using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tollgate_Project.Properties;
using System.Net.NetworkInformation;
using AForge.Video.DirectShow;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using Ozeki.VoIP;

namespace Tollgate_Project
{
    public partial class Operation : Form
    {
        string imagepath = @"C:\Users\User\Pictures\TollCaptureLic_YGNS633920240129111651873Pic.jpg";
        string from = "";
        string to = "";
        int classes = 0;
        FilterInfoCollection fic;
        VideoCaptureDevice vid;
        char[] datain = new char[150];
        byte[] Papercut = new byte[] { 27, 100, 6, 27, 109 };
        private Form activeform = null;
        USBCamera usb = null;
        HIKIPCam iPCam = null;
        byte[] barcode_command = new byte[] { 0x1d, 0x6b, 0x4 };
        byte[] printer_init = new byte[] { 27, 64 };
        byte[] barcode_size = new byte[] { 29, 104, 40 };
        private StringBuilder scannedData = new StringBuilder();
        int m_nSendType;                // Send type
        IntPtr m_pSendParams;           // Params

        public Operation()
        {
            Setting setting=new Setting();           
            InitializeComponent();
            cbx_printerselector.Text = Properties.Settings.Default.printerType;
            Screen screen = Screen.FromHandle(this.Handle);
            System.Drawing.Rectangle workingArea = screen.WorkingArea;
            this.Size = new Size(workingArea.Width, workingArea.Height);
            this.Location = new System.Drawing.Point(workingArea.Left, workingArea.Top);
            tbx_license.Enabled = false;
            tbx_class.Enabled = false;
            timer3.Start();
            bool bSendUseIp = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            // IP
            if (bSendUseIp)
            {
                m_nSendType = 0;
                string strParams = "192.168.2.200";//192.168.1.137
                m_pSendParams = Marshal.StringToHGlobalUni(strParams);
            }
            else
            {
                // Serial port see Cmd_GetBaudRate Cmd_SetBaudRate
                int nSerialPort = 4;
                int nBaudRate = 57600;
                string strParams = nSerialPort.ToString() + ":" + nBaudRate.ToString();

                m_nSendType = 1;
                m_pSendParams = Marshal.StringToHGlobalUni(strParams);
            }
        }

        private void Operation_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = Properties.Settings.Default.baudrate;
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Convert.ToString(Properties.Settings.Default.stopbit));
                serialPort1.DataBits = Properties.Settings.Default.databit;
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.parity);
                serialPort1.PortName = Properties.Settings.Default.printer_port;
                serialPort2.PortName = Properties.Settings.Default.barrier_port;
                serialPort2.BaudRate = 9600;
                serialPort2.StopBits = (StopBits)1;
                serialPort2.DataBits = 8;
                serialPort2.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort3.PortName = Properties.Settings.Default.displayport;
                serialPort3.BaudRate = 9600;
                serialPort3.StopBits = (StopBits)1;
                serialPort3.DataBits = 8;
                serialPort3.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            tbx_scannedbarcode.Focus();

        }
        #region keyboard
        private void button31_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button31.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button32.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button33.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button34.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button35.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button39.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button36.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button1.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button2.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button3.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button4.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button5.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button7.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button9.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button10.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button11.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button12.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button6.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button13.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button14.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button15.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button16.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button17.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button18.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button37.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button19.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button20.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button21.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button22.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button23.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button24.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button38.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button27.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button28.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button26.Text;
            tbx_scannedbarcode.Focus();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            tbx_license.Text += button25.Text;
            tbx_scannedbarcode.Focus();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tbx_license.Text = "";
            tbx_class.Text = "";
            tbx_scannedbarcode.Focus();
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {

            if ((String.Compare(tbx_license.Text, " ") < 0))
            {
                tbx_license.Text = tbx_license.Text.Substring(0, tbx_license.Text.Length - 1 + 1);
            }
            else
            {
                tbx_license.Text = tbx_license.Text.Substring(0, tbx_license.Text.Length - 1);
            }
            tbx_scannedbarcode.Focus();
        }
        #endregion

        #region from and to
        private void resetfrombutton()
        {
            btn_ygn.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_phyu.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_npt.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_mdy.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_tag.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_ski.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_mhl.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
        }
        private void resetbtnto()
        {
            btn_ygn2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_phyu2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_npt2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_mdy2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_tag2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_ski2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_mhl2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
        }

        private void btn_ygn_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_ygn.BackColor = System.Drawing.Color.AliceBlue;
            from = "YGN";
            tbx_scannedbarcode.Focus();
        }

        private void btn_npt_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_npt.BackColor = System.Drawing.Color.AliceBlue;
            from = "NPT";
            tbx_scannedbarcode.Focus();
        }

        private void btn_phyu_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_phyu.BackColor = System.Drawing.Color.AliceBlue;
            from = "PHYU";
            tbx_scannedbarcode.Focus();
        }

        private void btn_mhl_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_mhl.BackColor = System.Drawing.Color.AliceBlue;
            from = "MHL";
            tbx_scannedbarcode.Focus();
        }

        private void btn_ski_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_ski.BackColor = System.Drawing.Color.AliceBlue;
            from = "SKI";
            tbx_scannedbarcode.Focus();
        }

        private void btn_tag_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_tag.BackColor = System.Drawing.Color.AliceBlue;
            from = "TAG";
            tbx_scannedbarcode.Focus();
        }

        private void btn_mdy_Click(object sender, EventArgs e)
        {
            resetfrombutton();
            btn_mdy.BackColor = System.Drawing.Color.AliceBlue;
            from = "MDY";
            tbx_scannedbarcode.Focus();
        }

        private void btn_ygn2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_ygn2.BackColor = System.Drawing.Color.AliceBlue;
            to = "YGN";
            tbx_scannedbarcode.Focus();
        }

        private void btn_npt2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_npt2.BackColor = System.Drawing.Color.AliceBlue;
            to = "NPT";
            tbx_scannedbarcode.Focus();
        }

        private void btn_phyu2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_phyu2.BackColor = System.Drawing.Color.AliceBlue;
            to = "PHYU";
            tbx_scannedbarcode.Focus();
        }

        private void btn_mhl2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_mhl2.BackColor = System.Drawing.Color.AliceBlue;
            to = "MHL";
            tbx_scannedbarcode.Focus();
        }

        private void btn_ski2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_ski2.BackColor = System.Drawing.Color.AliceBlue;
            to = "SKI";
            tbx_scannedbarcode.Focus();
        }

        private void btn_tag2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_tag2.BackColor = System.Drawing.Color.AliceBlue;
            to = "TAG";
            tbx_scannedbarcode.Focus();
        }

        private void btn_mdy2_Click(object sender, EventArgs e)
        {
            resetbtnto();
            btn_mdy2.BackColor = System.Drawing.Color.AliceBlue;
            to = "MDY";
            tbx_scannedbarcode.Focus();
        }
        #endregion

        #region class buttons
        private void class_button_reset()
        {
            btn_class1.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class2.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class3.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class4.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class5.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class6.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class7.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class8.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);
            btn_class9.BackColor = System.Drawing.Color.FromArgb(9, 44, 179);

        }

        private void btn_class1_Click(object sender, EventArgs e)
        {
            class_button_reset();
          //  btn_class1.BackColor = System.Drawing.Color.AliceBlue;
            classes = 1;
            tbx_class.Text = "1";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class2_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class2.BackColor = System.Drawing.Color.AliceBlue;
            classes = 2;
            tbx_class.Text = "2";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class3_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class3.BackColor = System.Drawing.Color.AliceBlue;
            classes = 3;
            tbx_class.Text = "3";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class6_Click(object sender, EventArgs e)
        {
            class_button_reset();
            //btn_class6.BackColor = System.Drawing.Color.AliceBlue;
            classes = 6;
            tbx_class.Text = "6";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class5_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class5.BackColor = System.Drawing.Color.AliceBlue;
            classes = 5;
            tbx_class.Text = "5";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class4_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class4.BackColor = System.Drawing.Color.AliceBlue;
            classes = 4;
            tbx_class.Text = "4";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class9_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class9.BackColor = System.Drawing.Color.AliceBlue;
            classes = 9;
            tbx_class.Text = "9";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class8_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class8.BackColor = System.Drawing.Color.AliceBlue;
            classes = 8;
            tbx_class.Text = "8";
            tbx_scannedbarcode.Focus();
        }

        private void btn_class7_Click(object sender, EventArgs e)
        {
            class_button_reset();
           // btn_class7.BackColor = System.Drawing.Color.AliceBlue;
            classes = 7;
            tbx_class.Text = "7";
            tbx_scannedbarcode.Focus();
        }

        #endregion

        #region parsing value from setting

        private void formVisibleChanged(object sender, EventArgs e)
        {
            try
            {
              Setting setting=  (Setting)sender;
                if(!setting.Visible)
                {
                    serialPort1.BaudRate = Properties.Settings.Default.baudrate;
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Convert.ToString(Properties.Settings.Default.stopbit));
                    serialPort1.DataBits = Properties.Settings.Default.databit;
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.parity);
                    serialPort1.PortName = Properties.Settings.Default.printer_port;
                    serialPort2.PortName = Properties.Settings.Default.barrier_port;
                    serialPort2.BaudRate = 9600;
                    serialPort2.StopBits = (StopBits)1;
                    serialPort2.DataBits = 8; 
                    serialPort2.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                    setting.Dispose();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region print
       

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (pnl_videoviewer.Contains(usb)) usb.ScreenShot();
            Context ctx = new Context();

            LocalDatabaseQuery localDatabaseQuery = new LocalDatabaseQuery();
            int classno = Convert.ToInt32(tbx_class.Text);
            try
                {
                    string keyName = "license/" + tbx_license.Text + "_" + DateTime.Now.ToShortTimeString(); 
                    string s3BaseUrl = "https://tollgate-upload.s3.ap-southeast-1.amazonaws.com/";
                    string s3CompleteUrl = s3BaseUrl+keyName;
                    bool internetconnectivity = CheckInternetConnectivity();
                    string finalLicenseNo=tbx_license.Text.Replace("-","");
                    localDatabaseQuery.Addtolocaldatabase(classno, from, to, finalLicenseNo, cbx_gateid.Text, cbx_laneid.Text, s3CompleteUrl);
                    localDatabaseQuery.addbarcode(DateTime.Now.ToString()+" "+tbx_license.Text);
                    bool isCarExist = localDatabaseQuery.IsCarExist(finalLicenseNo);
                if (!isCarExist)
                {
                    localDatabaseQuery.AddtoCarDetail(tbx_class.Text,finalLicenseNo);
                }
                if(internetconnectivity)
                {
                    //AWSsync sync = new AWSsync();
                    MSSQLTOMYSQL sync= new MSSQLTOMYSQL();
                    sync.SyncMySqlData();
                    ctx.uploadS3(imagepath,keyName);//image path=local path
                }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
                if (cbx_printerselector.Text == "USB printer")
                {
                Print printer = new Print();
                printer.USBPrinter(classno, from, to, tbx_license.Text, cbx_gateid.Text, cbx_laneid.Text);
                    
                }

                if (cbx_printerselector.Text == "Serial Printer")
                {
                Print printer = new Print();
                printer.SerialPrinter(serialPort1, barcode_command, barcode_size, printer_init, Papercut, classno, from, to, tbx_license.Text, cbx_gateid.Text, cbx_laneid.Text);
                }
              
                int amount = localDatabaseQuery.Getamount(classno, from, to);
                string data ="Class-"+ classno.ToString()+" "+amount.ToString()+"ks";
                ledSendData(data);
                tbx_scannedbarcode.Focus();
        }
        #endregion

        #region camera
        private void OpenChildform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Left;
            pnl_videoviewer.Controls.Add(childform);
            pnl_videoviewer.Tag = childform;
            childform.BringToFront();
            childform.Show();
            
        }
        
        private void btn_usbcamera_Click(object sender, EventArgs e)
        {
            btn_ipcamera.BackColor = System.Drawing.Color.FromArgb(37, 40, 64);
            btn_usbcamera.BackColor = System.Drawing.Color.FromArgb(37, 40, 24);
            usb = new USBCamera();
            if(activeform != null)
            {
                activeform.Dispose();
            }
            OpenChildform(usb);
            tbx_scannedbarcode.Focus();
        }
        public void licenceHandler(string licence,string capturePic)
        {
            imagepath = capturePic;
            tbx_license.Text = licence;
            bool isCarExist;
            LocalDatabaseQuery query = new LocalDatabaseQuery();
            isCarExist=query.IsCarExist(licence);
            if (isCarExist)
            {
                tbx_class.Text=query.GetCarDetail(licence.Replace("-",""));
            }
            else
            {
                MessageBox.Show("Unregistered Car");
            }
            
           /*
            btn_usbcamera.BackColor = System.Drawing.Color.FromArgb(37, 40, 64);
            btn_ipcamera.BackColor = System.Drawing.Color.FromArgb(37, 40, 24);
            if (activeform != null)
            {
                activeform.Dispose();
            }
            iPCam=new HIKIPCam(licenceHandler);
            OpenChildform(iPCam);
        */
        }
        #endregion

        private void Operation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            
            if (vid != null)
            {
                if (vid.IsRunning)
                {
                    vid.Stop();
                    this.Close();
                }
            }
            
            if (iPCam != null)
            {
                iPCam.Logout();
                iPCam.Dispose();
            }
            if (vid != null)
            {
                if (vid.IsRunning)
                {
                    vid.Stop();
                    this.Close();
                }
            }
            if (activeform != null)
            {
                activeform.Dispose();
            }
            menu.Show();
        }
        #region BARRIER
        private void btn_barriorclose_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] command = new byte[] { 0x55, 0x56, 0x00, 0x00, 0x00, 0x02, 0x01, 0xAE };
                if (!serialPort2.IsOpen)
                {
                    serialPort2.Open();
                }
                serialPort2.Write(command, 0, command.Length);
                if (serialPort2.IsOpen)
                {
                    serialPort2.Close();

                }
                timer2.Enabled = true;
                string ledText = "";
                ledSendData(ledText);
                tbx_scannedbarcode.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btn_barrioropen_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] command = new byte[] { 0x55, 0x56, 0x00, 0x00, 0x00, 0x01, 0x01, 0xAD };

                if (!serialPort2.IsOpen)
                {
                    serialPort2.Open();
                }
                serialPort2.Write(command, 0, command.Length);
                if (serialPort2.IsOpen)
                {
                    serialPort2.Close();
                }
                timer1.Enabled = true;
                string data = "Thank You";
                ledSendData(data);
                tbx_scannedbarcode.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbx_scannedbarcode.Text = "";
            }
                                
        }
        

        private void t1_tk(object sender, EventArgs e)
        {
            byte[] command = new byte[] { 0x55, 0x56, 0x00, 0x00, 0x00, 0x01, 0x02, 0xAE };
            if (!serialPort2.IsOpen)
            {
                serialPort2.Open();
            }
            serialPort2.Write(command, 0, command.Length);
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();

            }
            timer1.Enabled = false;
        }
            
        private void timer2_Tick(object sender, EventArgs e)
        {
            byte[] command = new byte[] {0x55, 0x56, 0x00, 0x00, 0x00, 0x02, 0x02, 0xAF   };
            if (!serialPort2.IsOpen)
            {
                serialPort2.Open();
            }
            serialPort2.Write(command, 0, command.Length);
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();

            }
            timer2.Enabled = false;
        }
        #endregion 

       

        #region add data to cloud server
        private bool CheckInternetConnectivity()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com");
                    return (result.Status == IPStatus.Success);
                }
            }
            catch
            {
                return false;
                
            }
           
        }
       
      
       
        #endregion

        private void tbx_QR_TextChanged(object sender, EventArgs e)
        {

        }

        #region unnecessary
        

        private void btn_start_Click(object sender, EventArgs e)
        {
            
        }

        

        private void btn_stop_Click(object sender, EventArgs e)
        {
            
        }

        private void cbx_source_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnl_buttons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Operation_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if(tbx_scannedbarcode.Focus()==true)
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    //string barcode = tbx_scannedbarcode.Text;
                    //
                    
                    // tbx_scannedbarcode.Clear();

                    // MessageBox.Show(barcode);
                }
                else
                {
                    // tbx_scannedbarcode.Text += Convert.ToString(e.KeyChar);
                    string barcodescanned = tbx_scannedbarcode.Text;
                    SearchBarcode(barcodescanned);
                }
            }
           */
            //tbx_scannedbarcode.Focus();
        }
        #endregion
        

        private void tbx_scannedbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void IPWebBtn_Click(object sender, EventArgs e)
        {
           // var ipwebcam = new IPCamWeb();
           // ipwebcam.Show();
           if(activeform is IPCamWeb)
           {
                var ipcam= (IPCamWeb)activeform;
                ipcam.hidenavbar();
           }
        }

        ~Operation()
        {
            Marshal.FreeHGlobal(m_pSendParams);
        }

        private void ledSendData(string data)
        {
            try
            {
                IntPtr pNULL = new IntPtr(0);

                int nErrorCode = -1;
                // 1. Create a screen
                int nWidth = 64;
                int nHeight = 64;
                int nColor = 1;
                int nGray = 1;
                int nCardType = 0;

                int nRe = CSDKExport.Hd_CreateScreen(nWidth, nHeight, nColor, nGray, nCardType, pNULL, 0);
                if (nRe != 0)
                {
                    nErrorCode = CSDKExport.Hd_GetSDKLastError();
                    return;
                }

                // 2. Add program to screen
                int nProgramID = CSDKExport.Hd_AddProgram(pNULL, 0, 0, pNULL, 0);
                if (nProgramID == -1)
                {
                    nErrorCode = CSDKExport.Hd_GetSDKLastError();
                    return;
                }

                int nX = 0;
                int nY = 0;
                int nAreaWidth = 64;
                int nAreaHeight = 64;

                // 3. Add Area to program
                int nAreaID = CSDKExport.Hd_AddArea(nProgramID, nX, nY, nAreaWidth, nAreaHeight, pNULL, 0, 0, pNULL, 0);
                if (nAreaID == -1)
                {
                    nErrorCode = CSDKExport.Hd_GetSDKLastError();
                    return;
                }

                // 4.Add text AreaItem to Area
                IntPtr pText = Marshal.StringToHGlobalUni(data);
                IntPtr pFontName = Marshal.StringToHGlobalUni("Arial");
                int nTextColor = CSDKExport.Hd_GetColor(255, 0, 0);

                // center in bold and underlin
                int nTextStyle = 0x0100 | 0x0000 | 0x0000;
                int nAreaItemID = CSDKExport.Hd_AddSimpleTextAreaItem(nAreaID, pText, nTextColor, 0, nTextStyle,
                    pFontName, 14, 0, 30, 201, 3, pNULL, 0);
                if (nAreaItemID == -1)
                {
                    Marshal.FreeHGlobal(pText);
                    Marshal.FreeHGlobal(pFontName);
                    nErrorCode = CSDKExport.Hd_GetSDKLastError();
                    return;
                }
                Marshal.FreeHGlobal(pText);
                Marshal.FreeHGlobal(pFontName);

                // 5. Send to device 
                nRe = CSDKExport.Hd_SendScreen(m_nSendType, m_pSendParams, pNULL, pNULL, 0);
                if (nRe != 0)
                {
                    nErrorCode = CSDKExport.Hd_GetSDKLastError();
                    MessageBox.Show("Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void cbx_gateid_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbx_scannedbarcode.Focus();
        }

        private void cbx_laneid_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbx_scannedbarcode.Focus();
        }

        private void tbx_scannedbarcode_TextChanged(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            tbx_scannedbarcode.Text = "";
        }

        private void btn_ipcamera_Click(object sender, EventArgs e)
        {
            btn_usbcamera.BackColor = System.Drawing.Color.FromArgb(37, 40, 64);
            btn_ipcamera.BackColor = System.Drawing.Color.FromArgb(37, 40, 24);
            if (activeform != null)
            {
                activeform.Dispose();
            }
            //OpenChildform(new IPcamera());
            // iPCam = new IPCamWeb(Properties.Settings.Default.IPusername, Properties.Settings.Default.IPpassword, Properties.Settings.Default.IPcamAddress);
            iPCam = new HIKIPCam(licenceHandler);
            OpenChildform(iPCam);
            tbx_scannedbarcode.Focus();
        }

        private void cbx_printerselector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.printerType = cbx_printerselector.Text;
            Properties.Settings.Default.Save();
            tbx_scannedbarcode.Focus();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                bool internetconnectivity = CheckInternetConnectivity();
                int classno = Convert.ToInt32(tbx_class.Text);
                string finalLicenseNo = tbx_license.Text.Replace("-", "");
                string keyName = "license/" + tbx_license.Text + "_" + DateTime.Now.ToShortTimeString();
                string s3BaseUrl = "https://tollgate-upload.s3.ap-southeast-1.amazonaws.com/";
                string s3CompleteUrl = s3BaseUrl + keyName;
                LocalDatabaseQuery localDatabaseQuery = new LocalDatabaseQuery();
                localDatabaseQuery.FreeChargedCars(classno, from, to, finalLicenseNo, cbx_gateid.Text, cbx_laneid.Text, s3CompleteUrl);
                string data = "Class-" + classno.ToString() + " 0ks";
                ledSendData(data);
                if (internetconnectivity)
                {
                    //AWSsync sync = new AWSsync();
                    MSSQLTOMYSQL sync = new MSSQLTOMYSQL();
                    sync.SyncMySqlData();
                    Context ctx = new Context();
                    ctx.uploadS3(imagepath, keyName);//image path=local path
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btn_barcodeclear_Click(object sender, EventArgs e)
        {
            tbx_scannedbarcode.Text = "";
            tbx_scannedbarcode.Focus();
        }
    }



}
