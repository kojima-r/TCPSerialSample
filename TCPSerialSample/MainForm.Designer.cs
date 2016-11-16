namespace TCPSerialSample
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxTextCmd = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.labelHost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Joystick_timer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelSerialStatus = new System.Windows.Forms.Label();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.textBoxBaud = new System.Windows.Forms.TextBox();
            this.buttonPortOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerStatusCheck = new System.Windows.Forms.Timer(this.components);
            this.buttonLogClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(18, 19);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "送信";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxTextCmd
            // 
            this.textBoxTextCmd.Location = new System.Drawing.Point(99, 19);
            this.textBoxTextCmd.Name = "textBoxTextCmd";
            this.textBoxTextCmd.Size = new System.Drawing.Size(273, 19);
            this.textBoxTextCmd.TabIndex = 1;
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(81, 18);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(100, 19);
            this.textBoxHost.TabIndex = 2;
            this.textBoxHost.Text = "192.168.12.78";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(24, 24);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(29, 12);
            this.labelHost.TabIndex = 3;
            this.labelHost.Text = "Host";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(83, 50);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(43, 19);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Text = "5000";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(204, 16);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "接続";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(204, 48);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(90, 19);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "状態：Close";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(406, 18);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(178, 449);
            this.textBoxLog.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelHost);
            this.groupBox1.Controls.Add(this.textBoxHost);
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(14, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 76);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSend);
            this.groupBox2.Controls.Add(this.textBoxTextCmd);
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 79);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command";
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(261, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 16);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Joystick";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Joystick_timer
            // 
            this.Joystick_timer.Enabled = true;
            this.Joystick_timer.Tick += new System.EventHandler(this.Joystick_timer_Tick);
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.label10);
            this.groupBoxSerial.Controls.Add(this.label9);
            this.groupBoxSerial.Controls.Add(this.labelSerialStatus);
            this.groupBoxSerial.Controls.Add(this.comboBoxSerialPort);
            this.groupBoxSerial.Controls.Add(this.textBoxBaud);
            this.groupBoxSerial.Controls.Add(this.buttonPortOpen);
            this.groupBoxSerial.Controls.Add(this.buttonClose);
            this.groupBoxSerial.Location = new System.Drawing.Point(12, 102);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(372, 66);
            this.groupBoxSerial.TabIndex = 48;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "シリアル";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "ボーレート";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "ポート";
            // 
            // labelSerialStatus
            // 
            this.labelSerialStatus.AutoSize = true;
            this.labelSerialStatus.Location = new System.Drawing.Point(204, 47);
            this.labelSerialStatus.Name = "labelSerialStatus";
            this.labelSerialStatus.Size = new System.Drawing.Size(64, 12);
            this.labelSerialStatus.TabIndex = 28;
            this.labelSerialStatus.Text = "状態：Close";
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(64, 13);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(97, 20);
            this.comboBoxSerialPort.TabIndex = 0;
            // 
            // textBoxBaud
            // 
            this.textBoxBaud.Location = new System.Drawing.Point(64, 39);
            this.textBoxBaud.Name = "textBoxBaud";
            this.textBoxBaud.Size = new System.Drawing.Size(100, 19);
            this.textBoxBaud.TabIndex = 1;
            this.textBoxBaud.Text = "230400";
            // 
            // buttonPortOpen
            // 
            this.buttonPortOpen.Location = new System.Drawing.Point(191, 15);
            this.buttonPortOpen.Name = "buttonPortOpen";
            this.buttonPortOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonPortOpen.TabIndex = 8;
            this.buttonPortOpen.Text = "接続";
            this.buttonPortOpen.UseVisualStyleBackColor = true;
            this.buttonPortOpen.Click += new System.EventHandler(this.buttonPortOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(274, 15);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "切断";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timerStatusCheck
            // 
            this.timerStatusCheck.Enabled = true;
            this.timerStatusCheck.Tick += new System.EventHandler(this.timerStatusCheck_Tick);
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Location = new System.Drawing.Point(406, 484);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(178, 30);
            this.buttonLogClear.TabIndex = 49;
            this.buttonLogClear.Text = "クリア";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            this.buttonLogClear.Click += new System.EventHandler(this.buttonLogClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 541);
            this.Controls.Add(this.buttonLogClear);
            this.Controls.Add(this.groupBoxSerial);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxLog);
            this.Name = "MainForm";
            this.Text = "Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxTextCmd;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer Joystick_timer;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelSerialStatus;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.TextBox textBoxBaud;
        private System.Windows.Forms.Button buttonPortOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timerStatusCheck;
        private System.Windows.Forms.Button buttonLogClear;
    }
}

