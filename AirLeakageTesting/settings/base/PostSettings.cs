using System;
using System.Linq;

namespace AirLeakageTesting.settings
{
    /// <summary>
    /// 串口通用设置基类
    /// </summary>
    [Serializable()]
    public abstract class PostSettings
    {
        /// <summary>
        /// 当前串口号
        /// </summary> 
        private string serialport = (System.IO.Ports.SerialPort.GetPortNames().Count()>0)? System.IO.Ports.SerialPort.GetPortNames()[0]:null;
        public string SerialPort
        {
            get
            {
                return serialport;
            }
            set
            {
                serialport = value;
            }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        private string baudrate = "115200";
        public string BaudRate
        {
            get
            {
                return baudrate;
            }
            set
            {
                baudrate = value;
            }
        }

        /// <summary>
        /// 数据位
        /// </summary>
        private string databit = "8";
        public string DataBit
        {
            get
            {
                return databit;
            }
            set
            {
                databit = value;
            }
        }

        /// <summary>
        /// 奇偶校验
        /// </summary>
        private string paritycheck = "无校验";
        public string ParityCheck
        {
            get
            {
                return paritycheck;
            }
            set
            {
                paritycheck = value;
            }
        }

        /// <summary>
        /// 停止位
        /// </summary>
        private string stopbit = "1停止位";
        public string StopBit
        {
            get
            {
                return stopbit;
            }
            set
            {
                stopbit = value;
            }
        }
    }
}
