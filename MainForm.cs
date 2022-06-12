using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using SEM.Desktop.Models;
using SEM.Desktop.Extensions;
using static System.Threading.Timer;
using System.Net.Http.Headers;

namespace SEM.Desktop
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static User User { get; set; }
        public static ResponseToken Token { get; set; }

        private Image currentCamSnapshot;

        private System.Threading.Timer timer;
        public MainForm(User user, ResponseToken token)
        {
            InitializeComponent();
            User = user;
            Token = token;
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

            timer = new System.Threading.Timer(IsUserWorking, null, Constants.FIVE_SECONDS, Constants.TEN_SECONDS);
            runBtn.Enabled = false;
        }

        private static readonly CascadeClassifier CascadeClassifier = new ("haarcascade_frontalface_alt_tree.xml");

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var bitmap = (Bitmap)eventArgs.Frame.Clone();
            currentCamSnapshot = (Image)bitmap.Clone();
            var grayImage = bitmap.ToImage<Bgr, byte>();

            var rectangles = CascadeClassifier.DetectMultiScale(grayImage, 1.1, 1);
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
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token.Token);
            try
            {
                bool isUserWorking = IsAllowedApp();
                if (!isUserWorking)
                {
                    await client.PutAsync(Constants.API_URL + $"users/{User.UserId}/working/{false}", null);
                    logsTb.Invoke(new Action(() =>
                        logsTb.AppendText(Environment.NewLine + $"\nUser {User.Lastname} {User.Firstname} wasted 1 minute in {GetActiveWindowTitle()}.")));
                    
                    return;
                }

                var byteArray = ImageToByteArray(currentCamSnapshot);

                var formContent = new MultipartFormDataContent
                {
                    { new ByteArrayContent(byteArray), "file", "file.jpg" }
                };

                HttpResponseMessage response = await client.PostAsync(Constants.API_URL + $"users/{User.UserId}/face", formContent);
                response.EnsureSuccessStatusCode();

                bool isFaceDetected = response.Content.ReadAsAsync<bool>().Result;
                if (isFaceDetected)
                {
                    var addMinuteResult = await client.PutAsync(Constants.API_URL + $"users/{User.UserId}/working/{true}", null);
                    addMinuteResult.EnsureSuccessStatusCode();

                    logsTb.Invoke(new Action(() =>
                        logsTb.AppendText(Environment.NewLine + $"\nUser {User.Lastname} {User.Firstname} worked in {GetActiveWindowTitle()} for 1 minute.")));
                    
                    return;
                }

                logsTb.Invoke(new Action(() =>
                    logsTb.AppendText(Environment.NewLine + $"\nUser {User.Lastname} {User.Firstname} has NOT been present for 1 minute.")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception happened", MessageBoxButtons.OK);
            }
        }

        private static bool IsAllowedApp()
        {
            string activeWindowTitle = GetActiveWindowTitle();
            return (User.AllowedApps.Any(activeWindowTitle.Contains) && GetActiveWindowTitle() != string.Empty);
        }

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();

            return (GetWindowText(handle, buff, nChars) > 0 ? buff.ToString() : null) ?? string.Empty;
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_device.IsRunning)
            {
                _device.SignalToStop();
                _device.WaitForStop();
            }
        }
    }
}
