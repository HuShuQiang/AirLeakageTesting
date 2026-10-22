using System.Diagnostics;
using System.Windows.Forms;

namespace AirLeakageTesting
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_serial1 = new System.Windows.Forms.Panel();
            this.label_serial1_testTime = new System.Windows.Forms.Label();
            this.label_serial1_testStatus = new System.Windows.Forms.Label();
            this.label_serial1_tips = new System.Windows.Forms.Label();
            this.label_serial1_progress = new System.Windows.Forms.Label();
            this.progressBar_serial1 = new System.Windows.Forms.ProgressBar();
            this.textBox_serial1_inputSn = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label_serial1_uploadResult = new System.Windows.Forms.Label();
            this.label_serial1_testResult = new System.Windows.Forms.Label();
            this.label_serial1_airLeakAgeValue = new System.Windows.Forms.Label();
            this.label_serial1_leakageRate = new System.Windows.Forms.Label();
            this.label_serial1_deviationPressure = new System.Windows.Forms.Label();
            this.label_serial1_deviationLeakAge = new System.Windows.Forms.Label();
            this.label_serial1_testPressure = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_serial1_fials = new System.Windows.Forms.Label();
            this.button_serial1_open = new System.Windows.Forms.Button();
            this.button_serial1_setting = new System.Windows.Forms.Button();
            this.comboBox_serial1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_serial2 = new System.Windows.Forms.Panel();
            this.label_serial2_testTime = new System.Windows.Forms.Label();
            this.label_serial2_testStatus = new System.Windows.Forms.Label();
            this.label_serial2_tips = new System.Windows.Forms.Label();
            this.label_serial2_progress = new System.Windows.Forms.Label();
            this.textBox_serial2_inputSn = new System.Windows.Forms.TextBox();
            this.progressBar_serial2 = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label_serial2_uploadResult = new System.Windows.Forms.Label();
            this.label_serial2_airLeakAgeValue = new System.Windows.Forms.Label();
            this.label_serial2_testResult = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_serial2 = new System.Windows.Forms.ComboBox();
            this.label_serial2_leakageRate = new System.Windows.Forms.Label();
            this.button_serial2_setting = new System.Windows.Forms.Button();
            this.label_serial2_deviationPressure = new System.Windows.Forms.Label();
            this.button_serial2_open = new System.Windows.Forms.Button();
            this.label_serial2_deviationLeakAge = new System.Windows.Forms.Label();
            this.label_serial2_testPressure = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label_serial2_fials = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel_serial3 = new System.Windows.Forms.Panel();
            this.label_serial3_testTime = new System.Windows.Forms.Label();
            this.label_serial3_testStatus = new System.Windows.Forms.Label();
            this.label_serial3_tips = new System.Windows.Forms.Label();
            this.label_serial3_progress = new System.Windows.Forms.Label();
            this.textBox_serial3_inputSn = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.progressBar_serial3 = new System.Windows.Forms.ProgressBar();
            this.label_serial3_uploadResult = new System.Windows.Forms.Label();
            this.label_serial3_airLeakAgeValue = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label_serial3_testResult = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.comboBox_serial3 = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label_serial3_leakageRate = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.button_serial3_setting = new System.Windows.Forms.Button();
            this.label_serial3_fials = new System.Windows.Forms.Label();
            this.label_serial3_deviationPressure = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.button_serial3_open = new System.Windows.Forms.Button();
            this.label_serial3_deviationLeakAge = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label_serial3_testPressure = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.panel_serial4 = new System.Windows.Forms.Panel();
            this.label_serial4_testTime = new System.Windows.Forms.Label();
            this.label_serial4_testStatus = new System.Windows.Forms.Label();
            this.label_serial4_tips = new System.Windows.Forms.Label();
            this.label_serial4_progress = new System.Windows.Forms.Label();
            this.textBox_serial4_inputSn = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label_serial4_uploadResult = new System.Windows.Forms.Label();
            this.progressBar_serial4 = new System.Windows.Forms.ProgressBar();
            this.label_serial4_deviationPressure = new System.Windows.Forms.Label();
            this.label_serial4_airLeakAgeValue = new System.Windows.Forms.Label();
            this.label_serial4_testPressure = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label_serial4_testResult = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label_serial4_deviationLeakAge = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.comboBox_serial4 = new System.Windows.Forms.ComboBox();
            this.button_serial4_open = new System.Windows.Forms.Button();
            this.label60 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label_serial4_leakageRate = new System.Windows.Forms.Label();
            this.label_serial4_fials = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.button_serial4_setting = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label_sampleIndex = new System.Windows.Forms.Label();
            this.panel_title = new System.Windows.Forms.Panel();
            this.label_totalNGNumbers = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label_totalPassNumbers = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label_stationName = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label_productionModel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel_serial1.SuspendLayout();
            this.panel_serial2.SuspendLayout();
            this.panel_serial3.SuspendLayout();
            this.panel_serial4.SuspendLayout();
            this.panel_title.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            resources.ApplyResources(this.设置ToolStripMenuItem, "设置ToolStripMenuItem");
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            resources.ApplyResources(this.ToolStripMenuItem, "ToolStripMenuItem");
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // panel_serial1
            // 
            this.panel_serial1.Controls.Add(this.label_serial1_testTime);
            this.panel_serial1.Controls.Add(this.label_serial1_testStatus);
            this.panel_serial1.Controls.Add(this.label_serial1_tips);
            this.panel_serial1.Controls.Add(this.label_serial1_progress);
            this.panel_serial1.Controls.Add(this.progressBar_serial1);
            this.panel_serial1.Controls.Add(this.textBox_serial1_inputSn);
            this.panel_serial1.Controls.Add(this.label13);
            this.panel_serial1.Controls.Add(this.label_serial1_uploadResult);
            this.panel_serial1.Controls.Add(this.label_serial1_testResult);
            this.panel_serial1.Controls.Add(this.label_serial1_airLeakAgeValue);
            this.panel_serial1.Controls.Add(this.label_serial1_leakageRate);
            this.panel_serial1.Controls.Add(this.label_serial1_deviationPressure);
            this.panel_serial1.Controls.Add(this.label_serial1_deviationLeakAge);
            this.panel_serial1.Controls.Add(this.label_serial1_testPressure);
            this.panel_serial1.Controls.Add(this.label10);
            this.panel_serial1.Controls.Add(this.label9);
            this.panel_serial1.Controls.Add(this.label8);
            this.panel_serial1.Controls.Add(this.label6);
            this.panel_serial1.Controls.Add(this.label7);
            this.panel_serial1.Controls.Add(this.label5);
            this.panel_serial1.Controls.Add(this.label4);
            this.panel_serial1.Controls.Add(this.label_serial1_fials);
            this.panel_serial1.Controls.Add(this.button_serial1_open);
            this.panel_serial1.Controls.Add(this.button_serial1_setting);
            this.panel_serial1.Controls.Add(this.comboBox_serial1);
            this.panel_serial1.Controls.Add(this.label1);
            this.panel_serial1.Controls.Add(this.label3);
            this.panel_serial1.Controls.Add(this.label2);
            resources.ApplyResources(this.panel_serial1, "panel_serial1");
            this.panel_serial1.Name = "panel_serial1";
            // 
            // label_serial1_testTime
            // 
            resources.ApplyResources(this.label_serial1_testTime, "label_serial1_testTime");
            this.label_serial1_testTime.Name = "label_serial1_testTime";
            // 
            // label_serial1_testStatus
            // 
            resources.ApplyResources(this.label_serial1_testStatus, "label_serial1_testStatus");
            this.label_serial1_testStatus.Name = "label_serial1_testStatus";
            // 
            // label_serial1_tips
            // 
            this.label_serial1_tips.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.label_serial1_tips, "label_serial1_tips");
            this.label_serial1_tips.Name = "label_serial1_tips";
            // 
            // label_serial1_progress
            // 
            resources.ApplyResources(this.label_serial1_progress, "label_serial1_progress");
            this.label_serial1_progress.Name = "label_serial1_progress";
            // 
            // progressBar_serial1
            // 
            resources.ApplyResources(this.progressBar_serial1, "progressBar_serial1");
            this.progressBar_serial1.Name = "progressBar_serial1";
            // 
            // textBox_serial1_inputSn
            // 
            resources.ApplyResources(this.textBox_serial1_inputSn, "textBox_serial1_inputSn");
            this.textBox_serial1_inputSn.Name = "textBox_serial1_inputSn";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label_serial1_uploadResult
            // 
            resources.ApplyResources(this.label_serial1_uploadResult, "label_serial1_uploadResult");
            this.label_serial1_uploadResult.Name = "label_serial1_uploadResult";
            // 
            // label_serial1_testResult
            // 
            resources.ApplyResources(this.label_serial1_testResult, "label_serial1_testResult");
            this.label_serial1_testResult.Name = "label_serial1_testResult";
            // 
            // label_serial1_airLeakAgeValue
            // 
            resources.ApplyResources(this.label_serial1_airLeakAgeValue, "label_serial1_airLeakAgeValue");
            this.label_serial1_airLeakAgeValue.Name = "label_serial1_airLeakAgeValue";
            // 
            // label_serial1_leakageRate
            // 
            resources.ApplyResources(this.label_serial1_leakageRate, "label_serial1_leakageRate");
            this.label_serial1_leakageRate.Name = "label_serial1_leakageRate";
            // 
            // label_serial1_deviationPressure
            // 
            resources.ApplyResources(this.label_serial1_deviationPressure, "label_serial1_deviationPressure");
            this.label_serial1_deviationPressure.Name = "label_serial1_deviationPressure";
            // 
            // label_serial1_deviationLeakAge
            // 
            resources.ApplyResources(this.label_serial1_deviationLeakAge, "label_serial1_deviationLeakAge");
            this.label_serial1_deviationLeakAge.Name = "label_serial1_deviationLeakAge";
            // 
            // label_serial1_testPressure
            // 
            resources.ApplyResources(this.label_serial1_testPressure, "label_serial1_testPressure");
            this.label_serial1_testPressure.Name = "label_serial1_testPressure";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label_serial1_fials
            // 
            resources.ApplyResources(this.label_serial1_fials, "label_serial1_fials");
            this.label_serial1_fials.Name = "label_serial1_fials";
            // 
            // button_serial1_open
            // 
            resources.ApplyResources(this.button_serial1_open, "button_serial1_open");
            this.button_serial1_open.Name = "button_serial1_open";
            this.button_serial1_open.UseVisualStyleBackColor = true;
            // 
            // button_serial1_setting
            // 
            resources.ApplyResources(this.button_serial1_setting, "button_serial1_setting");
            this.button_serial1_setting.Name = "button_serial1_setting";
            this.button_serial1_setting.UseVisualStyleBackColor = true;
            // 
            // comboBox_serial1
            // 
            resources.ApplyResources(this.comboBox_serial1, "comboBox_serial1");
            this.comboBox_serial1.FormattingEnabled = true;
            this.comboBox_serial1.Name = "comboBox_serial1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel_serial2
            // 
            this.panel_serial2.Controls.Add(this.label_serial2_testTime);
            this.panel_serial2.Controls.Add(this.label_serial2_testStatus);
            this.panel_serial2.Controls.Add(this.label_serial2_tips);
            this.panel_serial2.Controls.Add(this.label_serial2_progress);
            this.panel_serial2.Controls.Add(this.textBox_serial2_inputSn);
            this.panel_serial2.Controls.Add(this.progressBar_serial2);
            this.panel_serial2.Controls.Add(this.label15);
            this.panel_serial2.Controls.Add(this.label_serial2_uploadResult);
            this.panel_serial2.Controls.Add(this.label_serial2_airLeakAgeValue);
            this.panel_serial2.Controls.Add(this.label_serial2_testResult);
            this.panel_serial2.Controls.Add(this.label11);
            this.panel_serial2.Controls.Add(this.comboBox_serial2);
            this.panel_serial2.Controls.Add(this.label_serial2_leakageRate);
            this.panel_serial2.Controls.Add(this.button_serial2_setting);
            this.panel_serial2.Controls.Add(this.label_serial2_deviationPressure);
            this.panel_serial2.Controls.Add(this.button_serial2_open);
            this.panel_serial2.Controls.Add(this.label_serial2_deviationLeakAge);
            this.panel_serial2.Controls.Add(this.label_serial2_testPressure);
            this.panel_serial2.Controls.Add(this.label22);
            this.panel_serial2.Controls.Add(this.label14);
            this.panel_serial2.Controls.Add(this.label21);
            this.panel_serial2.Controls.Add(this.label_serial2_fials);
            this.panel_serial2.Controls.Add(this.label20);
            this.panel_serial2.Controls.Add(this.label16);
            this.panel_serial2.Controls.Add(this.label19);
            this.panel_serial2.Controls.Add(this.label17);
            this.panel_serial2.Controls.Add(this.label18);
            this.panel_serial2.Controls.Add(this.label12);
            resources.ApplyResources(this.panel_serial2, "panel_serial2");
            this.panel_serial2.Name = "panel_serial2";
            // 
            // label_serial2_testTime
            // 
            resources.ApplyResources(this.label_serial2_testTime, "label_serial2_testTime");
            this.label_serial2_testTime.Name = "label_serial2_testTime";
            // 
            // label_serial2_testStatus
            // 
            resources.ApplyResources(this.label_serial2_testStatus, "label_serial2_testStatus");
            this.label_serial2_testStatus.Name = "label_serial2_testStatus";
            // 
            // label_serial2_tips
            // 
            this.label_serial2_tips.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.label_serial2_tips, "label_serial2_tips");
            this.label_serial2_tips.Name = "label_serial2_tips";
            // 
            // label_serial2_progress
            // 
            resources.ApplyResources(this.label_serial2_progress, "label_serial2_progress");
            this.label_serial2_progress.Name = "label_serial2_progress";
            // 
            // textBox_serial2_inputSn
            // 
            resources.ApplyResources(this.textBox_serial2_inputSn, "textBox_serial2_inputSn");
            this.textBox_serial2_inputSn.Name = "textBox_serial2_inputSn";
            // 
            // progressBar_serial2
            // 
            resources.ApplyResources(this.progressBar_serial2, "progressBar_serial2");
            this.progressBar_serial2.Name = "progressBar_serial2";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label_serial2_uploadResult
            // 
            resources.ApplyResources(this.label_serial2_uploadResult, "label_serial2_uploadResult");
            this.label_serial2_uploadResult.Name = "label_serial2_uploadResult";
            // 
            // label_serial2_airLeakAgeValue
            // 
            resources.ApplyResources(this.label_serial2_airLeakAgeValue, "label_serial2_airLeakAgeValue");
            this.label_serial2_airLeakAgeValue.Name = "label_serial2_airLeakAgeValue";
            // 
            // label_serial2_testResult
            // 
            resources.ApplyResources(this.label_serial2_testResult, "label_serial2_testResult");
            this.label_serial2_testResult.Name = "label_serial2_testResult";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // comboBox_serial2
            // 
            resources.ApplyResources(this.comboBox_serial2, "comboBox_serial2");
            this.comboBox_serial2.FormattingEnabled = true;
            this.comboBox_serial2.Name = "comboBox_serial2";
            // 
            // label_serial2_leakageRate
            // 
            resources.ApplyResources(this.label_serial2_leakageRate, "label_serial2_leakageRate");
            this.label_serial2_leakageRate.Name = "label_serial2_leakageRate";
            // 
            // button_serial2_setting
            // 
            resources.ApplyResources(this.button_serial2_setting, "button_serial2_setting");
            this.button_serial2_setting.Name = "button_serial2_setting";
            this.button_serial2_setting.UseVisualStyleBackColor = true;
            // 
            // label_serial2_deviationPressure
            // 
            resources.ApplyResources(this.label_serial2_deviationPressure, "label_serial2_deviationPressure");
            this.label_serial2_deviationPressure.Name = "label_serial2_deviationPressure";
            // 
            // button_serial2_open
            // 
            resources.ApplyResources(this.button_serial2_open, "button_serial2_open");
            this.button_serial2_open.Name = "button_serial2_open";
            this.button_serial2_open.UseVisualStyleBackColor = true;
            // 
            // label_serial2_deviationLeakAge
            // 
            resources.ApplyResources(this.label_serial2_deviationLeakAge, "label_serial2_deviationLeakAge");
            this.label_serial2_deviationLeakAge.Name = "label_serial2_deviationLeakAge";
            // 
            // label_serial2_testPressure
            // 
            resources.ApplyResources(this.label_serial2_testPressure, "label_serial2_testPressure");
            this.label_serial2_testPressure.Name = "label_serial2_testPressure";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label_serial2_fials
            // 
            resources.ApplyResources(this.label_serial2_fials, "label_serial2_fials");
            this.label_serial2_fials.Name = "label_serial2_fials";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Name = "label12";
            // 
            // panel_serial3
            // 
            this.panel_serial3.Controls.Add(this.label_serial3_testTime);
            this.panel_serial3.Controls.Add(this.label_serial3_testStatus);
            this.panel_serial3.Controls.Add(this.label_serial3_tips);
            this.panel_serial3.Controls.Add(this.label_serial3_progress);
            this.panel_serial3.Controls.Add(this.textBox_serial3_inputSn);
            this.panel_serial3.Controls.Add(this.label23);
            this.panel_serial3.Controls.Add(this.progressBar_serial3);
            this.panel_serial3.Controls.Add(this.label_serial3_uploadResult);
            this.panel_serial3.Controls.Add(this.label_serial3_airLeakAgeValue);
            this.panel_serial3.Controls.Add(this.label30);
            this.panel_serial3.Controls.Add(this.label_serial3_testResult);
            this.panel_serial3.Controls.Add(this.label31);
            this.panel_serial3.Controls.Add(this.label45);
            this.panel_serial3.Controls.Add(this.label32);
            this.panel_serial3.Controls.Add(this.comboBox_serial3);
            this.panel_serial3.Controls.Add(this.label33);
            this.panel_serial3.Controls.Add(this.label_serial3_leakageRate);
            this.panel_serial3.Controls.Add(this.label34);
            this.panel_serial3.Controls.Add(this.button_serial3_setting);
            this.panel_serial3.Controls.Add(this.label_serial3_fials);
            this.panel_serial3.Controls.Add(this.label_serial3_deviationPressure);
            this.panel_serial3.Controls.Add(this.label36);
            this.panel_serial3.Controls.Add(this.button_serial3_open);
            this.panel_serial3.Controls.Add(this.label_serial3_deviationLeakAge);
            this.panel_serial3.Controls.Add(this.label38);
            this.panel_serial3.Controls.Add(this.label_serial3_testPressure);
            this.panel_serial3.Controls.Add(this.label41);
            this.panel_serial3.Controls.Add(this.label37);
            resources.ApplyResources(this.panel_serial3, "panel_serial3");
            this.panel_serial3.Name = "panel_serial3";
            // 
            // label_serial3_testTime
            // 
            resources.ApplyResources(this.label_serial3_testTime, "label_serial3_testTime");
            this.label_serial3_testTime.Name = "label_serial3_testTime";
            // 
            // label_serial3_testStatus
            // 
            resources.ApplyResources(this.label_serial3_testStatus, "label_serial3_testStatus");
            this.label_serial3_testStatus.Name = "label_serial3_testStatus";
            // 
            // label_serial3_tips
            // 
            this.label_serial3_tips.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.label_serial3_tips, "label_serial3_tips");
            this.label_serial3_tips.Name = "label_serial3_tips";
            // 
            // label_serial3_progress
            // 
            resources.ApplyResources(this.label_serial3_progress, "label_serial3_progress");
            this.label_serial3_progress.Name = "label_serial3_progress";
            // 
            // textBox_serial3_inputSn
            // 
            resources.ApplyResources(this.textBox_serial3_inputSn, "textBox_serial3_inputSn");
            this.textBox_serial3_inputSn.Name = "textBox_serial3_inputSn";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // progressBar_serial3
            // 
            resources.ApplyResources(this.progressBar_serial3, "progressBar_serial3");
            this.progressBar_serial3.Name = "progressBar_serial3";
            // 
            // label_serial3_uploadResult
            // 
            resources.ApplyResources(this.label_serial3_uploadResult, "label_serial3_uploadResult");
            this.label_serial3_uploadResult.Name = "label_serial3_uploadResult";
            // 
            // label_serial3_airLeakAgeValue
            // 
            resources.ApplyResources(this.label_serial3_airLeakAgeValue, "label_serial3_airLeakAgeValue");
            this.label_serial3_airLeakAgeValue.Name = "label_serial3_airLeakAgeValue";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label_serial3_testResult
            // 
            resources.ApplyResources(this.label_serial3_testResult, "label_serial3_testResult");
            this.label_serial3_testResult.Name = "label_serial3_testResult";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // comboBox_serial3
            // 
            resources.ApplyResources(this.comboBox_serial3, "comboBox_serial3");
            this.comboBox_serial3.FormattingEnabled = true;
            this.comboBox_serial3.Name = "comboBox_serial3";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // label_serial3_leakageRate
            // 
            resources.ApplyResources(this.label_serial3_leakageRate, "label_serial3_leakageRate");
            this.label_serial3_leakageRate.Name = "label_serial3_leakageRate";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // button_serial3_setting
            // 
            resources.ApplyResources(this.button_serial3_setting, "button_serial3_setting");
            this.button_serial3_setting.Name = "button_serial3_setting";
            this.button_serial3_setting.UseVisualStyleBackColor = true;
            // 
            // label_serial3_fials
            // 
            resources.ApplyResources(this.label_serial3_fials, "label_serial3_fials");
            this.label_serial3_fials.Name = "label_serial3_fials";
            // 
            // label_serial3_deviationPressure
            // 
            resources.ApplyResources(this.label_serial3_deviationPressure, "label_serial3_deviationPressure");
            this.label_serial3_deviationPressure.Name = "label_serial3_deviationPressure";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // button_serial3_open
            // 
            resources.ApplyResources(this.button_serial3_open, "button_serial3_open");
            this.button_serial3_open.Name = "button_serial3_open";
            this.button_serial3_open.UseVisualStyleBackColor = true;
            // 
            // label_serial3_deviationLeakAge
            // 
            resources.ApplyResources(this.label_serial3_deviationLeakAge, "label_serial3_deviationLeakAge");
            this.label_serial3_deviationLeakAge.Name = "label_serial3_deviationLeakAge";
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label_serial3_testPressure
            // 
            resources.ApplyResources(this.label_serial3_testPressure, "label_serial3_testPressure");
            this.label_serial3_testPressure.Name = "label_serial3_testPressure";
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // panel_serial4
            // 
            this.panel_serial4.Controls.Add(this.label_serial4_testTime);
            this.panel_serial4.Controls.Add(this.label_serial4_testStatus);
            this.panel_serial4.Controls.Add(this.label_serial4_tips);
            this.panel_serial4.Controls.Add(this.label_serial4_progress);
            this.panel_serial4.Controls.Add(this.textBox_serial4_inputSn);
            this.panel_serial4.Controls.Add(this.label24);
            this.panel_serial4.Controls.Add(this.label_serial4_uploadResult);
            this.panel_serial4.Controls.Add(this.progressBar_serial4);
            this.panel_serial4.Controls.Add(this.label_serial4_deviationPressure);
            this.panel_serial4.Controls.Add(this.label_serial4_airLeakAgeValue);
            this.panel_serial4.Controls.Add(this.label_serial4_testPressure);
            this.panel_serial4.Controls.Add(this.label65);
            this.panel_serial4.Controls.Add(this.label_serial4_testResult);
            this.panel_serial4.Controls.Add(this.label63);
            this.panel_serial4.Controls.Add(this.label52);
            this.panel_serial4.Controls.Add(this.label62);
            this.panel_serial4.Controls.Add(this.label_serial4_deviationLeakAge);
            this.panel_serial4.Controls.Add(this.label61);
            this.panel_serial4.Controls.Add(this.comboBox_serial4);
            this.panel_serial4.Controls.Add(this.button_serial4_open);
            this.panel_serial4.Controls.Add(this.label60);
            this.panel_serial4.Controls.Add(this.label55);
            this.panel_serial4.Controls.Add(this.label_serial4_leakageRate);
            this.panel_serial4.Controls.Add(this.label_serial4_fials);
            this.panel_serial4.Controls.Add(this.label58);
            this.panel_serial4.Controls.Add(this.button_serial4_setting);
            this.panel_serial4.Controls.Add(this.label51);
            this.panel_serial4.Controls.Add(this.label54);
            resources.ApplyResources(this.panel_serial4, "panel_serial4");
            this.panel_serial4.Name = "panel_serial4";
            // 
            // label_serial4_testTime
            // 
            resources.ApplyResources(this.label_serial4_testTime, "label_serial4_testTime");
            this.label_serial4_testTime.Name = "label_serial4_testTime";
            // 
            // label_serial4_testStatus
            // 
            resources.ApplyResources(this.label_serial4_testStatus, "label_serial4_testStatus");
            this.label_serial4_testStatus.Name = "label_serial4_testStatus";
            // 
            // label_serial4_tips
            // 
            this.label_serial4_tips.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.label_serial4_tips, "label_serial4_tips");
            this.label_serial4_tips.Name = "label_serial4_tips";
            // 
            // label_serial4_progress
            // 
            resources.ApplyResources(this.label_serial4_progress, "label_serial4_progress");
            this.label_serial4_progress.Name = "label_serial4_progress";
            // 
            // textBox_serial4_inputSn
            // 
            resources.ApplyResources(this.textBox_serial4_inputSn, "textBox_serial4_inputSn");
            this.textBox_serial4_inputSn.Name = "textBox_serial4_inputSn";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label_serial4_uploadResult
            // 
            resources.ApplyResources(this.label_serial4_uploadResult, "label_serial4_uploadResult");
            this.label_serial4_uploadResult.Name = "label_serial4_uploadResult";
            // 
            // progressBar_serial4
            // 
            resources.ApplyResources(this.progressBar_serial4, "progressBar_serial4");
            this.progressBar_serial4.Name = "progressBar_serial4";
            // 
            // label_serial4_deviationPressure
            // 
            resources.ApplyResources(this.label_serial4_deviationPressure, "label_serial4_deviationPressure");
            this.label_serial4_deviationPressure.Name = "label_serial4_deviationPressure";
            // 
            // label_serial4_airLeakAgeValue
            // 
            resources.ApplyResources(this.label_serial4_airLeakAgeValue, "label_serial4_airLeakAgeValue");
            this.label_serial4_airLeakAgeValue.Name = "label_serial4_airLeakAgeValue";
            // 
            // label_serial4_testPressure
            // 
            resources.ApplyResources(this.label_serial4_testPressure, "label_serial4_testPressure");
            this.label_serial4_testPressure.Name = "label_serial4_testPressure";
            // 
            // label65
            // 
            resources.ApplyResources(this.label65, "label65");
            this.label65.Name = "label65";
            // 
            // label_serial4_testResult
            // 
            resources.ApplyResources(this.label_serial4_testResult, "label_serial4_testResult");
            this.label_serial4_testResult.Name = "label_serial4_testResult";
            // 
            // label63
            // 
            resources.ApplyResources(this.label63, "label63");
            this.label63.Name = "label63";
            // 
            // label52
            // 
            resources.ApplyResources(this.label52, "label52");
            this.label52.Name = "label52";
            // 
            // label62
            // 
            resources.ApplyResources(this.label62, "label62");
            this.label62.Name = "label62";
            // 
            // label_serial4_deviationLeakAge
            // 
            resources.ApplyResources(this.label_serial4_deviationLeakAge, "label_serial4_deviationLeakAge");
            this.label_serial4_deviationLeakAge.Name = "label_serial4_deviationLeakAge";
            // 
            // label61
            // 
            resources.ApplyResources(this.label61, "label61");
            this.label61.Name = "label61";
            // 
            // comboBox_serial4
            // 
            resources.ApplyResources(this.comboBox_serial4, "comboBox_serial4");
            this.comboBox_serial4.FormattingEnabled = true;
            this.comboBox_serial4.Name = "comboBox_serial4";
            // 
            // button_serial4_open
            // 
            resources.ApplyResources(this.button_serial4_open, "button_serial4_open");
            this.button_serial4_open.Name = "button_serial4_open";
            this.button_serial4_open.UseVisualStyleBackColor = true;
            // 
            // label60
            // 
            resources.ApplyResources(this.label60, "label60");
            this.label60.Name = "label60";
            // 
            // label55
            // 
            resources.ApplyResources(this.label55, "label55");
            this.label55.Name = "label55";
            // 
            // label_serial4_leakageRate
            // 
            resources.ApplyResources(this.label_serial4_leakageRate, "label_serial4_leakageRate");
            this.label_serial4_leakageRate.Name = "label_serial4_leakageRate";
            // 
            // label_serial4_fials
            // 
            resources.ApplyResources(this.label_serial4_fials, "label_serial4_fials");
            this.label_serial4_fials.Name = "label_serial4_fials";
            // 
            // label58
            // 
            resources.ApplyResources(this.label58, "label58");
            this.label58.Name = "label58";
            // 
            // button_serial4_setting
            // 
            resources.ApplyResources(this.button_serial4_setting, "button_serial4_setting");
            this.button_serial4_setting.Name = "button_serial4_setting";
            this.button_serial4_setting.UseVisualStyleBackColor = true;
            // 
            // label51
            // 
            resources.ApplyResources(this.label51, "label51");
            this.label51.Name = "label51";
            // 
            // label54
            // 
            resources.ApplyResources(this.label54, "label54");
            this.label54.Name = "label54";
            // 
            // label_sampleIndex
            // 
            resources.ApplyResources(this.label_sampleIndex, "label_sampleIndex");
            this.label_sampleIndex.Name = "label_sampleIndex";
            // 
            // panel_title
            // 
            resources.ApplyResources(this.panel_title, "panel_title");
            this.panel_title.Controls.Add(this.label_totalNGNumbers);
            this.panel_title.Controls.Add(this.label28);
            this.panel_title.Controls.Add(this.label_totalPassNumbers);
            this.panel_title.Controls.Add(this.label27);
            this.panel_title.Controls.Add(this.label_stationName);
            this.panel_title.Controls.Add(this.label26);
            this.panel_title.Controls.Add(this.label_productionModel);
            this.panel_title.Controls.Add(this.label25);
            this.panel_title.Name = "panel_title";
            this.panel_title.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_title_Paint);
            // 
            // label_totalNGNumbers
            // 
            resources.ApplyResources(this.label_totalNGNumbers, "label_totalNGNumbers");
            this.label_totalNGNumbers.Name = "label_totalNGNumbers";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label_totalPassNumbers
            // 
            resources.ApplyResources(this.label_totalPassNumbers, "label_totalPassNumbers");
            this.label_totalPassNumbers.Name = "label_totalPassNumbers";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label_stationName
            // 
            resources.ApplyResources(this.label_stationName, "label_stationName");
            this.label_stationName.Name = "label_stationName";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label_productionModel
            // 
            resources.ApplyResources(this.label_productionModel, "label_productionModel");
            this.label_productionModel.Name = "label_productionModel";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.label_sampleIndex);
            this.Controls.Add(this.panel_serial4);
            this.Controls.Add(this.panel_serial3);
            this.Controls.Add(this.panel_serial2);
            this.Controls.Add(this.panel_serial1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.load);
            this.Resize += new System.EventHandler(this.OnResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_serial1.ResumeLayout(false);
            this.panel_serial1.PerformLayout();
            this.panel_serial2.ResumeLayout(false);
            this.panel_serial2.PerformLayout();
            this.panel_serial3.ResumeLayout(false);
            this.panel_serial3.PerformLayout();
            this.panel_serial4.ResumeLayout(false);
            this.panel_serial4.PerformLayout();
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem;
        private Panel panel_serial1;
        private Panel panel_serial2;
        private Panel panel_serial3;
        private Panel panel_serial4;
        private Label label_serial1_testPressure;
        private Label label4;
        private Label label_serial1_fials;
        private Label label3;
        private Label label_serial1_testTime;
        private Label label2;
        private Button button_serial1_open;
        private Button button_serial1_setting;
        private ComboBox comboBox_serial1;
        private Label label1;
        private Label label_serial1_uploadResult;
        private Label label_serial1_testResult;
        private Label label_serial1_airLeakAgeValue;
        private Label label_serial1_leakageRate;
        private Label label_serial1_deviationPressure;
        private Label label_serial1_deviationLeakAge;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label7;
        private Label label5;
        private Label label_serial2_uploadResult;
        private Label label_serial2_airLeakAgeValue;
        private Label label_serial2_testResult;
        private Label label11;
        private ComboBox comboBox_serial2;
        private Label label_serial2_leakageRate;
        private Button button_serial2_setting;
        private Label label_serial2_deviationPressure;
        private Button button_serial2_open;
        private Label label_serial2_deviationLeakAge;
        private Label label12;
        private Label label_serial2_testPressure;
        private Label label_serial2_testTime;
        private Label label22;
        private Label label14;
        private Label label21;
        private Label label_serial2_fials;
        private Label label20;
        private Label label16;
        private Label label19;
        private Label label17;
        private Label label18;
        private Label label_serial3_uploadResult;
        private Label label_serial3_airLeakAgeValue;
        private Label label30;
        private Label label_serial3_testResult;
        private Label label31;
        private Label label45;
        private Label label32;
        private ComboBox comboBox_serial3;
        private Label label33;
        private Label label_serial3_leakageRate;
        private Label label34;
        private Button button_serial3_setting;
        private Label label_serial3_fials;
        private Label label_serial3_deviationPressure;
        private Label label36;
        private Button button_serial3_open;
        private Label label37;
        private Label label_serial3_deviationLeakAge;
        private Label label38;
        private Label label41;
        private Label label_serial3_testTime;
        private Label label_serial3_testPressure;
        private Label label_serial4_uploadResult;
        private Label label_serial4_deviationPressure;
        private Label label_serial4_airLeakAgeValue;
        private Label label_serial4_testPressure;
        private Label label65;
        private Label label_serial4_testTime;
        private Label label_serial4_testResult;
        private Label label51;
        private Label label63;
        private Label label52;
        private Label label62;
        private Label label_serial4_deviationLeakAge;
        private Label label61;
        private Label label54;
        private ComboBox comboBox_serial4;
        private Button button_serial4_open;
        private Label label60;
        private Label label55;
        private Label label_serial4_leakageRate;
        private Label label_serial4_fials;
        private Label label58;
        private Button button_serial4_setting;
        private TextBox textBox_serial1_inputSn;
        private Label label13;
        private TextBox textBox_serial2_inputSn;
        private Label label15;
        private TextBox textBox_serial3_inputSn;
        private Label label23;
        private TextBox textBox_serial4_inputSn;
        private Label label24;
        private Label label_sampleIndex;
        private Panel panel_title;
        private Label label_totalNGNumbers;
        private Label label28;
        private Label label_totalPassNumbers;
        private Label label27;
        private Label label_stationName;
        private Label label26;
        private Label label_productionModel;
        private Label label25;
        private Label label_serial1_progress;
        private ProgressBar progressBar_serial1;
        private Label label_serial2_progress;
        private ProgressBar progressBar_serial2;
        private Label label_serial3_progress;
        private ProgressBar progressBar_serial3;
        private Label label_serial4_progress;
        private ProgressBar progressBar_serial4;
        private Label label_serial1_tips;
        private Label label_serial2_tips;
        private Label label_serial3_tips;
        private Label label_serial4_tips;
        private Label label_serial1_testStatus;
        private Label label_serial2_testStatus;
        private Label label_serial3_testStatus;
        private Label label_serial4_testStatus;
    }
}

