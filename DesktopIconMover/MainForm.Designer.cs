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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmbIconList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.ButtonReload = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerTarget = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIconList
            // 
            this.cmbIconList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIconList.FormattingEnabled = true;
            this.cmbIconList.Location = new System.Drawing.Point(53, 21);
            this.cmbIconList.Name = "cmbIconList";
            this.cmbIconList.Size = new System.Drawing.Size(192, 24);
            this.cmbIconList.TabIndex = 10000000;
            this.cmbIconList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "کدوم آیکون باشه؟";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(357, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 99);
            this.button1.TabIndex = 2;
            this.button1.Text = "برو به این نقطه:";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnGo);
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(263, 103);
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
            this.label2.Location = new System.Drawing.Point(263, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "اکس و ایگرگ:";
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(262, 76);
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
            // ButtonReload
            // 
            this.ButtonReload.Location = new System.Drawing.Point(5, 16);
            this.ButtonReload.Name = "ButtonReload";
            this.ButtonReload.Size = new System.Drawing.Size(46, 27);
            this.ButtonReload.TabIndex = 6;
            this.ButtonReload.Text = "دوباره";
            this.ButtonReload.UseVisualStyleBackColor = true;
            this.ButtonReload.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonUp.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUp.Location = new System.Drawing.Point(71, 6);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(43, 41);
            this.ButtonUp.TabIndex = 2;
            this.ButtonUp.Text = "^";
            this.ButtonUp.UseVisualStyleBackColor = false;
            this.ButtonUp.Click += new System.EventHandler(this.btnUp);
            // 
            // ButtonRight
            // 
            this.ButtonRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonRight.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRight.Location = new System.Drawing.Point(120, 30);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(43, 41);
            this.ButtonRight.TabIndex = 1;
            this.ButtonRight.Text = "<";
            this.ButtonRight.UseVisualStyleBackColor = false;
            this.ButtonRight.Click += new System.EventHandler(this.btnRight);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonLeft.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLeft.Location = new System.Drawing.Point(22, 30);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(43, 41);
            this.ButtonLeft.TabIndex = 4;
            this.ButtonLeft.Text = ">";
            this.ButtonLeft.UseVisualStyleBackColor = false;
            this.ButtonLeft.Click += new System.EventHandler(this.btnLeft);
            // 
            // ButtonDown
            // 
            this.ButtonDown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDown.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDown.Location = new System.Drawing.Point(71, 53);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(43, 41);
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
            // chkLock
            // 
            this.chkLock.Location = new System.Drawing.Point(65, 150);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(176, 20);
            this.chkLock.TabIndex = 13;
            this.chkLock.Text = "روی حرکت آخر قفل کن";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ButtonRight);
            this.panel1.Controls.Add(this.ButtonUp);
            this.panel1.Controls.Add(this.ButtonLeft);
            this.panel1.Controls.Add(this.ButtonDown);
            this.panel1.Location = new System.Drawing.Point(31, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 99);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 173);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(256, 26);
            this.statusStrip1.TabIndex = 10000001;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel1.Text = "@peymanx";
            // 
            // timerTarget
            // 
            this.timerTarget.Tick += new System.EventHandler(this.timerTarget_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(459, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10000002;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 199);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.ButtonReload);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbIconList);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIconList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Button ButtonReload;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timerTarget;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}