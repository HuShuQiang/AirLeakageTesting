using AirLeakageTesting.imp;
using AirLeakageTesting.settings;
using AirLeakageTesting.utils;
using System.IO.Ports;
using System.Windows.Forms;

namespace AirLeakageTesting
{
    public partial class FormSerialPortSettings : Form
    {
        public FormSerialPortSettings()
        {
            //窗体居中显示
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        /// <summary>
        /// 串口设置保存配置之后的回调
        /// </summary>
        private SaveSerialPortSettingsCallBack saveSerialPortSettingsCall;
        public void SaveSerialPortCallBack(SaveSerialPortSettingsCallBack saveSerialPortSettingsCall)
        {
            this.saveSerialPortSettingsCall = saveSerialPortSettingsCall;
        }

        private SerializationFileType type;
        private PostSettings postSettings;

        public void Init(SerializationFileType type, PostSettings postSettings)
        {
            this.type = type;
            this.postSettings = postSettings;
            InitUI();
        }
        private void InitUI()
        {

            //设置串口号序号
            if (type == SerializationFileType.SerialPort1)
            {
                label_serialPort.Text = "第1通道串口号";
            }
            else if (type == SerializationFileType.SerialPort2)
            {
                label_serialPort.Text = "第2通道串口号";
            }
            else if (type == SerializationFileType.SerialPort3)
            {
                label_serialPort.Text = "第3通道串口号";
            }
            else if (type == SerializationFileType.SerialPort4)
            {
                label_serialPort.Text = "第4通道串口号";
            }

            // 获取所有可用的串口
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox_serialPort.Items.Add(port);
            }

            comboBox_serialPort.SelectedIndex = -1;

            // 设置波特率
            comboBox_BaudRate.Items.Add("9600");
            comboBox_BaudRate.Items.Add("38400");
            comboBox_BaudRate.Items.Add("115200");

            comboBox_BaudRate.SelectedIndex = 2;

            // 设置数据位  参数必须介于 5 和 8 之间
            comboBox_DataBit.Items.Add("5");
            comboBox_DataBit.Items.Add("6");
            comboBox_DataBit.Items.Add("7");
            comboBox_DataBit.Items.Add("8");

            comboBox_DataBit.SelectedIndex = 3;

            // 设置奇偶校验
            comboBox_ParityCheck.Items.Add("偶校验");
            comboBox_ParityCheck.Items.Add("奇校验");
            comboBox_ParityCheck.Items.Add("标记校验");
            comboBox_ParityCheck.Items.Add("无校验");
            comboBox_ParityCheck.Items.Add("禁止校验");

            comboBox_ParityCheck.SelectedIndex = 3;

            // 设置停止位
            comboBox_StopBit.Items.Add("1停止位");
            comboBox_StopBit.Items.Add("1.5停止位");
            comboBox_StopBit.Items.Add("2停止位");

            comboBox_StopBit.SelectedIndex = 0;


            if (this.postSettings != null)
            {
                comboBox_serialPort.Text = postSettings.SerialPort;
                comboBox_BaudRate.Text = postSettings.BaudRate;
                comboBox_DataBit.Text = postSettings.DataBit;
                comboBox_ParityCheck.Text = postSettings.ParityCheck;
                comboBox_StopBit.Text = postSettings.StopBit;
            }


        }

        private void button_ok_Click(object sender, System.EventArgs e)
        {
            if (type == SerializationFileType.SerialPort1)
            {
                SerialPort1Paramas serialPort1 = (SerialPort1Paramas)this.postSettings;
                serialPort1.SerialPort = comboBox_serialPort.Text;
                serialPort1.BaudRate = comboBox_BaudRate.Text;
                serialPort1.DataBit = comboBox_DataBit.Text;
                serialPort1.ParityCheck = comboBox_ParityCheck.Text;
                serialPort1.StopBit = comboBox_StopBit.Text;
                this.saveSerialPortSettingsCall.updateSerialPortConfig(type, serialPort1);
                FileUitls.SaveConfig(serialPort1);
            }
            else if (type == SerializationFileType.SerialPort2)
            {
                SerialPort2Paramas serialPort2 = (SerialPort2Paramas)this.postSettings;
                serialPort2.SerialPort = comboBox_serialPort.Text;
                serialPort2.BaudRate = comboBox_BaudRate.Text;
                serialPort2.DataBit = comboBox_DataBit.Text;
                serialPort2.ParityCheck = comboBox_ParityCheck.Text;
                serialPort2.StopBit = comboBox_StopBit.Text;
                this.saveSerialPortSettingsCall.updateSerialPortConfig(type, serialPort2);
                FileUitls.SaveConfig(serialPort2);
            }
            else if (type == SerializationFileType.SerialPort3)
            {
                SerialPort3Paramas serialPort3 = (SerialPort3Paramas)this.postSettings;
                serialPort3.SerialPort = comboBox_serialPort.Text;
                serialPort3.BaudRate = comboBox_BaudRate.Text;
                serialPort3.DataBit = comboBox_DataBit.Text;
                serialPort3.ParityCheck = comboBox_ParityCheck.Text;
                serialPort3.StopBit = comboBox_StopBit.Text;
                this.saveSerialPortSettingsCall.updateSerialPortConfig(type, serialPort3);
                FileUitls.SaveConfig(serialPort3);
            }
            else if (type == SerializationFileType.SerialPort4)
            {
                SerialPort4Paramas serialPort4 = (SerialPort4Paramas)this.postSettings;
                serialPort4.SerialPort = comboBox_serialPort.Text;
                serialPort4.BaudRate = comboBox_BaudRate.Text;
                serialPort4.DataBit = comboBox_DataBit.Text;
                serialPort4.ParityCheck = comboBox_ParityCheck.Text;
                serialPort4.StopBit = comboBox_StopBit.Text;
                this.saveSerialPortSettingsCall.updateSerialPortConfig(type, serialPort4);
                FileUitls.SaveConfig(serialPort4);
            }


            this.Close();
        }
    }
}
