using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using AirLeakageTesting.config;
using AirLeakageTesting.imp;
using AirLeakageTesting.settings;
using AirLeakageTesting.uitls;
using AirLeakageTesting.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirLeakageTesting.action
{
    /// <summary>
    /// 串口4 面板的操作
    /// </summary>
    class Panel4Action : SaveSerialPortSettingsCallBack
    {
        public bool IsInit = false;
        private InputOnkeyDownCallBack onkeyDownCallBack;
        private Panel panel;
        private ComboBox comboBoxSerialName;
        private static TextBox textBoxSerialInputSn;
        private ProgressBar progressBarSerial;
        private static Button buttonSerialSetting, buttonSerialOpen;
        private Label labelSerialProgress, labelSerialTips, labelSerialTestStatus,
                             labelSerialTestTime, labelSerialFails, labelSerialTestPressure,
                             labelSerialLeakageRate, labelSerialTestResult, labelSerialUploadResult,
                             labelSerialDeviationPressure, labelSerialAirLeakAgeValue, labelSerialDeviationLeakAge;

        public void SetOnKeyDownCallBack(InputOnkeyDownCallBack callBack)
        {
            this.onkeyDownCallBack = callBack;
        }

        /// <summary>
        /// 串口设置窗体
        /// </summary>
        private FormSerialPortSettings formSerialPortSettings = new FormSerialPortSettings();
        /// <summary>
        /// 串口打开/关闭 操作类
        /// </summary>
        private static SerialPort4Utils serialPort4Utils;
        /// <summary>
        /// 测试进度线程和计时线程
        /// </summary>
        private static Thread threadGetStatus, threadProgress, threadCountTime;

        private CountPassNgNumbersCallBack numbersCallBack;
        public void SetCountPassNgNumbersCallBack(CountPassNgNumbersCallBack callBack)
        {
            this.numbersCallBack = callBack;
        }

        public void Init(Panel panel, SerialPort4Utils serialPort4U, SerialPort4Paramas serialPort4P)
        {
            this.panel = panel;
            //容器的边框
            panel.Paint += new PaintEventHandler(panelPaint);

            serialPort4Utils = serialPort4U;

            formSerialPortSettings.SaveSerialPortCallBack(this);
            formSerialPortSettings.Init(SerializationFileType.SerialPort4, serialPort4P);

            //串口端口显示
            comboBoxSerialName = (ComboBox)panel.Controls["comboBox_serial4"];
            comboBoxSerialName.Text = serialPort4P.SerialPort;
            comboBoxSerialName.Enabled = false;

            // 串口设置 按钮
            buttonSerialSetting = (Button)panel.Controls["button_serial4_setting"];
            buttonSerialSetting.Click += new EventHandler(this.buttonSerialSettingClick);

            //打开、关闭串口 按钮
            buttonSerialOpen = (Button)panel.Controls["button_serial4_open"];
            buttonSerialOpen.Click += new EventHandler(buttonSerialOpenClick);

            // 扫描输入
            textBoxSerialInputSn = (TextBox)panel.Controls["textBox_serial4_inputSn"];
            textBoxSerialInputSn.KeyDown += new KeyEventHandler(onKeyDown);

            //进度条
            progressBarSerial = (ProgressBar)panel.Controls["progressBar_serial4"];
            progressBarSerial.Value = 0;

            //当前的测试进度状态
            labelSerialProgress = (Label)panel.Controls["label_serial4_progress"];
            labelSerialProgress.Text = "";

            //当前测试状态
            labelSerialTestStatus = (Label)panel.Controls["label_serial4_testStatus"];
            labelSerialTestStatus.Text = "";

            //测试时间
            labelSerialTestTime = (Label)panel.Controls["label_serial4_testTime"];
            labelSerialTestTime.Text = "";

            //失败数量
            labelSerialFails = (Label)panel.Controls["label_serial4_fials"];
            labelSerialFails.Text = "0";

            //测试压力
            labelSerialTestPressure = (Label)panel.Controls["label_serial4_testPressure"];
            labelSerialTestPressure.Text = "";

            //偏差
            labelSerialDeviationPressure = (Label)panel.Controls["label_serial4_deviationPressure"];
            labelSerialDeviationPressure.Text = "";

            //漏气值
            labelSerialAirLeakAgeValue = (Label)panel.Controls["label_serial4_airLeakAgeValue"];
            labelSerialAirLeakAgeValue.Text = "";

            //漏气偏差
            labelSerialDeviationLeakAge = (Label)panel.Controls["label_serial4_deviationLeakAge"];
            labelSerialDeviationLeakAge.Text = "";

            //泄漏速率
            labelSerialLeakageRate = (Label)panel.Controls["label_serial4_leakageRate"];
            labelSerialLeakageRate.Text = "";

            //检测结果
            labelSerialTestResult = (Label)panel.Controls["label_serial4_testResult"];
            labelSerialTestResult.Text = "";

            //检测结果
            labelSerialUploadResult = (Label)panel.Controls["label_serial4_uploadResult"];
            labelSerialUploadResult.Text = "";

            //底部测试状态提示
            labelSerialTips = (Label)panel.Controls["label_serial4_tips"];
            labelSerialTips.Text = "";

            IsInit = true;
        }

        private void panelPaint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private string inputSn = string.Empty;
        private static EntryBean _mEntryBean = new EntryBean();

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tempSN = textBoxSerialInputSn.Text;
                if (string.IsNullOrEmpty(tempSN))
                {
                    MessageBox.Show("Sn不能为空！");
                    return;
                }

                if (IsRunning)
                {
                    return;
                }

                inputSn = tempSN;

                Hashtable hashtable = new Hashtable();
                hashtable.Add("model", FormMain.globalSettings.Model);
                //hashtable.Add("dut_number_name", FormMain.globalSettings.InputNumber);
                //hashtable.Add("dut_number_value", tempSN);

                //HSQ-2024.1.8
                Regex regex = new Regex("\\w+\\(\\w+\\)");
                if (regex.IsMatch(FormMain.globalSettings.InputNumber))
                {
                    Regex num = new Regex("\\(\\w+\\)");
                    Match match = num.Match(FormMain.globalSettings.InputNumber);
                    string value = match.Value.TrimStart('(').TrimEnd(')');
                    hashtable.Add("dut_number_name", value);

                    if (value == "wifi_mac")
                    {
                        Regex regex1 = new Regex("([0-9A-Fa-f]{2}[:-]?){5}([0-9A-Fa-f]{2})");
                        Match match1 = regex1.Match(tempSN);
                        tempSN = match1.Value;
                    }
                    hashtable.Add("dut_number_value", tempSN);
                }
                else
                {
                    hashtable.Add("dut_number_name", FormMain.globalSettings.InputNumber);
                    hashtable.Add("dut_number_value", tempSN);
                }

                //离线测试
                if (FormMain.globalSettings.IsOffline.Equals("是"))
                {
                    StartTest();
                    return;
                }

                //新接口检查设备过站状态及是否可进行测试
                hashtable.Add("station", FormMain.globalSettings.StationName);
                string preRes = UrlHelper.GetStationStatu(FormMain.globalSettings.ServerIP, hashtable);
                if (string.IsNullOrEmpty(preRes)) return;
                JObject jArray = (JObject)JsonConvert.DeserializeObject(preRes);
                string resultCode = jArray["resultCode"].ToString();
                string resultMsg = jArray["resultMsg"].ToString();
                if (resultCode == "0")
                {
                    StartTest();
                }
                else
                {
                    InvokeHelper.Set(textBoxSerialInputSn, "Text", "");
                    MessageBox.Show(resultMsg);
                    return;
                }
            }
        }

        private void buttonSerialSettingClick(object sender, EventArgs e)
        {
            ReleaseResource();
            formSerialPortSettings.ShowDialog();
        }

        private void buttonSerialOpenClick(object sender, EventArgs e)
        {
            if (((string)InvokeHelper.Get(buttonSerialOpen, "Text")).Equals("打开串口"))
            {
                bool isOpen = serialPort4Utils.OpenSerial();
                if (isOpen)
                {
                    InvokeHelper.Set(buttonSerialOpen, "Text", "关闭串口");
                }
                else
                {
                    InvokeHelper.Set(buttonSerialOpen, "Text", "打开串口");
                }
            }
            else
            {
                ReleaseResource();
            }
        }

        private static void StopTest()
        {
            try
            {
                //关闭串口之前，先终止测试
                string res = serialPort4Utils.Send(RS485Commands.GetInstance().Stop);
                res = RS485DealWithResult.DeleteSpace(res).ToLower();
                PrintUitls.Write("终止测试------>", 4);
            }
            catch (Exception ex)
            {
                PrintUitls.Write(ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }
        /// <summary>
        /// 获取测试完成的总用时
        /// </summary>
        public void GetTestedTimes(string type)
        {
            try
            {
                string res = serialPort4Utils.Send(RS485Commands.GetInstance().GetTestTimes);
                res = RS485DealWithResult.DeleteSpace(res).ToLower();
                res = res.Substring(6, 12);
                double jinQiTime = Convert.ToDouble(RS485DealWithResult.HexStr2DecimalInt(res.Substring(0, 4))) / 10;
                double wenYaTime = Convert.ToDouble(RS485DealWithResult.HexStr2DecimalInt(res.Substring(4, 4))) / 10;
                double testTotalTime = Convert.ToDouble(RS485DealWithResult.HexStr2DecimalInt(res.Substring(8, 4))) / 10;

                PrintUitls.Write("jinQiTime=" + jinQiTime + ",wenYaTime=" + wenYaTime + ",testTotalTime=" + testTotalTime, 4);
                InvokeHelper.Set(labelSerialProgress, "Text", "充气" + jinQiTime + "秒" + ",稳压" + wenYaTime + "秒" + ",测试" + testTotalTime + "秒");

                _mEntryBean.ChongQiTime = jinQiTime.ToString();
                _mEntryBean.WenYaTime = wenYaTime.ToString();
                _mEntryBean.TestTime = testTotalTime.ToString();

                if (type.Equals("OK"))
                {
                    InvokeHelper.Set(labelSerialProgress, "ForeColor", Color.Green);
                }
                else
                {
                    InvokeHelper.Set(labelSerialProgress, "ForeColor", Color.Red);
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write("GetTestedTimes异常=" + ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime startTestT = DateTime.Now;
        private TimeSpan TimeCount = new TimeSpan();
        private static bool IsStopThreadCountTimeWhile = false;
        /// <summary>
        /// 计算测试时间，每一秒更新一下UI
        /// </summary>
        private void CountTestTime()
        {
            threadCountTime = new Thread(new ThreadStart(StartThreadCountTime));
            threadCountTime.Start();
        }
        private void StartThreadCountTime()
        {
            startTestT = DateTime.Now;
            IsStopThreadCountTimeWhile = false;

            try
            {
                while (!IsStopThreadCountTimeWhile)
                {
                    TimeCount = DateTime.Now - startTestT;
                    string currTime = string.Format("{0:00}:{1:00}", TimeCount.Minutes, TimeCount.Seconds);
                    InvokeHelper.Set(labelSerialTestTime, "Text", currTime);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write(ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }
        //保存测试的单位和精度
        private Dictionary<string, string> unitDictionary = new Dictionary<string, string>();
        private string unit = string.Empty;
        private int Precision = -1;

        private static bool IsRunning = false;

        /// <summary>
        /// 开始测试
        /// </summary>
        private void StartTest()
        {
            if (!serialPort4Utils.SerialIsOpen())
            {
                //打开串口
                bool isOpen = serialPort4Utils.OpenSerial();
                buttonSerialOpen.Text = isOpen ? ("关闭串口") : ("打开串口");
                if (!isOpen)
                {
                    //打开串口失败！
                    return;
                }
            }

            IsRunning = true;
            _mEntryBean = new EntryBean();
            textBoxSerialInputSn.Enabled = false;
            buttonSerialSetting.Enabled = false;
            buttonSerialOpen.Enabled = false;
            onkeyDownCallBack.OnKeyDown();

            ResetUI();

            //开启计时
            CountTestTime();

            //1.1 检查机器是否是空闲状态
            string deviceStatus = serialPort4Utils.Send(RS485Commands.GetInstance().GetDeviceStatus);
            deviceStatus = RS485DealWithResult.GetTestStatus(deviceStatus);
            PrintUitls.Write("仪器初始状态=" + deviceStatus, 4);

            if (deviceStatus.Equals("设备空闲"))
            {
                labelSerialTips.Text = "请启动测试仪";
                labelSerialTips.ForeColor = Color.Red;

                //HSQ-2024.1.8
                if (FormMain.globalSettings.WorkMode == "自动触发")
                {
                    Thread.Sleep(1000);
                    string Start = serialPort4Utils.Send(RS485Commands.GetInstance().Start);
                    Start = RS485DealWithResult.GetTestStatus(Start);
                }
            }
            else
            {
                labelSerialTips.Text = "设备未就绪，请稍后重试";
                labelSerialTips.ForeColor = Color.Red;
                ReleaseResource();
                return;
            }

            try
            {
                // 1.2 获取仪器设置的单位和精度
                string hexData = serialPort4Utils.Send(RS485Commands.GetInstance().GetUnit);
                unitDictionary = RS485DealWithResult.GetUnitAndPrecision(hexData);
                foreach (var item in unitDictionary)
                {
                    unit = item.Key;
                    Precision = Convert.ToInt32(item.Value);
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write(ex.StackTrace + ",msg=" + ex.Message, 4);
            }

            //2-1、检测仪器状态，是否可以启动测试
            threadGetStatus = new Thread(new ThreadStart(StartThreadGetStatus));
            threadGetStatus.Start();
        }

        /// <summary>
        /// 重置UI
        /// </summary>
        public void ResetUI(bool IsStopBU = false)
        {
            InvokeHelper.Set(progressBarSerial, "Value", 0);
            InvokeHelper.Set(labelSerialTestStatus, "Text", "");
            InvokeHelper.Set(labelSerialTestStatus, "ForeColor", Color.Black);
            InvokeHelper.Set(labelSerialTestPressure, "Text", "");
            InvokeHelper.Set(labelSerialDeviationPressure, "Text", "");
            InvokeHelper.Set(labelSerialAirLeakAgeValue, "Text", "");
            InvokeHelper.Set(labelSerialDeviationLeakAge, "Text", "");
            InvokeHelper.Set(labelSerialLeakageRate, "Text", "");
            InvokeHelper.Set(labelSerialTestResult, "Text", "");
            InvokeHelper.Set(labelSerialUploadResult, "Text", "");
            if (!IsStopBU)
            {
                InvokeHelper.Set(labelSerialTips, "Text", "");
                InvokeHelper.Set(labelSerialTestTime, "Text", "");
                InvokeHelper.Set(labelSerialFails, "Text", "0");
                InvokeHelper.Set(labelSerialProgress, "Text", "");
            }
        }

        /// <summary>
        /// 是否终止检查仪器状态的循环，一起启动之后就可以终止退出了
        /// </summary>
        private static bool IsStopThreadGetStatusWhile = false;

        private void StartThreadGetStatus()
        {
            try
            {
                IsStopThreadGetStatusWhile = false;

                while (!IsStopThreadGetStatusWhile)
                {
                    string deviceStatus = serialPort4Utils.Send(RS485Commands.GetInstance().GetDeviceStatus);
                    deviceStatus = RS485DealWithResult.GetTestStatus(deviceStatus);
                    PrintUitls.Write("仪器当前状态=" + deviceStatus, 4);

                    if (!deviceStatus.Equals("设备空闲"))
                    {
                        IsStopThreadGetStatusWhile = true;

                        //2-2、进度更新
                        threadProgress = new Thread(new ThreadStart(StartThreadTesting));
                        threadProgress.Start();

                        PrintUitls.Write("仪器已启动！退出检查...", 4);
                    }
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write(ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }

        /// <summary>
        /// 是否终止正在测试的循环
        /// </summary>
        private static bool IsStopThreadTestingWhile = false;
        /// <summary>
        /// 开始测试，进度的更新
        /// </summary>
        private void StartThreadTesting()
        {
            try
            {
                IsStopThreadTestingWhile = false;
                while (!IsStopThreadTestingWhile)
                {
                    // 判定结果读取
                    GetTestingResult();
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write(ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }

        private void GetTestingResult()
        {
            GetTestingProgress();

            string testingResult = serialPort4Utils.Send(RS485Commands.GetInstance().GetTestResult);
            testingResult = RS485DealWithResult.GetTestStatus(testingResult);
            PrintUitls.Write("机器状态=" + testingResult, 4);
            //检查是否测试完成
            if (testingResult.Equals("unknow"))
            {
                return;
            }

            if (testingResult.Contains("OK"))
            {
                numbersCallBack.updatePassNumbers(1);

                InvokeHelper.Set(labelSerialProgress, "Text", testingResult);
                InvokeHelper.Set(labelSerialProgress, "ForeColor", Color.Green);

                InvokeHelper.Set(labelSerialTips, "Text", "测试通过");
                InvokeHelper.Set(labelSerialTips, "ForeColor", Color.Green);

                InvokeHelper.Set(labelSerialTestStatus, "Text", "PASS");
                InvokeHelper.Set(labelSerialTestStatus, "ForeColor", Color.Green);

                InvokeHelper.Set(labelSerialTestResult, "Text", "OK");
                InvokeHelper.Set(labelSerialTestResult, "ForeColor", Color.Green);

                InvokeHelper.Set(textBoxSerialInputSn, "Text", "");

                InvokeHelper.Set(progressBarSerial, "Value", 100);

                GetTestedTimes("OK");
                UploadTestResult2Mes(true);
            }
            else if (testingResult.Contains("NG"))
            {
                numbersCallBack.updateFailNumbers(1);

                int failCount = Convert.ToInt32((string)InvokeHelper.Get(labelSerialFails, "Text"));
                failCount++;
                InvokeHelper.Set(labelSerialFails, "Text", failCount + "");

                InvokeHelper.Set(labelSerialProgress, "Text", testingResult);
                InvokeHelper.Set(labelSerialProgress, "ForeColor", Color.Red);

                InvokeHelper.Set(labelSerialTips, "Text", "测试失败");
                InvokeHelper.Set(labelSerialTips, "ForeColor", Color.Red);

                InvokeHelper.Set(labelSerialTestStatus, "Text", "NG");
                InvokeHelper.Set(labelSerialTestStatus, "ForeColor", Color.Red);

                InvokeHelper.Set(labelSerialTestResult, "Text", "NG");
                InvokeHelper.Set(labelSerialTestResult, "ForeColor", Color.Red);

                InvokeHelper.Set(textBoxSerialInputSn, "Text", "");

                InvokeHelper.Set(progressBarSerial, "Value", 100);

                GetTestedTimes("NG");
                UploadTestResult2Mes(false);
            }
            else
            {
                InvokeHelper.Set(labelSerialProgress, "Text", testingResult);
                InvokeHelper.Set(labelSerialProgress, "ForeColor", Color.Green);

                InvokeHelper.Set(labelSerialTips, "Text", "测试仪已启动测试");
                InvokeHelper.Set(labelSerialTips, "ForeColor", Color.Green);

                InvokeHelper.Set(labelSerialTestStatus, "Text", "Testing");
                InvokeHelper.Set(labelSerialTestStatus, "ForeColor", Color.Black);

                CheckTestingIsStopByU();
            }
        }

        /// <summary>
        /// 检查仪器是否人为停止测试
        /// </summary>
        private void CheckTestingIsStopByU()
        {
            try
            {
                string deviceStatus = serialPort4Utils.Send(RS485Commands.GetInstance().GetDeviceStatus);
                deviceStatus = RS485DealWithResult.GetTestStatus(deviceStatus);
                if (deviceStatus.Equals("设备空闲"))
                {
                    PrintUitls.Write("仪器测试过程中终止测试--1", 4);

                    InvokeHelper.Set(textBoxSerialInputSn, "Text", "");

                    InvokeHelper.Set(labelSerialTips, "Text", "测试仪已终止测试");
                    InvokeHelper.Set(labelSerialTips, "ForeColor", Color.Red);

                    InvokeHelper.Set(labelSerialTestStatus, "Text", "Stop");
                    InvokeHelper.Set(labelSerialTestStatus, "ForeColor", Color.Red);

                    ResetUI(true);

                    PrintUitls.Write("CheckTestingIsStopByU= ReleaseResource", 4);
                    ReleaseResource();
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write("CheckTestingIsStopByU=" + ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }

        /// <summary>
        /// 获取仪器测试的进度
        /// </summary>
        private void GetTestingProgress()
        {
            try
            {
                if (IsStopThreadTestingWhile)
                {
                    PrintUitls.Write("不更新进度条，进程已经退出！", 4);
                    return;
                }

                string hexData = serialPort4Utils.Send(RS485Commands.GetInstance().GetTestProgress);
                hexData = RS485DealWithResult.DeleteSpace(hexData);
                //取数据位
                hexData = hexData.Substring(6, 8);

                int fenzi = Convert.ToInt32(hexData.Substring(4, 4), 16);
                int fenmu = Convert.ToInt32(hexData.Substring(0, 4), 16);

                // PrintUitls.Write("测试进度,fenzi=" + fenzi + ",fenmu=" + fenmu, 4);
                if (fenzi <= fenmu)
                {
                    int progress = Convert.ToInt32(Convert.ToDouble(fenzi) / Convert.ToDouble(fenmu) * 100);
                    PrintUitls.Write("测试进度,progress=" + progress, 4);

                    InvokeHelper.Set(progressBarSerial, "Value", progress);

                    //大于95的时候就不更新测试压力了，最后的压力可能会偏差较大，丢弃掉
                    if (progress >= 0 && progress <= 95)
                    {
                        GetTestingPressure();
                        GetTestingLeakAgeRate();
                        GetTestingLeakAgeValue();
                    }
                }
            }
            catch (Exception ex)
            {
                PrintUitls.Write("GetTestingProgress=" + ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }
        /// <summary>
        /// 测试气压和偏差的获取
        /// </summary>
        private void GetTestingPressure()
        {
            try
            {
                if (IsStopThreadTestingWhile)
                {
                    PrintUitls.Write("不更新气压和偏差值，进程已经退出！", 4);
                    return;
                }

                string hexData = serialPort4Utils.Send(RS485Commands.GetInstance().GetCurrentPressureValue);
                int res = RS485DealWithResult.GetTestResult(hexData);
                if (Precision == -1 || res == 0x1212)
                {
                    return;
                }
                if (Precision == 4)
                {
                    Precision = 10000;
                }
                else if (Precision == 3)
                {
                    Precision = 1000;
                }
                else if (Precision == 2)
                {
                    Precision = 100;
                }
                else if (Precision == 1)
                {
                    Precision = 10;
                }
                else if (Precision == 0)
                {
                    Precision = 1;
                }
                double result = Convert.ToDouble(res) / Precision;
                //单位换算
                result = result / RS485DealWithResult.unitChangeRate;
                //判断当前测试气压是否在范围内
                //符合要求
                if (FormMain.globalSettings.PressureValueDown > FormMain.globalSettings.PressureValueUp)
                {
                    FormMain.globalSettings.PressureValueDown = FormMain.globalSettings.PressureValueUp;
                }

                if (result >= FormMain.globalSettings.PressureValueDown && result <= FormMain.globalSettings.PressureValueUp)
                {
                    InvokeHelper.Set(labelSerialDeviationPressure, "ForeColor", Color.Green);
                    InvokeHelper.Set(labelSerialTestPressure, "ForeColor", Color.Green);
                }
                else
                {
                    InvokeHelper.Set(labelSerialDeviationPressure, "ForeColor", Color.Red);
                    InvokeHelper.Set(labelSerialTestPressure, "ForeColor", Color.Red);
                }
                //保留三位有效数字
                result = Math.Round(result, 3);
                PrintUitls.Write("获取当前气压值=" + result + unit, 4);
                //设置压力值
                InvokeHelper.Set(labelSerialTestPressure, "Text", result + unit);
                _mEntryBean.testPressure = labelSerialTestPressure.Text;
                //设置压力偏差百分数
                double deviation = (result - FormMain.globalSettings.PressureValue) / FormMain.globalSettings.PressureValue * 100;
                deviation = Math.Round(deviation, 2);
                PrintUitls.Write("获取当前气压偏差=" + deviation, 4);
                InvokeHelper.Set(labelSerialDeviationPressure, "Text", deviation + "%");
                _mEntryBean.testPressureDeviation = labelSerialDeviationPressure.Text;
            }
            catch (Exception ex)
            {
                PrintUitls.Write("获取当前气压值异常=" + ex.StackTrace + ",msg=" + ex.Message, 4);
            }
        }
        /// <summary>
        /// 关闭资源
        /// </summary>
        public static void ReleaseResource()
        {
            try
            {
                if (serialPort4Utils.IsReceiverData) StopTest();
                serialPort4Utils.CloseSerial();
                InvokeHelper.Set(buttonSerialOpen, "Text", "打开串口");
                IsStopThreadCountTimeWhile = true;
                IsStopThreadTestingWhile = true;
                IsRunning = false;
                InvokeHelper.Set(textBoxSerialInputSn, "Enabled", true);
                InvokeHelper.Set(buttonSerialSetting, "Enabled", true);
                InvokeHelper.Set(buttonSerialOpen, "Enabled", true);
                InvokeHelper.Invoke(textBoxSerialInputSn, "Focus");
            }
            catch (Exception ex)
            {
                PrintUitls.Write(ex.StackTrace + ",msg=" + ex.Message, 4);
            }
            finally
            {
                _mEntryBean = null;
            }
        }
        /// <summary>
        /// 获取泄漏 速率
        /// </summary>
        private void GetTestingLeakAgeRate()
        {
            string hexData = serialPort4Utils.Send(RS485Commands.GetInstance().LeakageRateSCCMValue);
            int res = RS485DealWithResult.GetTestResult(hexData);
            PrintUitls.Write("获取泄漏速率=" + res, 4);

            if (Precision == 4)
            {
                Precision = 10000;
            }
            else if (Precision == 3)
            {
                Precision = 1000;
            }
            else if (Precision == 2)
            {
                Precision = 100;
            }
            else if (Precision == 1)
            {
                Precision = 10;
            }
            else if (Precision == 0)
            {
                Precision = 1;
            }

            double result = Convert.ToDouble(res) / Precision;
            InvokeHelper.Set(labelSerialLeakageRate, "Text", result + "sccm");
            _mEntryBean.LeakageRate = labelSerialLeakageRate.Text;
        }

        /// <summary>
        /// 获取泄漏值和偏差
        /// </summary>
        private void GetTestingLeakAgeValue()
        {
            string hexData = serialPort4Utils.Send(RS485Commands.GetInstance().DirectPressureTestLeakageValue);
            int res = RS485DealWithResult.GetTestResult(hexData);
            PrintUitls.Write("获取泄漏值=" + res, 4);
            if (Precision == -1 || res == 0x1212)
            {
                return;
            }
            if (Precision == 4)
            {
                Precision = 10000;
            }
            else if (Precision == 3)
            {
                Precision = 1000;
            }
            else if (Precision == 2)
            {
                Precision = 100;
            }
            else if (Precision == 1)
            {
                Precision = 10;
            }
            else if (Precision == 0)
            {
                Precision = 1;
            }

            double result = Convert.ToDouble(res) / Precision;
            //单位换算
            result = result / RS485DealWithResult.unitChangeRate;
            //判断当前测试泄漏值和偏差是否在范围内
            //符合要求
            //if (FormMain.globalSettings.LeakAgeValueDown > FormMain.globalSettings.LeakAgeValueUP)
            //{
            //    FormMain.globalSettings.LeakAgeValueDown = FormMain.globalSettings.LeakAgeValueUP;
            //}

            if (result <= FormMain.globalSettings.LeakAgeValueUP)
            {
                InvokeHelper.Set(labelSerialDeviationLeakAge, "ForeColor", Color.Green);
                InvokeHelper.Set(labelSerialAirLeakAgeValue, "ForeColor", Color.Green);
            }
            else
            {
                InvokeHelper.Set(labelSerialDeviationLeakAge, "ForeColor", Color.Red);
                InvokeHelper.Set(labelSerialAirLeakAgeValue, "ForeColor", Color.Red);
            }
            //保留三位有效数字
            result = Math.Round(result, 3);
            PrintUitls.Write("获取当前泄漏值=" + result + unit, 4);
            //设置泄漏值
            InvokeHelper.Set(labelSerialAirLeakAgeValue, "Text", result + unit);
            _mEntryBean.AirLeakageValue = labelSerialAirLeakAgeValue.Text;
            //设置泄漏偏差百分数（客户只给上限）
            double avgLeakAgeValue = FormMain.globalSettings.LeakAgeValueUP;
            double deviation = Math.Abs(result - avgLeakAgeValue) / avgLeakAgeValue * 100;
            //保留两位有效数字
            deviation = Math.Round(deviation, 2);
            PrintUitls.Write("获取当前气压偏差=" + deviation, 4);
            InvokeHelper.Set(labelSerialDeviationLeakAge, "Text", deviation + "%");
            _mEntryBean.AirLeakageValueDeviation = labelSerialDeviationLeakAge.Text;
        }
        /// <summary>
        /// 上传测试结果到Mes系统-1
        /// </summary>
        private void UploadTestResult2Mes(bool IsPass)
        {
            if (FormMain.globalSettings.IsOffline.Equals("是"))
            {
                InvokeHelper.Set(labelSerialUploadResult, "Text", "NG");
                InvokeHelper.Set(labelSerialUploadResult, "ForeColor", Color.Red);
            }
            else
            {
                if (IsPass)
                {
                    Upload("true");
                }
                else
                {
                    Upload("false");
                }
            }
            ReleaseResource();
        }
        /// <summary>
        /// 上传测试结果到Mes系统-2
        /// </summary>
        private void Upload(string result)
        {
            try
            {
                //处理时间格式原本为xx:xx格式
                string time = labelSerialTestTime.Text;
                time = Convert.ToInt32(time.Substring(0, 2)) * 60 + Convert.ToInt32(time.Substring(3, 2)) + "";

                //拼接测试信息
                _mEntryBean.TotalTestTime = labelSerialTestTime.Text;

                //上传过站标记
                Hashtable hashtable = new Hashtable();
                hashtable.Add("model", FormMain.globalSettings.Model);


                Regex regex = new Regex("\\w+\\(\\w+\\) ?");
                if (regex.IsMatch(FormMain.globalSettings.InputNumber))
                {
                    string old = FormMain.globalSettings.InputNumber;
                    string name = old.Substring(old.IndexOf('(') + 1, (old.Length - 1) - (old.IndexOf('(') + 1));
                    string oldinput = inputSn;
                    Regex regex1 = new Regex("([0-9A-F]{2}){6}");
                    Match match = regex1.Match(oldinput);
                    string Input = match.Value;
                    hashtable.Add("dut_number_name", name);
                    hashtable.Add("dut_number_value", Input);
                }
                else
                {
                    hashtable.Add("dut_number_name", FormMain.globalSettings.InputNumber);
                    hashtable.Add("dut_number_value", inputSn);
                }


                hashtable.Add("station", FormMain.globalSettings.StationName);
                hashtable.Add("fix_id", FormMain.globalSettings.StationId);
                hashtable.Add("line_name", FormMain.globalSettings.ProductionId);
                hashtable.Add("is_pass", result);
                hashtable.Add("elapsed", time);
                hashtable.Add("retry_cnt", "1");

                string res = string.Empty;
                //连续上传3次，避免网络问题失败
                for (int i = 0; i < 3; i++)
                {
                    res = UrlHelper.UploadTagWithTestInfos(FormMain.globalSettings.ServerIP, hashtable, JsonConvert.SerializeObject(_mEntryBean));
                    if (Regex.IsMatch(res, @"(""resultMsg"":""success"")"))
                    {
                        if (result == "true")
                        {
                            InvokeHelper.Set(labelSerialUploadResult, "Text", "OK");
                            InvokeHelper.Set(labelSerialUploadResult, "ForeColor", Color.Green);
                        }
                        else
                        {
                            InvokeHelper.Set(labelSerialUploadResult, "Text", "NG");
                            InvokeHelper.Set(labelSerialUploadResult, "ForeColor", Color.Red);
                        }

                        return;
                    }
                    else
                    {
                        continue;
                    }
                }

                InvokeHelper.Set(labelSerialUploadResult, "Text", "NG");
                InvokeHelper.Set(labelSerialUploadResult, "ForeColor", Color.Red);
                MessageBox.Show("【上传失败】\n" + res);
            }
            catch (Exception ex)
            {
                PrintUitls.Write("上传测试结果到Mes系统异常=" + ex.StackTrace + ",msg=" + ex.Message);
            }
        }
        /// <summary>
        /// 设置串口参数之后的回调
        /// </summary>
        /// <param name="type"></param>
        /// <param name="postSettings"></param>
        public void updateSerialPortConfig(SerializationFileType type, PostSettings postSettings)
        {
            if (type == SerializationFileType.SerialPort4)
            {
                comboBoxSerialName.Text = (postSettings as SerialPort4Paramas).SerialPort;
            }
        }
    }
}
