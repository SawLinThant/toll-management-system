
//using AlarmCSharpDemo;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Windows.Forms;


//namespace Tollgate_Project
//{
//    public class HikIPCam
//    {
//        private Int32 m_lUserID = -1;
//        private uint iLastErr = 0;
//        private Int32 m_lRealHandle = -1;
//        private bool m_bInitSDK = false;
//        CHCNetSDK.REALDATACALLBACK RealData = null;
//        public int m_iChannel = -1;
//        public string strLocalFilePath="";
//        private Int32 m_iListenHandle = -1;
//        private CHCNetSDK.MSGCallBack_V31 m_falarmData_V31 = null;
//        public  delegate void OnLicenceDetected(string licence,string captureLicencePath);
//        Image img = null;
//        public OnLicenceDetected onLicenceDetected;
//        private CHCNetSDK.MSGCallBack m_falarmData = null;
//        public delegate void UpdateListBoxCallback(string strAlarmTime, string strDevIP, string strAlarmMsg);

//        public HikIPCam()
//        {

//            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
//            if (m_bInitSDK == false)
//            {
//                MessageBox.Show("NET_DVR_Init error!");
//                return;
//            }
//            else
//            {
//                //MessageBox.Show("NET_DVR_Init success!");
//                CHCNetSDK.NET_DVR_SetValidIP(0, true); //绑定第一张网卡
//                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
//                if (m_falarmData_V31 == null)
//                {
//                    m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
//                }
//                CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);

//                //Control.CheckForIllegalCrossThreadCalls = false;
//            }

//        }

//        public void Dispose()
//        {
//            this.Dispose();
//        }

//        public HikIPCam(string picDirectory, OnLicenceDetected onLicenceDetected)
//        {
//            this.strLocalFilePath = picDirectory;
//            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
//            if (m_bInitSDK == false)
//            {
//                MessageBox.Show("NET_DVR_Init error!");
//                return;
//            }
//            else
//            {
//                //MessageBox.Show("NET_DVR_Init success!");
//                CHCNetSDK.NET_DVR_SetValidIP(0, true); //绑定第一张网卡
//                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
//                if (m_falarmData_V31 == null)
//                {
//                    m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
//                }
//                CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);

//                //Control.CheckForIllegalCrossThreadCalls = false;
//            }

//            this.onLicenceDetected = onLicenceDetected;
//        }
//        public void deleagetTest()
//        {
//            onLicenceDetected("this is delegate test", "");
//        }

//        public Boolean LogIn(string ipAddress, Int16 portNo, string userName, string password)
//        {
//            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
//            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(ipAddress, portNo, userName, password, ref DeviceInfo);
//            if (m_lUserID < 0)
//            {
//                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
//                string result = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //µÇÂ¼Ê§°Ü£¬Êä³ö´íÎóºÅ
//                MessageBox.Show(result + "\n" + "Please check your Ip camera configuration.");
//                return false;
//            }
//            else
//            {
//                //µÇÂ¼³É¹¦
//                MessageBox.Show("Login Success!" + m_lUserID);

//                return true;
//            }
//        }
//        public bool LogOut()
//        {
//            if (m_lRealHandle >= 0)
//            {
//                MessageBox.Show("No camera is logged in.");
//                return false;
//            }

//            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
//            {
//                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
//                string result = "NET_DVR_Logout failed, error code= " + iLastErr;
//                MessageBox.Show(result);
//                return false;
//            }
//            m_lUserID = -1;
//            return true;
//        }


//        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
//        {
//            if (dwBufSize > 0)
//            {
//                byte[] sData = new byte[dwBufSize];
//                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

//                string str = "ÊµÊ±Á÷Êý¾Ý.ps";
//                FileStream fs = new FileStream(str, FileMode.Create);
//                int iLen = (int)dwBufSize;
//                fs.Write(sData, 0, iLen);
//                fs.Close();
//            }
//        }
//        public Boolean StartLiveView(IntPtr pictureBoxHandle)
//        {
//            try
//            {
//                if (m_lUserID < 0)
//                {
//                    //MessageBox.Show("Please login the device firstly");
//                    return false;
//                }
//                if (m_lRealHandle < 0)
//                {
//                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
//                    lpPreviewInfo.hPlayWnd = pictureBoxHandle;//Ô¤ÀÀ´°¿Ú
//                    lpPreviewInfo.lChannel = 1;//Ô¤teÀÀµÄÉè±¸Í¨µÀ
//                    lpPreviewInfo.dwStreamType = 0;//ÂëÁ÷ÀàÐÍ£º0-Ö÷ÂëÁ÷£¬1-×ÓÂëÁ÷£¬2-ÂëÁ÷3£¬3-ÂëÁ÷4£¬ÒÔ´ËÀàÍÆ
//                    lpPreviewInfo.dwLinkMode = 0;//Á¬½Ó·½Ê½£º0- TCP·½Ê½£¬1- UDP·½Ê½£¬2- ¶à²¥·½Ê½£¬3- RTP·½Ê½£¬4-RTP/RTSP£¬5-RSTP/HTTP 
//                    lpPreviewInfo.bBlocked = true; //0- ·Ç×èÈûÈ¡Á÷£¬1- ×èÈûÈ¡Á÷
//                    lpPreviewInfo.dwDisplayBufNum = 1; //²¥·Å¿â²¥·Å»º³åÇø×î´ó»º³åÖ¡Êý
//                    lpPreviewInfo.byProtoType = 0;
//                    lpPreviewInfo.byPreviewMode = 0;

//                    if (RealData == null)
//                    {
//                        RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//Ô¤ÀÀÊµÊ±Á÷»Øµ÷º¯Êý
//                    }

//                    IntPtr pUser = new IntPtr();//ÓÃ»§Êý¾Ý

//                    //´ò¿ªÔ¤ÀÀ Start live view 
//                    m_lRealHandle =CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
//                    if (m_lRealHandle < 0)
//                    {
//                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
//                        string result = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //Ô¤ÀÀÊ§°Ü£¬Êä³ö´íÎóºÅ
//                        MessageBox.Show(result);
//                        return false;
//                    }
//                    else
//                    {
//                        //Ô¤ÀÀ³É¹¦
//                        return true;
//                    }
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//                return false;
//            }
//        }
//        public Boolean StopLiveView(IntPtr pictureBoxHandle)
//        {
//            try
//            {
//                if (!(m_lRealHandle < 0))
//                {
//                    if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
//                    {
//                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
//                        string result = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
//                        MessageBox.Show(result);
//                        return false;
//                    }
//                    m_lRealHandle = -1;
//                }
//                return true;
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//                return false;
//            }
//        }
//        public bool SetUpAnpr(string listenIp,int listenPort)
//        {
//            try
//            {

//                ArmCamera();
//                StartListen(listenIp, listenPort);
//                return true;
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//                return false;
//            }
//        }

//        //private IDeviceTree g_deviceTree = PluginsFactory.GetDeviceTreeInstance();
//        public bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)

//        {



//            AlarmMessage(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);



//            return true; 

//        }
//        public void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)

//        {



//            AlarmMessage(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);

//        }
//        public void AlarmMessage(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
//        {
//            switch (lCommand)
//            {
//                // License plate recognition alarm upload
//                case CHCNetSDK.COMM_UPLOAD_PLATE_RESULT:
//                    break;
//                case CHCNetSDK.COMM_ITS_PLATE_RESULT:
//                    ProcessCommAlarm_ITS(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
//                    break;
//                default:
//                    break;
//            }

//        }
//        private void ProcessCommAlarm_ITS(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
//        {

//            //             if (this.InvokeRequired)
//            //             {
//            //                 ProcessCommAlarm_ITS_Handle handle = new ProcessCommAlarm_ITS_Handle(ProcessCommAlarm_ITS);
//            //                 this.BeginInvoke(handle, pAlarmer, pAlarmInfo, dwBufLen, pUser);
//            //             }
//            //             else
//            //             {
//            //pAlarmInfo数据异常导致无法解析到正常数据，注释掉if...else...后正常


//            //获取当前系统时间
//            string datatimenow = DateTime.Now.ToString("yyyyMMddhhmmssfff");
//            //车牌图片存储路径
//            string strPicFilePath = "";
//            //车辆检测图片存储路径
//            string strPicFilePathB = "";
//            //ANPR展示数据存储路径
//            string strShowDataPath = "";
//            string captureFilepath = "";
//            //报警信息解析
//            //IDeviceTree.DeviceInfo deviceInfo = m_deviceTree.GetSelectedDeviceInfo();
//            CHCNetSDK.NET_ITS_PLATE_RESULT struITSPlateResult = new CHCNetSDK.NET_ITS_PLATE_RESULT();
//            uint dwSize = (uint)Marshal.SizeOf(struITSPlateResult);
//            struITSPlateResult = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));
//            CHCNetSDK.NET_DVR_PLATE_INFO struPlateInfo = struITSPlateResult.struPlateInfo;

//            string strLicense = System.Text.Encoding.Default.GetString(struITSPlateResult.struPlateInfo.sLicense);
//            StringBuilder sb = new StringBuilder();
//            strLicense = Regex.Replace(strLicense, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));

//            //MessageBox.Show(strLicense);

//            //车牌报警图片信息展示(License plate alarm picture information display)

//            if (struITSPlateResult.dwPicNum != 0)
//            {
//                int picCount = 0;
//                for (int i = 0; i < struITSPlateResult.dwPicNum; i++)
//                {
//                    if (struITSPlateResult.struPicInfo[i].dwDataLen > 0 && struITSPlateResult.struPicInfo[i].pBuffer != IntPtr.Zero)
//                    {
//                        picCount++;
//                        if (struITSPlateResult.struPicInfo[i].byType == 0)
//                        {
//                            strPicFilePath = strLocalFilePath + "\\TollCaptureLic_" + strLicense+datatimenow + "Pic.jpg";
//                            int iLen = (int)struITSPlateResult.struPicInfo[i].dwDataLen;
//                            byte[] byDataTempBuffer = new byte[iLen];
//                            Marshal.Copy(struITSPlateResult.struPicInfo[i].pBuffer, byDataTempBuffer, 0, iLen);
//                             img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(byDataTempBuffer));
//                            Bitmap bmpImage = new System.Drawing.Bitmap(img);
//                            bmpImage.Save(strPicFilePath);
//                            captureFilepath = strPicFilePath;
//                            //ANPRPicBox.Image = Image.FromFile(strPicFilePath);
//                            img.Dispose();
//                            bmpImage.Dispose();
//                        }
//                        else if (struITSPlateResult.struPicInfo[i].byType == 1)
//                        {
//                            strPicFilePathB = strLocalFilePath + "\\TollCaptureLic_" + strLicense + datatimenow + "DPic.jpg";
//                            int iLen = (int)struITSPlateResult.struPicInfo[i].dwDataLen;
//                            byte[] byDataTempBuffer = new byte[iLen];
//                            Marshal.Copy(struITSPlateResult.struPicInfo[i].pBuffer, byDataTempBuffer, 0, iLen);
//                             img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(byDataTempBuffer));
//                            Bitmap bmpImage = new System.Drawing.Bitmap(img);
//                            bmpImage.Save(strPicFilePathB);
//                            captureFilepath = strPicFilePathB;
//                            //ANPRDPicBox.Image = Image.FromFile(strPicFilePathB);
//                            img.Dispose();
//                            bmpImage.Dispose();
//                        }
//                    }
//                }
//            }
//            onLicenceDetected(strLicense,strPicFilePathB);

//            //车牌报警详细信息展示(License plate alarm detailed information display)
//            /* 
//              string Info = struPlateInfo.pXmlBuf.ToString();
//             String InfoPlateResult = string.Format("ITS Plate Alarm Channel NO[{0}] DriveChan[{1}] IllegalFromatType[{2}] IllegalInfo[{3}] Analysis[{4}] YellowLabel[{5}] DangerousVeh[{6}] MatchNo[{7}] IllegalType[{8}] IllegalSubType[{9}] MonitoringSiteID[{10}] DeviceID[{11}] Dir[{12}] PicNum[{13}] DetSceneID[{14}] VehicleType[{15}] DetectType[{16}]",
//                 struITSPlateResult.byChanIndexEx * 256 + struITSPlateResult.byChanIndex, struITSPlateResult.byDriveChan, struITSPlateResult.byIllegalFromatType, struITSPlateResult.pIllegalInfoBuf,
//                 struITSPlateResult.byDataAnalysis, struITSPlateResult.byYellowLabelCar, struITSPlateResult.byDangerousVehicles, struITSPlateResult.dwMatchNo, struITSPlateResult.wIllegalType,
//                 struITSPlateResult.byIllegalSubType, struITSPlateResult.byMonitoringSiteID, struITSPlateResult.byDeviceID, struITSPlateResult.byDir, struITSPlateResult.dwPicNum, struITSPlateResult.byDetSceneID,
//                 struITSPlateResult.byVehicleType, struITSPlateResult.byDetectType);
//             String InfoPlate = string.Format("", "");
//             if (struPlateInfo.dwXmlLen != 0)
//             {
//                 //ITSPlateInfoTextBox.Text = Info;
//                 MessageBox.Show(Info);
//                 //License plate alarm detailed information storage
//                 strShowDataPath = strLocalFilePath + "\\ANPRListenInfo" + datatimenow + "ShowData.txt";
//                 FileStream fs = new FileStream(strShowDataPath, FileMode.Create);
//                 int iLen = (int)struPlateInfo.dwXmlLen;
//                 byte[] byDataTempBuffer = new byte[iLen];
//                 Marshal.Copy(struPlateInfo.pXmlBuf, byDataTempBuffer, 0, iLen);
//                 fs.Write(byDataTempBuffer, 0, iLen);
//                 fs.Close();
//             }
//             else
//             {
//                 //ITSPlateInfoTextBox.Text = InfoPlateResult;
//                 MessageBox.Show(InfoPlateResult);
//                 //License plate alarm detailed information storage
//                 strShowDataPath = strLocalFilePath + "\\ANPRListenInfo" + datatimenow + "ShowData.txt";
//                 //File.Create(strShowDataPath);
//                 File.WriteAllText(@strShowDataPath, InfoPlateResult);
//             }*/





//        }

//        public void StartListen(string listenIPAddress, int listenPortNo, string userName, string password)
//        {
//            SDK_Listen(listenIPAddress, listenPortNo, userName, password);
//        }
//        public void StartListen(string listenIPAddress, int listenPortNo)
//        {
//            SDK_Listen(listenIPAddress, listenPortNo, "", "");
//        }
//        private void SDK_Listen(string listenIPAddress, int listenPortNo, string userName, string password)
//        {
//           if (m_iListenHandle < 0)
//            {
//                try
//                {
//                    if (m_falarmData == null)
//                    {
//                        m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
//                    }

//                    m_iListenHandle = CHCNetSDK.NET_DVR_StartListen_V30(listenIPAddress, (ushort)listenPortNo, m_falarmData, IntPtr.Zero);

//                    if (m_iListenHandle < 0)
//                    {
//                        int iLastErr = Convert.ToInt32(CHCNetSDK.NET_DVR_GetLastError());
//                        string strErr = "启动监听失败，错误码：" + iLastErr; //启动监听失败，输出错误码
//                        MessageBox.Show("Listening Fail"+"\n"+strErr);
//                    }
//                    else
//                    {
//                        //MainFormHandler.SetStatusString(MainFormHandler.Level.Info, "NET_DVR_StartListen_V30", "启动监听成功！");
//                        MessageBox.Show("Camera start listening successfully！");
//                    }
//                }
//                catch (Exception e)
//                {
//                    MessageBox.Show(e.Message);
//                }

//            }
//        }

//        public void StopListen()
//        {
//            SDK_StopListen();
//        }
//        private void SDK_StopListen()
//        {
//            if (m_iListenHandle >= 0)
//            {
//                if (!CHCNetSDK.NET_DVR_StopListen_V30(m_iListenHandle))
//                {
//                    int iLastErr = Convert.ToInt32(CHCNetSDK.NET_DVR_GetLastError());
//                    string strErr = "停止监听失败，错误码：" + iLastErr; //撤防失败，输出错误码
//                    MessageBox.Show(strErr);
//                }
//                else
//                {
//                    MessageBox.Show("Stop listening successfully！");
//                    m_iListenHandle = -1;
//                }
//            }
//        }
//        public void ArmCamera()
//        {
//            CHCNetSDK.NET_DVR_SETUPALARM_PARAM struAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();

//            struAlarmParam.dwSize = (uint)Marshal.SizeOf(struAlarmParam);

//            struAlarmParam.byLevel = 1; //0- 一级布防,1- 二级布防

//            struAlarmParam.byAlarmInfoType = 1;//智能交通设备有效，新报警信息类型

//            struAlarmParam.byFaceAlarmDetection = 1;//1-人脸侦测

//            Int32 m_lAlarmHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_lUserID, ref struAlarmParam);

//            if (m_lAlarmHandle < 0)

//            {

//                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();

//                string strErr = "Failed to arm, Error code:" + iLastErr; //布防失败，输出错误号

//                // listViewDevice.Items[i].SubItems[2].Text = strErr;              
//                MessageBox.Show("Arm camera fail"+"\n"+strErr);
//            }

//            else

//            {

//                // listViewDevice.Items[i].SubItems[2].Text = "Arm successfully";                     
//                MessageBox.Show("Arm camera successfully");
//            }

//        }
//    }
//    }

using AlarmCSharpDemo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tollgate_Project
{
    public class HikIPCam
    {
        private Int32 m_lUserID = -1;
        private uint iLastErr = 0;
        private Int32 m_lRealHandle = -1;
        private bool m_bInitSDK = false;
        CHCNetSDK.REALDATACALLBACK RealData = null;
        public int m_iChannel = -1;
        public string strLocalFilePath = "";
        private Int32 m_iListenHandle = -1;
        private CHCNetSDK.MSGCallBack_V31 m_falarmData_V31 = null;
        public delegate void OnLicenceDetected(string licence, string captureLicencePath);
        Image img = null;
        public OnLicenceDetected onLicenceDetected;
        private CHCNetSDK.MSGCallBack m_falarmData = null;
        public delegate void UpdateListBoxCallback(string strAlarmTime, string strDevIP, string strAlarmMsg);

        public HikIPCam()
        {

            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //MessageBox.Show("NET_DVR_Init success!");
                CHCNetSDK.NET_DVR_SetValidIP(0, true); //绑定第一张网卡
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
                if (m_falarmData_V31 == null)
                {
                    m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
                }
                CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);

                //Control.CheckForIllegalCrossThreadCalls = false;
            }

        }

        public HikIPCam(string picDirectory, OnLicenceDetected onLicenceDetected)
        {
            this.strLocalFilePath = picDirectory;
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //MessageBox.Show("NET_DVR_Init success!");
                CHCNetSDK.NET_DVR_SetValidIP(0, true); //绑定第一张网卡
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
                if (m_falarmData_V31 == null)
                {
                    m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
                }
                CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);

                //Control.CheckForIllegalCrossThreadCalls = false;
            }

            this.onLicenceDetected = onLicenceDetected;
        }
        public void deleagetTest()
        {
            onLicenceDetected("this is delegate test", "");
        }

        public Boolean LogIn(string ipAddress, Int16 portNo, string userName, string password)
        {
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(ipAddress, portNo, userName, password, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string result = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //µÇÂ¼Ê§°Ü£¬Êä³ö´íÎóºÅ
                MessageBox.Show(result + "\n" + "Please check your Ip camera configuration.");
                return false;
            }
            else
            {
                //µÇÂ¼³É¹¦
                // MessageBox.Show("Login Success!" + m_lUserID);

                return true;
            }
        }
        public bool LogOut()
        {
            if (m_lRealHandle >= 0)
            {
                MessageBox.Show("No camera is logged in.");
                return false;
            }

            if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string result = "NET_DVR_Logout failed, error code= " + iLastErr;
                MessageBox.Show(result);
                return false;
            }
            CHCNetSDK.NET_DVR_Cleanup();
            m_lUserID = -1;
            return true;
        }


        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "ÊµÊ±Á÷Êý¾Ý.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }
        public Boolean StartLiveView(IntPtr pictureBoxHandle)
        {
            try
            {
                if (m_lUserID < 0)
                {
                    //MessageBox.Show("Please login the device firstly");
                    return false;
                }
                if (m_lRealHandle < 0)
                {
                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                    lpPreviewInfo.hPlayWnd = pictureBoxHandle;//Ô¤ÀÀ´°¿Ú
                    lpPreviewInfo.lChannel = 1;//Ô¤teÀÀµÄÉè±¸Í¨µÀ
                    lpPreviewInfo.dwStreamType = 0;//ÂëÁ÷ÀàÐÍ£º0-Ö÷ÂëÁ÷£¬1-×ÓÂëÁ÷£¬2-ÂëÁ÷3£¬3-ÂëÁ÷4£¬ÒÔ´ËÀàÍÆ
                    lpPreviewInfo.dwLinkMode = 0;//Á¬½Ó·½Ê½£º0- TCP·½Ê½£¬1- UDP·½Ê½£¬2- ¶à²¥·½Ê½£¬3- RTP·½Ê½£¬4-RTP/RTSP£¬5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = true; //0- ·Ç×èÈûÈ¡Á÷£¬1- ×èÈûÈ¡Á÷
                    lpPreviewInfo.dwDisplayBufNum = 1; //²¥·Å¿â²¥·Å»º³åÇø×î´ó»º³åÖ¡Êý
                    lpPreviewInfo.byProtoType = 0;
                    lpPreviewInfo.byPreviewMode = 0;

                    if (RealData == null)
                    {
                        RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//Ô¤ÀÀÊµÊ±Á÷»Øµ÷º¯Êý
                    }

                    IntPtr pUser = new IntPtr();//ÓÃ»§Êý¾Ý

                    //´ò¿ªÔ¤ÀÀ Start live view 
                    m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                    if (m_lRealHandle < 0)
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        string result = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //Ô¤ÀÀÊ§°Ü£¬Êä³ö´íÎóºÅ
                        MessageBox.Show(result);
                        return false;
                    }
                    else
                    {
                        //Ô¤ÀÀ³É¹¦
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public Boolean StopLiveView(IntPtr pictureBoxHandle)
        {
            try
            {
                if (!(m_lRealHandle < 0))
                {
                    if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        string result = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                        MessageBox.Show(result);
                        return false;
                    }
                    // else
                    m_lRealHandle = -1;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool SetUpAnpr(string listenIp, int listenPort)
        {
            try
            {

                ArmCamera();
                StartListen(listenIp, listenPort);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        //private IDeviceTree g_deviceTree = PluginsFactory.GetDeviceTreeInstance();
        public bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)

        {



            AlarmMessage(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);



            return true;

        }
        public void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)

        {



            AlarmMessage(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);

        }
        public void AlarmMessage(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            switch (lCommand)
            {
                // License plate recognition alarm upload
                case CHCNetSDK.COMM_UPLOAD_PLATE_RESULT:
                    break;
                case CHCNetSDK.COMM_ITS_PLATE_RESULT:
                    ProcessCommAlarm_ITS(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                default:
                    break;
            }

        }
        private void ProcessCommAlarm_ITS(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {

            //             if (this.InvokeRequired)
            //             {
            //                 ProcessCommAlarm_ITS_Handle handle = new ProcessCommAlarm_ITS_Handle(ProcessCommAlarm_ITS);
            //                 this.BeginInvoke(handle, pAlarmer, pAlarmInfo, dwBufLen, pUser);
            //             }
            //             else
            //             {
            //pAlarmInfo数据异常导致无法解析到正常数据，注释掉if...else...后正常


            //获取当前系统时间
            string datatimenow = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            //车牌图片存储路径
            string strPicFilePath = "";
            //车辆检测图片存储路径
            string strPicFilePathB = "";
            //ANPR展示数据存储路径
            string strShowDataPath = "";
            string captureFilepath = "";
            //报警信息解析
            //IDeviceTree.DeviceInfo deviceInfo = m_deviceTree.GetSelectedDeviceInfo();
            CHCNetSDK.NET_ITS_PLATE_RESULT struITSPlateResult = new CHCNetSDK.NET_ITS_PLATE_RESULT();
            uint dwSize = (uint)Marshal.SizeOf(struITSPlateResult);
            struITSPlateResult = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));
            CHCNetSDK.NET_DVR_PLATE_INFO struPlateInfo = struITSPlateResult.struPlateInfo;

            string strLicense = System.Text.Encoding.Default.GetString(struITSPlateResult.struPlateInfo.sLicense);
            StringBuilder sb = new StringBuilder();
            strLicense = Regex.Replace(strLicense, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));

            //MessageBox.Show(strLicense);

            //车牌报警图片信息展示(License plate alarm picture information display)

            if (struITSPlateResult.dwPicNum != 0)
            {
                int picCount = 0;
                for (int i = 0; i < struITSPlateResult.dwPicNum; i++)
                {
                    if (struITSPlateResult.struPicInfo[i].dwDataLen > 0 && struITSPlateResult.struPicInfo[i].pBuffer != IntPtr.Zero)
                    {
                        picCount++;
                        if (struITSPlateResult.struPicInfo[i].byType == 0)
                        {
                            strPicFilePath = strLocalFilePath + "\\TollCaptureLic_" + strLicense + datatimenow + "Pic.jpg";
                            int iLen = (int)struITSPlateResult.struPicInfo[i].dwDataLen;
                            byte[] byDataTempBuffer = new byte[iLen];
                            Marshal.Copy(struITSPlateResult.struPicInfo[i].pBuffer, byDataTempBuffer, 0, iLen);
                            img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(byDataTempBuffer));
                            Bitmap bmpImage = new System.Drawing.Bitmap(img);
                            bmpImage.Save(strPicFilePath);
                            captureFilepath = strPicFilePath;
                            //ANPRPicBox.Image = Image.FromFile(strPicFilePath);
                            img.Dispose();
                            bmpImage.Dispose();
                        }
                        else if (struITSPlateResult.struPicInfo[i].byType == 1)
                        {
                            strPicFilePathB = strLocalFilePath + "\\TollCaptureLic_" + strLicense + datatimenow + "" + "DPic.jpg";
                            int iLen = (int)struITSPlateResult.struPicInfo[i].dwDataLen;
                            byte[] byDataTempBuffer = new byte[iLen];
                            Marshal.Copy(struITSPlateResult.struPicInfo[i].pBuffer, byDataTempBuffer, 0, iLen);
                            img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(byDataTempBuffer));
                            Bitmap bmpImage = new System.Drawing.Bitmap(img);
                            bmpImage.Save(strPicFilePathB);
                            captureFilepath = strPicFilePathB;
                            //ANPRDPicBox.Image = Image.FromFile(strPicFilePathB);
                            img.Dispose();
                            bmpImage.Dispose();
                        }
                    }
                }
            }
            onLicenceDetected(strLicense, strPicFilePathB);

            //车牌报警详细信息展示(License plate alarm detailed information display)
            /* 
              string Info = struPlateInfo.pXmlBuf.ToString();
             String InfoPlateResult = string.Format("ITS Plate Alarm Channel NO[{0}] DriveChan[{1}] IllegalFromatType[{2}] IllegalInfo[{3}] Analysis[{4}] YellowLabel[{5}] DangerousVeh[{6}] MatchNo[{7}] IllegalType[{8}] IllegalSubType[{9}] MonitoringSiteID[{10}] DeviceID[{11}] Dir[{12}] PicNum[{13}] DetSceneID[{14}] VehicleType[{15}] DetectType[{16}]",
                 struITSPlateResult.byChanIndexEx * 256 + struITSPlateResult.byChanIndex, struITSPlateResult.byDriveChan, struITSPlateResult.byIllegalFromatType, struITSPlateResult.pIllegalInfoBuf,
                 struITSPlateResult.byDataAnalysis, struITSPlateResult.byYellowLabelCar, struITSPlateResult.byDangerousVehicles, struITSPlateResult.dwMatchNo, struITSPlateResult.wIllegalType,
                 struITSPlateResult.byIllegalSubType, struITSPlateResult.byMonitoringSiteID, struITSPlateResult.byDeviceID, struITSPlateResult.byDir, struITSPlateResult.dwPicNum, struITSPlateResult.byDetSceneID,
                 struITSPlateResult.byVehicleType, struITSPlateResult.byDetectType);
             String InfoPlate = string.Format("", "");
             if (struPlateInfo.dwXmlLen != 0)
             {
                 //ITSPlateInfoTextBox.Text = Info;
                 MessageBox.Show(Info);
                 //License plate alarm detailed information storage
                 strShowDataPath = strLocalFilePath + "\\ANPRListenInfo" + datatimenow + "ShowData.txt";
                 FileStream fs = new FileStream(strShowDataPath, FileMode.Create);
                 int iLen = (int)struPlateInfo.dwXmlLen;
                 byte[] byDataTempBuffer = new byte[iLen];
                 Marshal.Copy(struPlateInfo.pXmlBuf, byDataTempBuffer, 0, iLen);
                 fs.Write(byDataTempBuffer, 0, iLen);
                 fs.Close();
             }
             else
             {
                 //ITSPlateInfoTextBox.Text = InfoPlateResult;
                 MessageBox.Show(InfoPlateResult);
                 //License plate alarm detailed information storage
                 strShowDataPath = strLocalFilePath + "\\ANPRListenInfo" + datatimenow + "ShowData.txt";
                 //File.Create(strShowDataPath);
                 File.WriteAllText(@strShowDataPath, InfoPlateResult);
             }*/





        }

        public void StartListen(string listenIPAddress, int listenPortNo, string userName, string password)
        {
            SDK_Listen(listenIPAddress, listenPortNo, userName, password);
        }
        public void StartListen(string listenIPAddress, int listenPortNo)
        {
            SDK_Listen(listenIPAddress, listenPortNo, "", "");
        }
        private void SDK_Listen(string listenIPAddress, int listenPortNo, string userName, string password)
        {
            if (m_iListenHandle < 0)
            {
                try
                {
                    if (m_falarmData == null)
                    {
                        m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
                    }

                    m_iListenHandle = CHCNetSDK.NET_DVR_StartListen_V30(listenIPAddress, (ushort)listenPortNo, m_falarmData, IntPtr.Zero);

                    if (m_iListenHandle < 0)
                    {
                        int iLastErr = Convert.ToInt32(CHCNetSDK.NET_DVR_GetLastError());
                        string strErr = "启动监听失败，错误码：" + iLastErr; //启动监听失败，输出错误码
                        MessageBox.Show("Listening Fail" + "\n" + strErr);
                    }
                    else
                    {
                        //MainFormHandler.SetStatusString(MainFormHandler.Level.Info, "NET_DVR_StartListen_V30", "启动监听成功！");
                         MessageBox.Show("Camera start listening successfully！");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }

        public void StopListen()
        {
            SDK_StopListen();
        }
        private void SDK_StopListen()
        {
            if (m_iListenHandle >= 0)
            {
                if (!CHCNetSDK.NET_DVR_StopListen_V30(m_iListenHandle))
                {
                    int iLastErr = Convert.ToInt32(CHCNetSDK.NET_DVR_GetLastError());
                    string strErr = "停止监听失败，错误码：" + iLastErr; //撤防失败，输出错误码
                    MessageBox.Show(strErr);
                }
                else
                {
                    // MessageBox.Show("Stop listening successfully！");
                    m_iListenHandle = -1;
                }
            }
        }
        public void ArmCamera()
        {
            CHCNetSDK.NET_DVR_SETUPALARM_PARAM struAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();

            struAlarmParam.dwSize = (uint)Marshal.SizeOf(struAlarmParam);

            struAlarmParam.byLevel = 1; //0- 一级布防,1- 二级布防

            struAlarmParam.byAlarmInfoType = 1;//智能交通设备有效，新报警信息类型

            struAlarmParam.byFaceAlarmDetection = 1;//1-人脸侦测

            Int32 m_lAlarmHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_lUserID, ref struAlarmParam);

            if (m_lAlarmHandle < 0)

            {

                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();

                string strErr = "Failed to arm, Error code:" + iLastErr; //布防失败，输出错误号

                // listViewDevice.Items[i].SubItems[2].Text = strErr;              
                MessageBox.Show("Arm camera fail" + "\n" + strErr);
            }

            else

            {

                // listViewDevice.Items[i].SubItems[2].Text = "Arm successfully";                     
                // MessageBox.Show("Arm camera successfully");
            }

        }
        public void Dispose()
        {
            this.Dispose();
        }
    }
}

