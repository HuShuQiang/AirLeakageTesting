using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AirLeakageTesting.imp;
using AirLeakageTesting.settings;
using AirLeakageTesting.utils;

namespace AirLeakageTesting
{
    public partial class FormGlobalSettings : Form
    {
        public FormGlobalSettings()
        {
            //窗体居中显示
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            InitChannelConboboxs();
            InitSettingsUI();
        }
        /// <summary>
        /// 最大支持4个通道（串口）
        /// </summary>
        public void InitChannelConboboxs()
        {
            comboBoxChannels.Items.Add("1");
            comboBoxChannels.Items.Add("2");
            comboBoxChannels.Items.Add("3");
            comboBoxChannels.Items.Add("4");

            comboBoxIsOffline.Items.Add("否");
            comboBoxIsOffline.Items.Add("是");

            comboBoxCheckPreStation.Items.Add("否");
            comboBoxCheckPreStation.Items.Add("是");

            comboBoxInputNumber.Items.Add("sn");
            comboBoxInputNumber.Items.Add("cmei");
            comboBoxInputNumber.Items.Add("main_board");
            comboBoxInputNumber.Items.Add("QR_code(wifi_mac)");
            comboBoxInputNumber.Items.Add("Packsn");

            WorkMode.Items.Add("自动触发");
            WorkMode.Items.Add("手动触发");
        }

        private GlobalSettings myGlobalSettings;

        private void InitSettingsUI()
        {
            GlobalSettings globalSettings = FileUitls.GetConfig(SerializationFileType.Global) as GlobalSettings;
            if (globalSettings != null)
            {
                this.myGlobalSettings = globalSettings;

                textBox_productionId.Text = globalSettings.ProductionId;
                textBox_stationId.Text = globalSettings.StationId;
                textBox_stationName.Text = globalSettings.StationName;

                textBox_model.Text = globalSettings.Model;
                textBox_ip.Text = globalSettings.ServerIP;

                comboBoxChannels.Text = globalSettings.ChannnelNumber + "";
                comboBoxIsOffline.Text = globalSettings.IsOffline;
                comboBoxCheckPreStation.Text = globalSettings.CheckPreStation;
                comboBoxInputNumber.Text = globalSettings.InputNumber;

                textBox_pressureValue.Text = globalSettings.PressureValue + "";
                textBox_pressureValueUp.Text = globalSettings.PressureValueUp + "";
                textBox_pressureValueDown.Text = globalSettings.PressureValueDown + "";

                textBox_leakAgeUp.Text = globalSettings.LeakAgeValueUP + "";
                //textBox_leakAgeDown.Text = globalSettings.LeakAgeValueDown + "";

                textBox_chongQiTime.Text = globalSettings.ChongQiTime + "";
                textBox_wenYaTime.Text = globalSettings.WenYaTime + "";
                textBox_testingTime.Text = globalSettings.TestingTime + "";

                WorkMode.Text = globalSettings.WorkMode + "";
            }
            else
            {
                GlobalSettings global = new GlobalSettings();

                textBox_ip.Text = global.ServerIP;

                comboBoxChannels.Text = global.ChannnelNumber + "";
                comboBoxIsOffline.Text = global.IsOffline;
                comboBoxCheckPreStation.Text = global.CheckPreStation;
                comboBoxInputNumber.Text = global.InputNumber;

                textBox_pressureValue.Text = global.PressureValue + "";
                textBox_pressureValueUp.Text = global.PressureValueUp + "";
                textBox_pressureValueDown.Text = global.PressureValueDown + "";

                textBox_leakAgeUp.Text = global.LeakAgeValueUP + "";
                //textBox_leakAgeDown.Text = global.LeakAgeValueDown + "";

                textBox_chongQiTime.Text = global.ChongQiTime + "";
                textBox_wenYaTime.Text = global.WenYaTime + "";
                textBox_testingTime.Text = global.TestingTime + "";

                WorkMode.Text = global.WorkMode + "";

                this.myGlobalSettings = global;
            }
        }

        /// <summary>
        /// 设置保存成功的回调
        /// </summary>
        private SettingsCallBack settingsCallB;
        public void SetSettingsCallB(SettingsCallBack settingsCallB)
        {
            this.settingsCallB = settingsCallB;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            GlobalSettings globalSettings = this.myGlobalSettings;

            string productionId = textBox_productionId.Text;
            if (string.IsNullOrEmpty(productionId))
            {
                MessageBox.Show("生产线Id不能为空！");
                return;
            }
            if (!Regex.IsMatch(productionId, "\\d"))
            {
                MessageBox.Show("生产线Id只能是数字！");
                return;
            }
            globalSettings.ProductionId = productionId;

            string stationId = textBox_stationId.Text;
            if (string.IsNullOrEmpty(stationId))
            {
                MessageBox.Show("工位Id不能为空！");
                return;
            }
            if (!Regex.IsMatch(stationId, "\\d"))
            {
                MessageBox.Show("工位Id只能是数字！");
                return;
            }
            globalSettings.StationId = stationId;

            string stationName = textBox_stationName.Text;
            if (string.IsNullOrEmpty(stationName))
            {
                MessageBox.Show("工位名不能为空！");
                return;
            }
            globalSettings.StationName = stationName;

            string serverModel = textBox_model.Text;
            if (string.IsNullOrEmpty(serverModel))
            {
                MessageBox.Show("服务器机型不能为空！");
                return;
            }
            globalSettings.Model = serverModel;

            string serverIP = textBox_ip.Text;
            if (string.IsNullOrEmpty(serverIP))
            {
                MessageBox.Show("服务器IP不能为空！");
                return;
            }
            string regex = "^(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)(:\\d*)?$";

            if (!Regex.IsMatch(serverIP, regex))
            {
                MessageBox.Show("服务器IP不符合规范！");
                return;
            }
            globalSettings.ServerIP = serverIP;

            string pressureValue = textBox_pressureValue.Text;
            if (string.IsNullOrEmpty(pressureValue) || pressureValue.Equals("0"))
            {
                MessageBox.Show("请设置进气压力！");
                return;
            }
            if (!Regex.IsMatch(pressureValue, "\\d"))
            {
                MessageBox.Show("进气压力只能是数字！");
                return;
            }
            globalSettings.PressureValue = Convert.ToDouble(pressureValue);

            string pressureValueUp = textBox_pressureValueUp.Text;
            if (string.IsNullOrEmpty(pressureValueUp) || pressureValueUp.Equals("0"))
            {
                MessageBox.Show("请设置进气压力上限！");
                return;
            }
            if (!Regex.IsMatch(pressureValueUp, "\\d"))
            {
                MessageBox.Show("进气压力上限只能是数字！");
                return;
            }
            globalSettings.PressureValueUp = Convert.ToDouble(pressureValueUp);

            string pressureValueDown = textBox_pressureValueDown.Text;
            if (string.IsNullOrEmpty(pressureValueDown) || pressureValueDown.Equals("0"))
            {
                MessageBox.Show("请设置进气压力下限！");
                return;
            }
            if (!Regex.IsMatch(pressureValueDown, "\\d"))
            {
                MessageBox.Show("进气压力下限只能是数字！");
                return;
            }
            globalSettings.PressureValueDown = Convert.ToDouble(pressureValueDown);

            string leakAgeUp = textBox_leakAgeUp.Text;
            if (string.IsNullOrEmpty(leakAgeUp) || leakAgeUp.Equals("0"))
            {
                MessageBox.Show("请设置样本泄漏上限！");
                return;
            }
            if (!Regex.IsMatch(leakAgeUp, "\\d"))
            {
                MessageBox.Show("样本泄漏上限只能是数字！");
                return;
            }
            globalSettings.LeakAgeValueUP = Convert.ToDouble(leakAgeUp);

            //string leakAgeDown = textBox_leakAgeDown.Text;
            //if (string.IsNullOrEmpty(leakAgeDown) || leakAgeDown.Equals("0"))
            //{
            //    MessageBox.Show("请设置样本泄漏下限！");
            //    return;
            //}
            //if (!Regex.IsMatch(leakAgeDown, "\\d"))
            //{
            //    MessageBox.Show("样本泄漏下限只能是数字！");
            //    return;
            //}
            //globalSettings.LeakAgeValueDown = Convert.ToDouble(leakAgeDown);

            string chongQiTime = textBox_chongQiTime.Text;
            if (string.IsNullOrEmpty(chongQiTime) || chongQiTime.Equals("0"))
            {
                MessageBox.Show("请设置样本充气时间！");
                return;
            }
            if (!Regex.IsMatch(chongQiTime, "\\d"))
            {
                MessageBox.Show("样本充气时间只能是数字！");
                return;
            }
            globalSettings.ChongQiTime = Convert.ToInt32(chongQiTime);

            string wenYaTime = textBox_wenYaTime.Text;
            if (string.IsNullOrEmpty(wenYaTime) || wenYaTime.Equals("0"))
            {
                MessageBox.Show("请设置样本稳压时间！");
                return;
            }
            if (!Regex.IsMatch(wenYaTime, "\\d"))
            {
                MessageBox.Show("样本稳压时间只能是数字！");
                return;
            }
            globalSettings.WenYaTime = Convert.ToInt32(wenYaTime);

            string testingTime = textBox_testingTime.Text;
            if (string.IsNullOrEmpty(testingTime) || testingTime.Equals("0"))
            {
                MessageBox.Show("请设置样本测试时间！");
                return;
            }
            if (!Regex.IsMatch(testingTime, "\\d"))
            {
                MessageBox.Show("样本测试时间只能是数字！");
                return;
            }

            globalSettings.TestingTime = Convert.ToInt32(testingTime);

            string channekNumbers = comboBoxChannels.Text;
            if (string.IsNullOrEmpty(channekNumbers))
            {
                MessageBox.Show("通道数未设置！");
                return;
            }
            globalSettings.ChannnelNumber = Convert.ToInt32(channekNumbers);

            string isOffline = comboBoxIsOffline.Text;
            if (string.IsNullOrEmpty(isOffline))
            {
                MessageBox.Show("访问服务器是否未设置！");
                return;
            }
            globalSettings.IsOffline = isOffline;

            if (isOffline == "是")
            {
                globalSettings.CheckPreStation = "否";
            }
            else
            {
                globalSettings.CheckPreStation = "是";
            }

            //string checkPreStation = comboBoxCheckPreStation.Text;
            //if (string.IsNullOrEmpty(checkPreStation))
            //{
            //    MessageBox.Show("是否检查前一工位未设置！");
            //    return;
            //}
            //globalSettings.CheckPreStation = checkPreStation;

            string inputNumber = comboBoxInputNumber.Text;
            if (string.IsNullOrEmpty(inputNumber))
            {
                MessageBox.Show("扫描的号码（唯一项）未设置！");
                return;
            }
            globalSettings.InputNumber = inputNumber;

            globalSettings.WorkMode = WorkMode.Text;

            FileUitls.SaveConfig(globalSettings);

            this.settingsCallB.updateConfig(globalSettings);

            this.Close();
        }
    }
}
