namespace DesktopIconMover
{
    partial class MainForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 24);
            this.comboBox1.TabIndex = 10000000;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "کدوم آیکون باشه؟";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 68);
            this.button1.TabIndex = 2;
            this.button1.Text = "برو به این نقطه:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGo);
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(403, 121);
            this.numY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(76, 23);
            this.numY.TabIndex = 3;
            this.numY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "اکس و ایگرگ:";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(402, 94);
            this.numX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(76, 23);
            this.numX.TabIndex = 5;
            this.numX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numX.ValueChanged += new System.EventHandler(this.numX_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "دوباره";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonUp.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUp.Location = new System.Drawing.Point(71, 10);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(53, 52);
            this.ButtonUp.TabIndex = 2;
            this.ButtonUp.Text = "^";
            this.ButtonUp.UseVisualStyleBackColor = false;
            this.ButtonUp.Click += new System.EventHandler(this.btnUp);
            // 
            // ButtonRight
            // 
            this.ButtonRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonRight.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRight.Location = new System.Drawing.Point(125, 35);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(53, 52);
            this.ButtonRight.TabIndex = 1;
            this.ButtonRight.Text = "<";
            this.ButtonRight.UseVisualStyleBackColor = false;
            this.ButtonRight.Click += new System.EventHandler(this.btnRight);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonLeft.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLeft.Location = new System.Drawing.Point(17, 34);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(53, 52);
            this.ButtonLeft.TabIndex = 4;
            this.ButtonLeft.Text = ">";
            this.ButtonLeft.UseVisualStyleBackColor = false;
            this.ButtonLeft.Click += new System.EventHandler(this.btnLeft);
            // 
            // ButtonDown
            // 
            this.ButtonDown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonDown.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDown.Location = new System.Drawing.Point(71, 61);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(53, 52);
            this.ButtonDown.TabIndex = 3;
            this.ButtonDown.Text = "v";
            this.ButtonDown.UseVisualStyleBackColor = false;
            this.ButtonDown.Click += new System.EventHandler(this.btnDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(86, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(199, 20);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "ماوس رو تعقیب کن";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(86, 186);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(199, 20);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "قفل کن و حرکت آخر رو تکرار کن";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonRight);
            this.panel1.Controls.Add(this.ButtonUp);
            this.panel1.Controls.Add(this.ButtonLeft);
            this.panel1.Controls.Add(this.ButtonDown);
            this.panel1.Location = new System.Drawing.Point(60, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 124);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 229);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(308, 26);
            this.statusStrip1.TabIndex = 10000001;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel1.Text = "@peymanx";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 255);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "آیکون دسکتاپ ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}