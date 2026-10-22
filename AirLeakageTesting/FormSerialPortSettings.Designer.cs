namespace AirLeakageTesting
{
    partial class FormSerialPortSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_serialPort = new System.Windows.Forms.Label();
            this.comboBox_serialPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_StopBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_DataBit = new System.Windows.Forms.ComboBox();
            this.comboBox_ParityCheck = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_serialPort
            // 
            this.label_serialPort.AutoSize = true;
            this.label_serialPort.Location = new System.Drawing.Point(47, 29);
            this.label_serialPort.Name = "label_serialPort";
            this.label_serialPort.Size = new System.Drawing.Size(95, 12);
            this.label_serialPort.TabIndex = 0;
            this.label_serialPort.Text = "第1通道串口号：";
            // 
            // comboBox_serialPort
            // 
            this.comboBox_serialPort.FormattingEnabled = true;
            this.comboBox_serialPort.Location = new System.Drawing.Point(146, 25);
            this.comboBox_serialPort.Name = "comboBox_serialPort";
            this.comboBox_serialPort.Size = new System.Drawing.Size(73, 20);
            this.comboBox_serialPort.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_StopBit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_DataBit);
            this.groupBox1.Controls.Add(this.comboBox_ParityCheck);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_BaudRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(49, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 114);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // comboBox_StopBit
            // 
            this.comboBox_StopBit.FormattingEnabled = true;
            this.comboBox_StopBit.Location = new System.Drawing.Point(295, 65);
            this.comboBox_StopBit.Name = "comboBox_StopBit";
            this.comboBox_StopBit.Size = new System.Drawing.Size(87, 20);
            this.comboBox_StopBit.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "停止位：";
            // 
            // comboBox_DataBit
            // 
            this.comboBox_DataBit.FormattingEnabled = true;
            this.comboBox_DataBit.Location = new System.Drawing.Point(83, 65);
            this.comboBox_DataBit.Name = "comboBox_DataBit";
            this.comboBox_DataBit.Size = new System.Drawing.Size(87, 20);
            this.comboBox_DataBit.TabIndex = 1;
            // 
            // comboBox_ParityCheck
            // 
            this.comboBox_ParityCheck.FormattingEnabled = true;
            this.comboBox_ParityCheck.Location = new System.Drawing.Point(295, 28);
            this.comboBox_ParityCheck.Name = "comboBox_ParityCheck";
            this.comboBox_ParityCheck.Size = new System.Drawing.Size(87, 20);
            this.comboBox_ParityCheck.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "奇偶校验：";
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Location = new System.Drawing.Point(83, 28);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(87, 20);
            this.comboBox_BaudRate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "波特率：";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(214, 214);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(119, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "保存";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // FormSerialPortSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 272);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_serialPort);
            this.Controls.Add(this.label_serialPort);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSerialPortSettings";
            this.Text = "串口配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_serialPort;
        private System.Windows.Forms.ComboBox comboBox_serialPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_DataBit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_StopBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_ParityCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_ok;
    }
}