using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;


namespace SEM.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        FilterInfoCollection filter;
        VideoCaptureDevice device;

        private void MainForm_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filter)
            {
                deviceCb.Items.Add(device.Name);
            }

            deviceCb.SelectedIndex = 0;
            device = new VideoCaptureDevice();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(filter[deviceCb.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }

        private static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var bitmap = (Bitmap)eventArgs.Frame.Clone();
            var grayImage = bitmap.ToImage<Bgr, byte>();

            var rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            foreach (var rectangle in rectangles)
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    using (var pen = new Pen(Color.Green, 1))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }
            cameraPb.Image = bitmap;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
                device.Stop();
        }
    }
}
