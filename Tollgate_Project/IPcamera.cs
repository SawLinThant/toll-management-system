using Ozeki.Camera;
using Ozeki.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tollgate_Project
{
    public partial class IPcamera : Form
    {
        private string IPnumber = "";
        private string username = "";
        private string password = "";
        private IIPCamera _camera;
        private DrawingImageProvider _imageProvider = new DrawingImageProvider();
        private MediaConnector _connector = new MediaConnector();
        private VideoResizer _resizeHandler;
        private VideoViewerWF _videoViewerWF1;
        private SnapshotHandler _snapshotHandler;
        public IPcamera()
        {
            InitializeComponent();
            // Create video viewer UI control
            _videoViewerWF1 = new VideoViewerWF();
            _videoViewerWF1.Name = "videoViewerWF1";
            _videoViewerWF1.Size = panel2.Size;
            _videoViewerWF1.Dock = DockStyle.Fill;
            _snapshotHandler = new SnapshotHandler();
            panel2.Controls.Add(_videoViewerWF1);
            tbx_ipno.Text = Properties.Settings.Default.IPcamAddress.ToString();
            tbx_username.Text= Properties.Settings.Default.IPusername.ToString();
            tbx_password.Text = Properties.Settings.Default.IPpassword.ToString();
            // Bind the camera image to the UI control
            _resizeHandler=new VideoResizer();


            _videoViewerWF1.SetImageProvider(_imageProvider);
            _videoViewerWF1.Start();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.IPcamAddress = tbx_ipno.Text;
                Properties.Settings.Default.IPusername= tbx_username.Text;
                Properties.Settings.Default.IPpassword= tbx_password.Text;
                IPnumber = tbx_ipno.Text;
                username = tbx_username.Text;
                password = tbx_password.Text;
                //_camera = IPCameraFactory.GetCamera("rtsp://" +"@"+ IPnumber+":554" + "/cam/realmonitor?channel=1&subtype=1", username, password);
                _camera=new IPCamera("rtsp://" + "@" + IPnumber + ":554" + "/cam/realmonitor?channel=1&subtype=1", username, password);
                _resizeHandler.SetResolution(640, 480);
                _connector.Connect(_camera.VideoChannel, _resizeHandler);
                _connector.Connect(_resizeHandler, _imageProvider);
                
                _connector.Connect(_camera.VideoChannel, _snapshotHandler);
                _camera.CameraStateChanged += _camera_CameraStateChanged;
               
                _camera.Start();
               


            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            
        }
        private void _camera_CameraStateChanged(object sender, CameraStateEventArgs e)
        {
            if(e.State == CameraState.StreamConnecting)
            {
                UpdateConnectBtnLabel("Connecting");

            }
            if (e.State == CameraState.Streaming)
            {
                UpdateConnectBtnLabel("Connected");
                SetResolution();

            }

        }
        private void SetResolution()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if(_camera.CurrentStream.VideoEncoding!=null)
                    _camera.CurrentStream.VideoEncoding.SetAttributes(new IPCameraVideoEncoding { FrameRate = 20 });
                }));
            }
        }
        private void UpdateConnectBtnLabel(string text)
        {
            if (btn_connect.InvokeRequired)
            {
                btn_connect.Invoke((MethodInvoker)(()=> btn_connect.Text = text));
            }
            else
                btn_connect.Text = text;
        }

        private void CreateSnapShot(string path)
        {
            var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                       DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
            string currentpath;
            if (String.IsNullOrEmpty(path))
                currentpath = date + ".jpg";
            else
                currentpath = path + "\\" + date + ".jpg";
            /*
            var snapShotImage = _snapshotHandler.TakeSnapshot().ToImage();
            snapShotImage.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            */
            Image snapShotImage = (Image)_snapshotHandler.TakeSnapshot().ToImage();
            snapShotImage.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void btn_snapshot_Click(object sender, EventArgs e)
        {
            var path = tbx_path.Text;
            CreateSnapShot(path);
        }

        private void IPcamera_Load(object sender, EventArgs e)
        {

        }

        private void tbx_ipno_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void tbx_username_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void tbx_password_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void tbx_ipno_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_username_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_password_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IPcamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_camera != null)
            {
                _camera.Disconnect();
                _camera.Dispose();
                if(_videoViewerWF1!=null)
                _videoViewerWF1.Dispose();
            }
        }

        public string StreamInfoVideo()
        {
            var sb = new StringBuilder();

            sb.AppendLine(" - Video Encoding \n");
            if (_camera.CurrentStream.VideoEncoding != null)
            {
                sb.AppendLine("\t Bitrate - " + _camera.CurrentStream.VideoEncoding.BitRate + "\n");
                sb.AppendLine("\t Encoding - " + _camera.CurrentStream.VideoEncoding.Encoding + "\n");
                sb.AppendLine("\t Encoding interval - " + _camera.CurrentStream.VideoEncoding.EncodingInterval + "\n");
                sb.AppendLine("\t Framerate - " + _camera.CurrentStream.VideoEncoding.FrameRate + "\n");
                sb.AppendLine("\t Quality - " + _camera.CurrentStream.VideoEncoding.Quality + "\n");
                sb.AppendLine("\t Resolution - " + _camera.CurrentStream.VideoEncoding.Resolution + "\n");
                sb.AppendLine("\t Session time out - " + _camera.CurrentStream.VideoEncoding.SessionTimeout + "\n");
                sb.AppendLine("\t Use count - " + _camera.CurrentStream.VideoEncoding.UseCount + "\n");
            }
            sb.AppendLine(" - Video Source \n");
            if (_camera.CurrentStream.VideoSource != null)
            {
                sb.AppendLine("\t Bounds - " + _camera.CurrentStream.VideoSource.Bounds + "\n");
                sb.AppendLine("\t Use count - " + _camera.CurrentStream.VideoSource.UseCount + "\n");
            }
            return sb.ToString();
        }
    }
}
