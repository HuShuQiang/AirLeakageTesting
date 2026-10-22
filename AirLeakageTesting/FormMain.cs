using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AirLeakageTesting.action;
using AirLeakageTesting.imp;
using AirLeakageTesting.settings;
using AirLeakageTesting.utils;

namespace AirLeakageTesting
{
    public partial class FormMain : Form, SettingsCallBack, CountPassNgNumbersCallBack, InputOnkeyDownCallBack
    {

        //这里的 loginfo 和 log4net.config 里的名字要一样
        public static log4net.ILog myLog = log4net.LogManager.GetLogger("loginfo");

        #region 保存一些设置项
        /// <summary>
        /// 保存全局设置项 到本地 二进制文件
        /// </summary>
        /// 
        public static string SaveGlobalSettingsPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar
                                           + "configSettings" + Path.DirectorySeparatorChar
                                          + "GlobalSettings.bin";

        /// <summary>
        /// 保存串口1设置项
        /// </summary>
        /// 
        public static string SaveSerialPort1SettingsPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar
                                           + "configSettings" + Path.DirectorySeparatorChar
                                          + "SerialPort1Settings.bin";

        /// <summary>
        /// 保存串口2设置项
        /// </summary>
        /// 
        public static string SaveSerialPort2SettingsPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar
                                           + "configSettings" + Path.DirectorySeparatorChar
                                          + "SerialPort2Settings.bin";

        /// <summary>
        /// 保存串口3设置项
        /// </summary>
        /// 
        public static string SaveSerialPort3SettingsPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar
                                           + "configSettings" + Path.DirectorySeparatorChar
                                          + "SerialPort3Settings.bin";

        /// <summary>
        /// 保存串口4设置项
        /// </summary>
        /// 
        public static string SaveSerialPort4SettingsPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar
                                           + "configSettings" + Path.DirectorySeparatorChar
                                          + "SerialPort4Settings.bin";

        #endregion

        #region 具体测试操作实例
        /// <summary>
        /// 各个串口UI处理封装
        /// </summary>
        private Panel1Action panel1Action = new Panel1Action();
        private Panel2Action panel2Action = new Panel2Action();
        private Panel3Action panel3Action = new Panel3Action();
        private Panel4Action panel4Action = new Panel4Action();

        /// <summary>
        /// 各个串口参数设置
        /// </summary>
        private SerialPort1Paramas serialPort1Paramas = new SerialPort1Paramas();
        private SerialPort2Paramas serialPort2Paramas = new SerialPort2Paramas();
        private SerialPort3Paramas serialPort3Paramas = new SerialPort3Paramas();
        private SerialPort4Paramas serialPort4Paramas = new SerialPort4Paramas();

        /// <summary>
        /// 串口打开/关闭 操作类
        /// </summary>
        private SerialPort1Utils serialPort1Utils = new SerialPort1Utils();
        private SerialPort2Utils serialPort2Utils = new SerialPort2Utils();
        private SerialPort3Utils serialPort3Utils = new SerialPort3Utils();
        private SerialPort4Utils serialPort4Utils = new SerialPort4Utils();

        #endregion


        /// <summary>
        /// 全局设置变量保存
        /// </summary>
        public static GlobalSettings globalSettings;

        public FormMain()
        {
            //窗体居中显示
            this.StartPosition = FormStartPosition.CenterScreen;


            InitializeComponent();

            InitUIByConfigFile();

            InitSerialPorts();

            this.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Timer2ClearMem();
        }
        /// <summary>
        /// 根据之前的本地配置（如果存在） 更新UI
        /// </summary>
        private void InitUIByConfigFile()
        {
            if (!Directory.Exists(Path.GetDirectoryName(SaveGlobalSettingsPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SaveGlobalSettingsPath));
            }

            //串口配置
            SerialPort1Paramas serialPort1Paramas = FileUitls.GetConfig(SerializationFileType.SerialPort1) as SerialPort1Paramas;
            if (serialPort1Paramas != null)
            {
                this.serialPort1Paramas = serialPort1Paramas;
            }
            SerialPort2Paramas serialPort2Paramas = FileUitls.GetConfig(SerializationFileType.SerialPort2) as SerialPort2Paramas;
            if (serialPort2Paramas != null)
            {
                this.serialPort2Paramas = serialPort2Paramas;
            }
            SerialPort3Paramas serialPort3Paramas = FileUitls.GetConfig(SerializationFileType.SerialPort3) as SerialPort3Paramas;
            if (serialPort3Paramas != null)
            {
                this.serialPort3Paramas = serialPort3Paramas;
            }
            SerialPort4Paramas serialPort4Paramas = FileUitls.GetConfig(SerializationFileType.SerialPort4) as SerialPort4Paramas;
            if (serialPort4Paramas != null)
            {
                this.serialPort4Paramas = serialPort4Paramas;
            }

            //全局配置
            globalSettings = FileUitls.GetConfig(SerializationFileType.Global) as GlobalSettings;
            if (globalSettings != null)
            {
                updateConfig(globalSettings);
            }
            else
            {
                panel_title.Visible = false;
                label_sampleIndex.Visible = false;
                panel_serial1.Visible = false;
                panel_serial2.Visible = false;
                panel_serial3.Visible = false;
                panel_serial4.Visible = false;
            }
        }
        /// <summary>
        /// 初始化串口配置
        /// </summary>
        private void InitSerialPorts()
        {
            this.serialPort1Utils.Init(serialPort1Paramas);
            panel1Action.Init(this.panel_serial1, this.serialPort1Utils, this.serialPort1Paramas);
            panel1Action.SetCountPassNgNumbersCallBack(this);
            panel1Action.SetOnKeyDownCallBack(this);

            this.serialPort2Utils.Init(serialPort2Paramas);
            panel2Action.Init(this.panel_serial2, this.serialPort2Utils, this.serialPort2Paramas);
            panel2Action.SetCountPassNgNumbersCallBack(this);
            panel2Action.SetOnKeyDownCallBack(this);

            this.serialPort3Utils.Init(serialPort3Paramas);
            panel3Action.Init(this.panel_serial3, this.serialPort3Utils, this.serialPort3Paramas);
            panel3Action.SetCountPassNgNumbersCallBack(this);
            panel3Action.SetOnKeyDownCallBack(this);

            this.serialPort4Utils.Init(serialPort4Paramas);
            panel4Action.Init(this.panel_serial4, this.serialPort4Utils, this.serialPort4Paramas);
            panel4Action.SetCountPassNgNumbersCallBack(this);
            panel4Action.SetOnKeyDownCallBack(this);
        }

        private void ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ////需要进行全局设置之前，先终止测试，是否资源，然后关闭所有串口
            Panel1Action.ReleaseResource();
            Panel2Action.ReleaseResource();
            Panel3Action.ReleaseResource();
            Panel4Action.ReleaseResource();

            this.serialPort1Utils.CloseSerial();
            button_serial1_open.Text = "打开串口";

            this.serialPort2Utils.CloseSerial();
            button_serial2_open.Text = "打开串口";

            this.serialPort3Utils.CloseSerial();
            button_serial3_open.Text = "打开串口";

            this.serialPort4Utils.CloseSerial();
            button_serial4_open.Text = "打开串口";

            FormGlobalSettings globalSettingsForm = new FormGlobalSettings();
            globalSettingsForm.SetSettingsCallB(this);
            globalSettingsForm.ShowDialog();
            //每次更新全局设置之后，都让第一通道获取焦点
            textBox_serial1_inputSn.Focus();
        }

        public void updateConfig(GlobalSettings globalSet)
        {
            globalSettings = globalSet;
            //显示UI
            panel_title.Visible = true;
            label_sampleIndex.Visible = true;
            panel_serial1.Visible = true;
            panel_serial2.Visible = true;
            panel_serial3.Visible = true;
            panel_serial4.Visible = true;

            //重置每个测试通道的UI
            if (panel1Action.IsInit)
            {
                panel1Action.ResetUI();
                textBox_serial1_inputSn.Text = "";
            }
            if (panel2Action.IsInit)
            {
                panel2Action.ResetUI();
                textBox_serial2_inputSn.Text = "";
            }
            if (panel3Action.IsInit)
            {
                panel3Action.ResetUI();
                textBox_serial3_inputSn.Text = "";
            }
            if (panel4Action.IsInit)
            {
                panel4Action.ResetUI();
                textBox_serial4_inputSn.Text = "";
            }

            //标题
            label_productionModel.Text = globalSettings.Model;
            label_stationName.Text = globalSettings.StationName;

            //样本指标更新
            label_sampleIndex.Text = "样本指标:" +
                "进气压力" + globalSettings.PressureValue + "Kpa," +
                 "上限" + globalSettings.PressureValueUp + "Kpa," +
                 "下限" + globalSettings.PressureValueDown + "Kpa," +
                "泄漏上限" + globalSettings.LeakAgeValueUP + "Kpa," +
                //"泄漏下限" + globalSettings.LeakAgeValueDown + "Kpa," +
                "充气时间 " + globalSettings.ChongQiTime + "," +
                "稳压时间 " + globalSettings.WenYaTime + "," +
                "测试时间 " + globalSettings.TestingTime;

            //通道数更新
            channels = globalSettings.ChannnelNumber;

            // 更新合格数量
            label_totalPassNumbers.Text = globalSettings.TotalPassNums + "";
            // 更新失败数量
            label_totalNGNumbers.Text = globalSettings.TotalFailNums + "";

            if (channels == 1)
            {
                panel_serial1.Location = new Point(567, 165);

                panel_serial1.Visible = true;
                panel_serial2.Visible = false;
                panel_serial3.Visible = false;
                panel_serial4.Visible = false;


            }
            else if (channels == 2)
            {
                panel_serial1.Location = new Point(365, 165);
                panel_serial2.Location = new Point(763, 165);

                panel_serial1.Visible = true;
                panel_serial2.Visible = true;
                panel_serial3.Visible = false;
                panel_serial4.Visible = false;
            }
            else if (channels == 3)
            {
                panel_serial1.Location = new Point(215, 165);
                panel_serial2.Location = new Point(560, 165);
                panel_serial3.Location = new Point(910, 165);

                panel_serial1.Visible = true;
                panel_serial2.Visible = true;
                panel_serial3.Visible = true;
                panel_serial4.Visible = false;
            }
            else if (channels == 4)
            {
                panel_serial1.Location = new Point(114, 165);
                panel_serial2.Location = new Point(414, 165);
                panel_serial3.Location = new Point(710, 165);
                panel_serial4.Location = new Point(1006, 165);

                panel_serial1.Visible = true;
                panel_serial2.Visible = true;
                panel_serial3.Visible = true;
                panel_serial4.Visible = true;
            }
        }

        private void panel_title_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel_title.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }
        private void OnResize(object sender, EventArgs e)
        {
            // 禁止窗体最大化
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void load(object sender, EventArgs e)
        {
            //让textbox获取焦点
            this.ActiveControl = this.textBox_serial1_inputSn;
        }

        public void updatePassNumbers(int passNum)
        {
            globalSettings.TotalPassNums += passNum;
            InvokeHelper.Set(label_totalPassNumbers, "Text", globalSettings.TotalPassNums + "");
            FileUitls.SaveConfig(globalSettings);
        }

        public void updateFailNumbers(int failNum)
        {
            globalSettings.TotalFailNums += failNum;
            InvokeHelper.Set(label_totalNGNumbers, "Text", globalSettings.TotalFailNums + "");
            FileUitls.SaveConfig(globalSettings);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsAppExit = true;
            try
            {
                Panel1Action.ReleaseResource();
                Panel2Action.ReleaseResource();
                Panel3Action.ReleaseResource();
                Panel4Action.ReleaseResource();

                this.Dispose();
                GC.Collect();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 记录当前是几个测试通道
        /// </summary>
        private int channels = 0;

        public void OnKeyDown()
        {
            switch (channels)
            {
                case 1:
                    panel_serial1.Focus();
                    break;
                case 2:
                    if (textBox_serial1_inputSn.Enabled)
                    {
                        textBox_serial1_inputSn.Focus();
                    }
                    else if (textBox_serial2_inputSn.Enabled)
                    {
                        textBox_serial2_inputSn.Focus();
                    }
                    else
                    {
                        panel_serial1.Focus();
                    }
                    break;
                case 3:
                    if (textBox_serial1_inputSn.Enabled)
                    {
                        textBox_serial1_inputSn.Focus();
                    }
                    else if (textBox_serial2_inputSn.Enabled)
                    {
                        textBox_serial2_inputSn.Focus();
                    }
                    else if (textBox_serial3_inputSn.Enabled)
                    {
                        textBox_serial3_inputSn.Focus();
                    }
                    else
                    {
                        panel_serial1.Focus();
                    }
                    break;
                case 4:
                    if (textBox_serial1_inputSn.Enabled)
                    {
                        textBox_serial1_inputSn.Focus();
                    }
                    else if (textBox_serial2_inputSn.Enabled)
                    {
                        textBox_serial2_inputSn.Focus();
                    }
                    else if (textBox_serial3_inputSn.Enabled)
                    {
                        textBox_serial3_inputSn.Focus();
                    }
                    else if (textBox_serial4_inputSn.Enabled)
                    {
                        textBox_serial4_inputSn.Focus();
                    }
                    else
                    {
                        panel_serial1.Focus();
                    }
                    break;
            }
        }

        private bool IsAppExit = false;
        /// <summary>
        /// 定时去清除一下内存，避免长时间运行，内存过高
        /// </summary>
        private void Timer2ClearMem()
        {
            BackgroundWorker mWorker = new BackgroundWorker();
            mWorker.DoWork += MWorker_DoWork;
            mWorker.WorkerSupportsCancellation = true;
            mWorker.RunWorkerAsync();
        }

        private void MWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsAppExit = false;
            while (!IsAppExit)
            {
                CommonUtils.GetInstance().ClearMemory();
                //每5分钟执行一遍
                Thread.Sleep(1000 * 60 * 5);
            }
        }
    }
}
