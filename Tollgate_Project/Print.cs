using ESC_POS_USB_NET.Printer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tollgate_Project
{
    internal class Print
    {
        public void SerialPrinter(SerialPort serialPort1,byte[] barcode_command, byte[] printer_init, byte[] barcode_size, byte[] Papercut, int classes, string from, string to, string license, string gateid, string laneid)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con = ConnectionString.connectionstring;
                string cmd_getamount = @"select charge from amount where class='" + classes + "' and[from]='" + from + "' and [to]='" + to + "'";
                string Charge = "";
                try
                {                  
                    con.Open();
                    byte[] bytes = Encoding.ASCII.GetBytes(license);
                    byte[] data = barcode_command.Concat(bytes).ToArray();
                    data = data.Concat(new byte[] { 0x00 }).ToArray();

                    MySqlCommand cmd = new MySqlCommand(cmd_getamount, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Charge = Convert.ToString(dt.Rows[0][0]);
                    }
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                    }
                    serialPort1.Write("             Department of D.O.H\n");
                    serialPort1.Write("************************************************");
                    serialPort1.Write("Date:            " + Convert.ToString(DateTime.Now));
                    serialPort1.Write("\n");
                    serialPort1.Write("License:         " + license + "\n");
                    serialPort1.Write("Class No         " + classes + "\n");
                    serialPort1.Write("From             " + from + "\n");
                    serialPort1.Write("To               " + to + "\n");
                    serialPort1.Write("Charge:          " + Charge + "\n");
                    serialPort1.Write("Gate ID          " + gateid + "\n");
                    serialPort1.Write("lane ID          " + laneid + "\n");
                    serialPort1.Write(printer_init, 0, printer_init.Length);
                    serialPort1.Write(barcode_size, 0, barcode_size.Length);

                    serialPort1.Write(data, 0, data.Length);
                    serialPort1.Write(Papercut, 0, 5);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    if (con != null)
                    {
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*   public void USBPrinter(int classes, string from, string to, string license, string gateid, string laneid)
           {
               Printer printer = new Printer("POS-80C");

               string ESC = Convert.ToString((char)27);
               string GS = Convert.ToString((char)29);
               string center = ESC + "a" + (char)1; //align center
               string left = ESC + "a" + (char)0; //align left
               string bold_on = ESC + "E" + (char)1; //turn on bold mode
               string bold_off = ESC + "E" + (char)0; //turn off bold mode
               string cut = ESC + "d" + (char)1 + GS + "V" + (char)66;
               string initp = ESC + (char)64; //initialize printer
               string buffer = ""; //store all the data that want to be printed
               string QrData = "This voucher is already paid."; //data to be print in QR code

               Encoding m_encoding = Encoding.GetEncoding("UTF-8");
               int store_len = (QrData).Length + 3;
               byte store_pL = (byte)(store_len % 256);
               byte store_pH = (byte)(store_len / 256);
               buffer += m_encoding.GetString(new byte[] { 29, 40, 107, 48, 103, store_pL, store_pH });
               buffer += QrData;
               buffer += m_encoding.GetString(new byte[] { 29, 40, 107, 48, 129 });
               byte[] d1 = { 29, 40, 107, 48, 103, 10 };
               byte[] d2 = { 29, 40, 107, 48, 103, 10 };
               byte[] d3 = { 29, 40, 107, 48, 103, 10 };
               byte[] d4 = { 29, 40, 107, 48, 103, 10 };
               //buffer += cut + initp;

               try
               {               
                   printer.InitializePrint();              
                   printer.Append(buffer);
                   printer.Append( initp);
                   printer.FullPaperCut();
                   printer.PrintDocument();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
               finally { }
           }*/
        public void USBPrinter(int classes, string from, string to, string license, string gateid, string laneid)
        {
            Printer printer = new Printer(Properties.Settings.Default.PrinterName);
            SqlConnection con = new SqlConnection();
            con = ConnectionString.localconnectionstring;
            string cmd_getamount = @"select charge from amount where class='" + classes + "' and dirFrom='" + from + "' and dirTo='" + to + "'";
            string Charge = "";
            string ESC = Convert.ToString((char)27);
            string GS = Convert.ToString((char)29);
            string center = ESC + "a" + (char)1; //align center
            string left = ESC + "a" + (char)0; //align left
            string bold_on = ESC + "E" + (char)1; //turn on bold mode
            string bold_off = ESC + "E" + (char)0; //turn off bold mode
            string cut = ESC + "d" + (char)1 + GS + "V" + (char)66;
            string initp = ESC + (char)64; //initialize printer
            string buffer = ""; //store all the data that want to be printed
            string QrData = "Date:" + Convert.ToString(DateTime.Now) + "&"  //data to be print in QR code
            + "License:" + license + "&"
            + "Class:" + classes + "&"
            + "From:" + from + "&"
            + "To:" + to + "&"
            + "Charge:" + Charge + "&"
            + "Gate ID:" + gateid + "&"
            + "lane ID:" + laneid + "&";

            Encoding m_encoding = Encoding.GetEncoding("UTF-8");
            int store_len = (QrData).Length + 3;
            byte store_pL = (byte)(store_len % 256);
            byte store_pH = (byte)(store_len / 256);
            buffer += initp; //initialize printer
            buffer += m_encoding.GetString(new byte[] { 29, 40, 107, 4, 0, 49, 65, 50, 0 });
            buffer += m_encoding.GetString(new byte[] { 29, 40, 107, 3, 0, 49, 67, 8 });
            buffer += m_encoding.GetString(new byte[] { 29, 40, 107, 3, 0, 49, 69, 48 });
            buffer += m_encoding.GetString(new byte[] { 29, 40, 107, store_pL, store_pH, 49, 80, 48 });
            buffer += QrData;
            buffer += m_encoding.GetString(new byte[] { 29, 40, 107, 3, 0, 49, 81, 48 });
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmd_getamount, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Charge = Convert.ToString(dt.Rows[0][0]);
                }
                //printer.Font("Arial",ESC_POS_USB_NET.Enums.Fonts.FontA);
                printer.AlignCenter();
                printer.Append("Department of D.O.H");
                printer.NewLine();

                printer.AlignLeft();
                printer.Append("Date:            " + Convert.ToString(DateTime.Now));
                printer.Append("");
                printer.Append("License:         " + license);
                printer.Append("Class:           " + classes);
                printer.Append("From:            " + from);
                printer.Append("To:              " + to);
                printer.Append("Charge:          " + Charge);
                printer.Append("Gate ID :        " + gateid);
                printer.Append("lane ID :        " + laneid);
                printer.Append("");
                printer.SetLineHeight(1);
                printer.Append("________________________________________________");
                printer.Append("------------------------------------------------");
                printer.Append(center);
                printer.Append(buffer);
                //printer.Code128(license);
                printer.FullPaperCut();
                printer.PrintDocument();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }

        }
    }
}
