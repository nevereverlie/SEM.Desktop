using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using SEM.Desktop.Models;
using Timer = System.Threading.Timer;


namespace SEM.Desktop
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static User User { get; set; }
        public MainForm(User user)
        {
            InitializeComponent();
            User = user;
        }

        private FilterInfoCollection _filter;
        private VideoCaptureDevice _device;

        private void MainForm_Load(object sender, EventArgs e)
        {
            Array.ForEach(User.AllowedApps, app => allowedAppsTb.AppendText(Environment.NewLine + Regex.Unescape($"\\u2713 {app}")));

            _filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in _filter)
            {
                deviceCb.Items.Add(device.Name);
            }

            deviceCb.SelectedIndex = -1;
            _device = new VideoCaptureDevice();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (deviceCb.SelectedIndex == -1)
            {
                MessageBox.Show(@"No camera selected!", @"Error", MessageBoxButtons.OK);
                return;
            }

            _device = new VideoCaptureDevice(_filter[deviceCb.SelectedIndex].MonikerString);
            _device.NewFrame += Device_NewFrame;
            _device.Start();

            _ = new Timer(IsUserWorking, null, 0, Constants.FIVE_SECONDS);
        }

        private static readonly CascadeClassifier CascadeClassifier = new ("haarcascade_frontalface_alt_tree.xml");

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var bitmap = (Bitmap)eventArgs.Frame.Clone();
            var grayImage = bitmap.ToImage<Bgr, byte>();

            var rectangles = CascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            foreach (var rectangle in rectangles)
            {
                using var graphics = Graphics.FromImage(bitmap);
                using var pen = new Pen(Color.Green, 1);
                graphics.DrawRectangle(pen, rectangle);
            }
            cameraPb.Image = bitmap;
        }

        private async void IsUserWorking(Object state)
        {
            using var client = new HttpClient();
            try
            {
                var addMinuteResult = await client.PutAsync(Constants.API_URL + $"users/{User.UserId}/working/{IsAllowedApp()}", null);
                addMinuteResult.EnsureSuccessStatusCode();
                logsTb.AppendText($"\nUser {User.Lastname} {User.Firstname} worked in {GetActiveWindowTitle()} for 1 minute." );
            }
            catch (Exception)
            {
                await client.PutAsync(Constants.API_URL + $"users/{User.UserId}/working/{false}", null);
                logsTb.AppendText($"\nUser {User.Lastname} {User.Firstname} wasted 1 minute in {GetActiveWindowTitle()}.");
            }
        }

        private static bool IsAllowedApp()
        {
            string activeWindowTitle = GetActiveWindowTitle();
            return (User.AllowedApps.Contains(activeWindowTitle) && GetActiveWindowTitle() != string.Empty);
        }

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();

            return (GetWindowText(handle, buff, nChars) > 0 ? buff.ToString() : null) ?? string.Empty;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_device.IsRunning)
                _device.Stop();
        }
    }
}
