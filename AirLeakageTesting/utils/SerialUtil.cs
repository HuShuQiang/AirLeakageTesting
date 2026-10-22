using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using AirLeakageTesting.settings;

namespace AirLeakageTesting.uitls
{
    /// <summary>
    /// 串口连接功能类
    /// </summary>
    public abstract class SerialUtil
    {
        /// <summary>
        /// 标记串口是否正在收发数据
        /// </summary>
        public bool IsReceiverData = false;

        private SerialPort ComPortHandler = new SerialPort();

        private PostSettings postSettings;

        public void Init(PostSettings postSettings)
        {
            this.postSettings = postSettings;
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void CloseSerial()
        {
            try
            {
                if (ComPortHandler == null)
                {
                    return;
                }

                IsReceiverData = false;
                if (ComPortHandler.IsOpen)
                {
                    ComPortHandler.Close();
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("关闭串口异常：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("关闭串口异常：" + ex.StackTrace + ",msg=" + ex.Message);
            }
        }

        public bool SerialIsOpen()
        {
            if (ComPortHandler == null)
            {
                return false;
            }
            return ComPortHandler.IsOpen;
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        public bool OpenSerial()
        {
            try
            {
                string portNameTmp = postSettings.SerialPort;
                string BaudRateTmp = postSettings.BaudRate;
                string DataBitsTmp = postSettings.DataBit;
                string StopBitsTmp = postSettings.StopBit;
                string ParityTmp = postSettings.ParityCheck;

                if (portNameTmp == null || portNameTmp == "")
                {
                    Trace.WriteLine("请先选择串口！");
                    return false;
                }

                //格式化停止位
                if (StopBitsTmp.Equals("1停止位"))
                {
                    StopBitsTmp = "1";
                }
                else if (StopBitsTmp.Equals("1.5停止位"))
                {
                    StopBitsTmp = "3";
                }
                else if (StopBitsTmp.Equals("2停止位"))
                {
                    StopBitsTmp = "2";
                }

                //格式化奇偶校验
                if (ParityTmp.Equals("偶校验"))
                {
                    ParityTmp = "2";
                }
                else if (ParityTmp.Equals("奇校验"))
                {
                    ParityTmp = "1";
                }
                else if (ParityTmp.Equals("标记校验"))
                {
                    ParityTmp = "3";
                }
                else if (ParityTmp.Equals("无校验"))
                {
                    ParityTmp = "0";
                }
                else if (ParityTmp.Equals("禁止校验"))
                {
                    ParityTmp = "4";
                }

                if (ComPortHandler == null)
                {
                    Trace.WriteLine("串口实例为空！重新实例化！");
                    FormMain.myLog.Info("串口实例为空！重新实例化！");
                    ComPortHandler = new SerialPort();
                }

                if (!ComPortHandler.IsOpen)
                {
                    ComPortHandler.PortName = Convert.ToString(portNameTmp);
                    ComPortHandler.BaudRate = Convert.ToInt32(BaudRateTmp);
                    ComPortHandler.DataBits = Convert.ToInt16(DataBitsTmp);
                    ComPortHandler.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBitsTmp);
                    ComPortHandler.Parity = (Parity)Enum.Parse(typeof(Parity), ParityTmp);
                    ComPortHandler.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "0");

                    ComPortHandler.Open();

                    return true;
                }
                else
                {
                    Trace.WriteLine("端口：" + portNameTmp + " 已打开");
                    FormMain.myLog.Info("端口：" + portNameTmp + " 已打开");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("打开串口异常：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("打开串口异常：" + ex.StackTrace + ",msg=" + ex.Message);
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private int count = 0;
        /// <summary>
        /// 串口发送数据
        /// <param name="cmd">发送的字符串</param>
        public string Send(string cmd)
        {
            string result = null;
            try
            {
                if (ComPortHandler != null && ComPortHandler.IsOpen)
                {
                    byte[] cmdByte = ConvertUtils.HexStringToBytes(cmd);
                    ComPortHandler.Write(cmdByte, 0, cmdByte.Length);
                    count = 0;
                    while (ComPortHandler.BytesToRead == 0)
                    {
                        //1秒超时，自动退出
                        if (count >= 1000) break;
                        Thread.Sleep(100);
                        count += 100;
                    }
                    string serialPortData = "";
                    int bytesRead = ComPortHandler.BytesToRead;
                    if (bytesRead == 0) return result;
                    //Trace.WriteLine("Received BytesRead:" + bytesRead);
                    //FormMain.myLog.Info("Received BytesRead:" + bytesRead);
                    byte[] buf = new byte[bytesRead];
                    ComPortHandler.Read(buf, 0, bytesRead);
                    for (int i = 0; i < bytesRead; i++)
                    {
                        serialPortData += buf[i].ToString("X").PadLeft(2, '0') + " ";
                        IsReceiverData = true;
                    }
                    //Trace.WriteLine("Received Data:" + serialPortData);
                    //FormMain.myLog.Info("Received Data:" + serialPortData);
                    result = serialPortData;
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("异常：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("异常：" + ex.StackTrace + ",msg=" + ex.Message);
                return result;
            }

            //return result;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _startDT = DateTime.Now;
        public DateTime StartDT
        {
            get
            {
                return _startDT;
            }
            set
            {
                _startDT = value;
            }
        }
        /// <summary>
        /// 获取总共测试用时/秒
        /// </summary>
        /// <returns></returns>
        public double GetTestElapsed()
        {
            try
            {
                DateTime afterDT = DateTime.Now;
                TimeSpan ts = afterDT.Subtract(_startDT);
                double elapsed = Convert.ToInt32(Convert.ToDouble(ts.TotalMilliseconds.ToString()));
                return elapsed / 1000;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info(ex.StackTrace + ",msg=" + ex.Message);
            }
            return 0;
        }
    }
}
