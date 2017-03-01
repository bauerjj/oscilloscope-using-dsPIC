namespace Osciloscop
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TriggerTrackbar = new System.Windows.Forms.TrackBar();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.SlopeLink = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HorizScale = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.XValMinus = new System.Windows.Forms.Button();
            this.XValPluss = new System.Windows.Forms.Button();
            this.COMConnectBtn = new System.Windows.Forms.Button();
            this.COMPorts = new System.Windows.Forms.ComboBox();
            this.SnapshotTimer = new System.Windows.Forms.Timer(this.components);
            this.serialTimer = new System.Windows.Forms.Timer(this.components);
            this.InterfaceTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerTrackbar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HorizScale)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.Interval = 100D;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.Interval = 1000D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.Maximum = 1599D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.Interval = 25D;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Title = "Samples";
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.Maximum = 1599D;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.Maximum = 260D;
            chartArea1.AxisY.Minimum = -5D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.Maximum = 260D;
            chartArea1.AxisY2.Minimum = -5D;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(63, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.IsVisibleInLegend = false;
            series1.LabelAngle = 90;
            series1.Name = "ValueLine";
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Yellow;
            series2.Name = "TriggerLine";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(986, 414);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // TriggerTrackbar
            // 
            this.TriggerTrackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TriggerTrackbar.Location = new System.Drawing.Point(12, 41);
            this.TriggerTrackbar.Maximum = 255;
            this.TriggerTrackbar.Name = "TriggerTrackbar";
            this.TriggerTrackbar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TriggerTrackbar.Size = new System.Drawing.Size(45, 360);
            this.TriggerTrackbar.TabIndex = 1;
            this.TriggerTrackbar.ValueChanged += new System.EventHandler(this.TriggerTrackbar_ValueChanged);
            // 
            // serialPort
            // 
            this.serialPort.ReadBufferSize = 2000;
            this.serialPort.ReadTimeout = 50;
            // 
            // SlopeLink
            // 
            this.SlopeLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SlopeLink.AutoSize = true;
            this.SlopeLink.Location = new System.Drawing.Point(9, 12);
            this.SlopeLink.Name = "SlopeLink";
            this.SlopeLink.Size = new System.Drawing.Size(44, 13);
            this.SlopeLink.TabIndex = 2;
            this.SlopeLink.TabStop = true;
            this.SlopeLink.Text = "Positive";
            this.SlopeLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SlopeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SlopeLink_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.HorizScale);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.XValMinus);
            this.groupBox1.Controls.Add(this.XValPluss);
            this.groupBox1.Controls.Add(this.COMConnectBtn);
            this.groupBox1.Controls.Add(this.COMPorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // HorizScale
            // 
            this.HorizScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HorizScale.AutoSize = false;
            this.HorizScale.Location = new System.Drawing.Point(357, 14);
            this.HorizScale.Maximum = 1599;
            this.HorizScale.Minimum = 10;
            this.HorizScale.Name = "HorizScale";
            this.HorizScale.Size = new System.Drawing.Size(487, 30);
            this.HorizScale.TabIndex = 10;
            this.HorizScale.Value = 1599;
            this.HorizScale.ValueChanged += new System.EventHandler(this.HorizScale_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(850, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vertical";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Samples / Sec";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(932, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(996, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(898, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // XValMinus
            // 
            this.XValMinus.Location = new System.Drawing.Point(323, 19);
            this.XValMinus.Name = "XValMinus";
            this.XValMinus.Size = new System.Drawing.Size(28, 23);
            this.XValMinus.TabIndex = 3;
            this.XValMinus.Text = "-";
            this.XValMinus.UseVisualStyleBackColor = true;
            this.XValMinus.Click += new System.EventHandler(this.XValMinus_Click);
            // 
            // XValPluss
            // 
            this.XValPluss.Location = new System.Drawing.Point(289, 19);
            this.XValPluss.Name = "XValPluss";
            this.XValPluss.Size = new System.Drawing.Size(28, 23);
            this.XValPluss.TabIndex = 2;
            this.XValPluss.Text = "+";
            this.XValPluss.UseVisualStyleBackColor = true;
            this.XValPluss.Click += new System.EventHandler(this.XValPlus_Click);
            // 
            // COMConnectBtn
            // 
            this.COMConnectBtn.Location = new System.Drawing.Point(112, 23);
            this.COMConnectBtn.Name = "COMConnectBtn";
            this.COMConnectBtn.Size = new System.Drawing.Size(80, 21);
            this.COMConnectBtn.TabIndex = 1;
            this.COMConnectBtn.Text = "Connect";
            this.COMConnectBtn.UseVisualStyleBackColor = true;
            this.COMConnectBtn.Click += new System.EventHandler(this.COMConnectBtn_Click);
            // 
            // COMPorts
            // 
            this.COMPorts.FormattingEnabled = true;
            this.COMPorts.Location = new System.Drawing.Point(6, 23);
            this.COMPorts.Name = "COMPorts";
            this.COMPorts.Size = new System.Drawing.Size(100, 21);
            this.COMPorts.TabIndex = 0;
            // 
            // SnapshotTimer
            // 
            this.SnapshotTimer.Interval = 800;
            this.SnapshotTimer.Tick += new System.EventHandler(this.SnapshotTimer_Tick);
            // 
            // serialTimer
            // 
            this.serialTimer.Enabled = true;
            this.serialTimer.Interval = 200;
            this.serialTimer.Tick += new System.EventHandler(this.serialTimer_Tick);
            // 
            // InterfaceTimer
            // 
            this.InterfaceTimer.Enabled = true;
            this.InterfaceTimer.Interval = 500;
            this.InterfaceTimer.Tick += new System.EventHandler(this.InterfaceTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SlopeLink);
            this.Controls.Add(this.TriggerTrackbar);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Osciloscop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerTrackbar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HorizScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TrackBar TriggerTrackbar;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.LinkLabel SlopeLink;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button XValMinus;
        private System.Windows.Forms.Button XValPluss;
        private System.Windows.Forms.Button COMConnectBtn;
        private System.Windows.Forms.ComboBox COMPorts;
        private System.Windows.Forms.Timer SnapshotTimer;
        private System.Windows.Forms.Timer serialTimer;
        private System.Windows.Forms.Timer InterfaceTimer;
        private System.Windows.Forms.TrackBar HorizScale;
    }
}

