
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using utils;

//namespace Tollgate_Project
//{
//    public partial class HIKIPCam : Form
//    {
//        HikIPCam ipCam;
//        public delegate void LicenceHandler(string licence, string cpaturePic);
//         LicenceHandler licenceHandler;
//        public HIKIPCam()
//        {

//            InitializeComponent();

//            ipCam = new HikIPCam(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), onLicenceDetected);

//            ipCam.LogIn(Properties.Settings.Default.IPcamAddress, Properties.Settings.Default.IPcamport, Properties.Settings.Default.IPusername, Properties.Settings.Default.IPpassword);
//            ipCam.SetUpAnpr(Properties.Settings.Default.ListenIPaddress, Properties.Settings.Default.ANPRlistenport);
//            ipCam.StartLiveView(picbx_ipcam.Handle);

//        }
//        public HIKIPCam(LicenceHandler licenceHandler)
//        {

//            InitializeComponent();

//            ipCam = new HikIPCam(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), onLicenceDetected);
//            this.licenceHandler = licenceHandler;
//            ipCam.LogIn(Properties.Settings.Default.IPcamAddress, Properties.Settings.Default.IPcamport, Properties.Settings.Default.IPusername, Properties.Settings.Default.IPpassword);
//            ipCam.SetUpAnpr(Properties.Settings.Default.ListenIPaddress, Properties.Settings.Default.ANPRlistenport);
//            ipCam.StartLiveView(picbx_ipcam.Handle);
//            this.licenceHandler = licenceHandler;
//        }

//        private void HIKIPCam_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            ipCam.StopLiveView(picbx_ipcam.Handle);
//            ipCam.LogOut();
//        }
//        public void onLicenceDetected(string licence,string capturePic)
//        {
//            licenceHandler(licence, capturePic);
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using utils;

namespace Tollgate_Project
{
    public partial class HIKIPCam : Form
    {
        HikIPCam ipCam;
        public delegate void LicenceHandler(string licence, string cpaturePic);
        LicenceHandler licenceHandler;
        public HIKIPCam()
        {

            InitializeComponent();

            ipCam = new HikIPCam(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), onLicenceDetected);

            ipCam.LogIn(Properties.Settings.Default.IPcamAddress, Properties.Settings.Default.IPcamport, Properties.Settings.Default.IPusername, Properties.Settings.Default.IPpassword);
            ipCam.SetUpAnpr(Properties.Settings.Default.ListenIPaddress, Properties.Settings.Default.ANPRlistenport);
            ipCam.StartLiveView(picbx_ipcam.Handle);

        }
        ~HIKIPCam()
        {
            if (ipCam != null)
            {
                ipCam.StopLiveView(picbx_ipcam.Handle);
                ipCam.LogOut();
                ipCam.Dispose();
            }
        }
        public HIKIPCam(LicenceHandler licenceHandler)
        {

            InitializeComponent();

            ipCam = new HikIPCam(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), onLicenceDetected);
            this.licenceHandler = licenceHandler;
            if (ipCam.LogIn(Properties.Settings.Default.IPcamAddress, Properties.Settings.Default.IPcamport, Properties.Settings.Default.IPusername, Properties.Settings.Default.IPpassword))
            {
                ipCam.SetUpAnpr(Properties.Settings.Default.ListenIPaddress, Properties.Settings.Default.ANPRlistenport);
                ipCam.StartLiveView(picbx_ipcam.Handle);
                this.licenceHandler = licenceHandler;
            }


        }

        private void HIKIPCam_FormClosed(object sender, FormClosedEventArgs e)
        {
            ipCam.StopLiveView(picbx_ipcam.Handle);
            ipCam.LogOut();
            if (ipCam != null)
            {
                ipCam.Dispose();
            }

        }
        public void onLicenceDetected(string licence, string capturePic)
        {
            licenceHandler(licence, capturePic);
        }
        public void Logout()
        {
            ipCam.StopLiveView(picbx_ipcam.Handle);
            ipCam.LogOut();
        }
    }
}