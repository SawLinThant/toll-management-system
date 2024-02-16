using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    public partial class Setting : Form
    {
        Operation operationform;
        public int ReturnBaudrates { get; set; }
        public int ReturnStopbit { get; set; }

        public int ReturnDataBit { get; set; }

        public string ReturnParity { get; set; }

        public string ReturnPort { get; set; }
        public string ReturnBarrierPort { get; set; }
        public Setting()
        {
            InitializeComponent();
            cbx_barrierport.Text = Properties.Settings.Default.barrier_port.ToString();
            cbx_baudrate.SelectedItem = Properties.Settings.Default.baudrate.ToString();
            cbx_displayport.Text = Properties.Settings.Default.displayport.ToString();
            cbx_port.Text= Properties.Settings.Default.printer_port.ToString();
            cbx_databits.SelectedItem = Properties.Settings.Default.databit.ToString();
            cbx_stopbits.SelectedItem = Properties.Settings.Default.stopbit.ToString();
            cbx_pair.SelectedItem = Properties.Settings.Default.parity;
            IPaddresstxt.Text = Properties.Settings.Default.IPcamAddress;
            IPusernametxt.Text = Properties.Settings.Default.IPusername;
            IPpasswordtxt.Text = Properties.Settings.Default.IPpassword;
            tbx_clouddatabasename.Text= Properties.Settings.Default.clouddbname.ToString();
            tbx_clouddatabaseserver.Text = Properties.Settings.Default.cloudservername.ToString();
            tbx_clouddatabaseuid.Text = Properties.Settings.Default.clouddbuserid.ToString();
            tbx_clouddatabasepassword.Text = Properties.Settings.Default.clouddbpassword.ToString();
            tbx_listenaddress.Text= Properties.Settings.Default.ListenIPaddress.ToString();
            tbx_listenport.Text= Properties.Settings.Default.ANPRlistenport.ToString();
            tbx_ipcamport.Text= Properties.Settings.Default.IPcamport.ToString();
            tbx_printername.Text= Properties.Settings.Default.PrinterName.ToString();
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.baudrate = int.Parse(cbx_baudrate.SelectedItem.ToString());
            Properties.Settings.Default.barrier_port = cbx_barrierport.Text;
            Properties.Settings.Default.printer_port = cbx_port.Text;
            Properties.Settings.Default.databit = int.Parse(cbx_databits.SelectedItem.ToString());
            Properties.Settings.Default.stopbit = int.Parse(cbx_stopbits.SelectedItem.ToString());
            Properties.Settings.Default.parity = cbx_pair.SelectedItem.ToString();
            Properties.Settings.Default.IPcamAddress = IPaddresstxt.Text;
            Properties.Settings.Default.IPusername = IPusernametxt.Text;
            Properties.Settings.Default.IPpassword = IPpasswordtxt.Text;
            Properties.Settings.Default.Save();
             
            Menu menu = new Menu();
            menu.Show();
        }

        #region getting prots
        private void GetAvaiablePort()
        {
            string[] port = SerialPort.GetPortNames();
            if(cbx_port.Items.Count > 0 && cbx_barrierport.Items.Count>0 && cbx_displayport.Items.Count>0) 
            {
                cbx_port.Items.Clear();
                cbx_barrierport.Items.Clear();
                cbx_displayport.Items.Clear();
            }
            cbx_port.Items.AddRange(port);
            cbx_barrierport.Items.AddRange(port);
            cbx_displayport.Items.AddRange(port);
           
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            GetAvaiablePort();
        }

        #endregion

        #region setting
        private void cbx_port_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = cbx_port.Text;
        }

        private void cbx_baudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(cbx_baudrate.Text);
        }

        private void cbx_stopbits_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbx_stopbits.Text);
        }

        private void cbx_databits_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.DataBits = Convert.ToInt32(cbx_databits.Text);
        }

        private void cbx_pair_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cbx_pair.Text);
        }

        #endregion

        private void btn_refreshport_Click(object sender, EventArgs e)
        {
            GetAvaiablePort();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
				/*this.ReturnPort = cbx_port.Text;
                this.ReturnBarrierPort = cbx_barrierport.Text;
                this.ReturnBaudrates = Convert.ToInt32(cbx_baudrate.Text);
                this.ReturnStopbit = Convert.ToInt32(cbx_stopbits.Text);
                this.ReturnParity = cbx_pair.Text;
                this.ReturnDataBit = Convert.ToInt32(cbx_databits.Text);*/
				Properties.Settings.Default.baudrate = int.Parse(cbx_baudrate.SelectedItem.ToString());
				Properties.Settings.Default.barrier_port = cbx_barrierport.Text;
				Properties.Settings.Default.printer_port = cbx_port.Text;
                Properties.Settings.Default.displayport = cbx_displayport.Text;
                Properties.Settings.Default.databit = int.Parse(cbx_databits.SelectedItem.ToString());
				Properties.Settings.Default.stopbit = int.Parse(cbx_stopbits.SelectedItem.ToString());
				Properties.Settings.Default.parity = cbx_pair.SelectedItem.ToString();
                Properties.Settings.Default.IPcamAddress = IPaddresstxt.Text;
                Properties.Settings.Default.IPusername = IPusernametxt.Text;
                Properties.Settings.Default.IPpassword = IPpasswordtxt.Text;
                Properties.Settings.Default.PrinterName=tbx_printername.Text;
                Properties.Settings.Default.IPcamport = short.Parse(tbx_ipcamport.Text);
                Properties.Settings.Default.ListenIPaddress=tbx_listenaddress.Text;
                Properties.Settings.Default.ANPRlistenport=int.Parse(tbx_listenport.Text);
                Properties.Settings.Default.clouddbname=tbx_clouddatabasename.Text;
                Properties.Settings.Default.clouddbpassword=tbx_clouddatabasepassword.Text;
                Properties.Settings.Default.clouddbuserid=tbx_clouddatabaseuid.Text;
                Properties.Settings.Default.cloudservername = tbx_clouddatabaseserver.Text;
                    
                Properties.Settings.Default.Save();

				this.Visible = false;
                operationform = new Operation();
                if (operationform.Visible == false)
                {
                    Menu menu = new Menu();
                    menu.Show();
                }
				
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbx_barrierport_SelectedIndexChanged(object sender, EventArgs e)
        {        
                     serialPort2.PortName = cbx_barrierport.Text;
        }

        private void IPaddresstxt_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IPusernametxt_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IPpasswordtxt_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IPaddresstxt_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void IPusernametxt_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void IPpasswordtxt_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tbx_ipcamport_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_listenaddress_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_listenport_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_printername_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_clouddatabaseserver_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_clouddatabaseuid_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_clouddatabasename_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbx_clouddatabasepassword_Enter(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_ipcamport_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_listenaddress_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_listenport_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_printername_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_clouddatabaseserver_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_clouddatabaseuid_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_clouddatabasename_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }

        private void tbx_clouddatabasepassword_Leave(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                process.Kill();
            }
        }
    }
}
