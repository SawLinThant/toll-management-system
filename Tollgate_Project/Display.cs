using Ozeki.VoIP;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tollgate_Project
{
    internal class Display
    {
        public static int CalculateCRC16(byte[] data)
        {
            int crc = 0xFFFF;
            for (int i = 0; i < data.Length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) == 1)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return crc;
        }
        public void WriteToDisplay(SerialPort serialPort,int classes, string from, string to)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = Properties.Settings.Default.displayport;
                    serialPort.BaudRate = 9600;
                    serialPort.StopBits = (StopBits)1;
                    serialPort.DataBits = 8;
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                    serialPort.Open();
                }

                string classno = Convert.ToString(classes);
                Context ctx = new Context();
                string charges = Convert.ToString(ctx.Getamount(classes, from, to));
                string displaydata = classno + "0" + charges;
                System.UInt16 charge = Convert.ToUInt16(displaydata);
                // int charge = services.Getamount(Convert.ToInt32(cbx_class.Text),cbx_from.Text,cbx_to.Text);
                byte[] chargedata = BitConverter.GetBytes(charge);
                Array.Reverse(chargedata);


                byte[] test = { 0xF1, 0x01, 0x01 };
                byte[] data = { 0x01, 0x06, 0x00, 0x02, };//working code
                                                          //byte[] data = { 0x01, 0x10, 0x00, 0x05,0x00,0x02,0x04, 0x40, 0xbc, 0x7a, 0xe1 };
                                                          //string modbusAsciiCommand = "01100000000102001FCD";
                                                          // byte[] data = { 0x01, 0x10, 0x00, 0x00, 0x00 ,0x01, 0x02, 0x00 ,0x02, 0xEA };
                                                          //byte[] data2 = { 0x01 ,0x03, 0x00, 0x14 ,0x00 ,0x08, 0xE0 };
                                                          //byte[] data = { 0x01, 0x06, 0x01, 0x01, 0x02, 0xED,0x0D,0x0A };
                                                          //byte[] clear_tare_weight = { 0x01, 0x06, 0x00, 0x48, 0x00, 0x00, 0x09, 0xDC };
                                                          //byte[] alarm = { 0x01, 0x06, 0x00, 0x08, 0x00, 0x02, 0x04, 0x12, 0x34, 0x56, 0x02, 0x08, 0xDE };
                                                          //  byte[] sample = { 0x01, 0x06, 0x00, 0x01, 0x01 };
                byte[] finaldata = data.Concat(chargedata).ToArray();

                if (serialPort.IsOpen)
                {
                    int crc = CalculateCRC16(finaldata);
                    byte[] crcBytes = BitConverter.GetBytes(crc);

                    byte[] transmitData = finaldata.Concat(crcBytes).ToArray();
                    serialPort.Write(transmitData, 0, transmitData.Length);
                }
            }
            catch { }
            finally
            {
                serialPort.Close();
            }

        }

    }
}
