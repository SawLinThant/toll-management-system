using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Capture = Emgu.CV.Capture;

namespace Tollgate_Project
{
   
    public partial class USBCamera : Form
    {
        
        Capture capture;
        bool _streaming = false;
        public Image ScreenShots { get; set; }
        public USBCamera()
        {
            InitializeComponent();
        }
        private void streaming(object sender, System.EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    var img = capture.QueryFrame().ToImage<Bgr, byte>();
                    var bmp = img.Bitmap;
                    pictureBox1.Image = bmp;                 
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Idle -= streaming;
                btn_streamonoff.Text = @"Stream is off";
                capture.Dispose();
            }
        }

        private void btn_streamonoff_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_streaming)
                {

                    capture = new Capture(Convert.ToInt32(cbx_camsource.Text));
                    Application.Idle += streaming;
                    btn_streamonoff.Text = @"Stream is on";
                }
                else
                {
                    Application.Idle -= streaming;
                    btn_streamonoff.Text = @"Stream is off";
                    capture.Dispose();
                }
                _streaming = !_streaming;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Idle -= streaming;
                btn_streamonoff.Text = @"Stream is off";
               // capture.Dispose();
            }
        }

        public void  ScreenShot()
        {
            try
            {
                Image image = pictureBox1.Image;
                if (image != null)
                {
                    string fileName = "image_" + DateTime.Now.ToString("M_d_yyyy h_m tt") + ".jpg"; // add timestamp to file name
                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), fileName); // set default file path
                    image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
