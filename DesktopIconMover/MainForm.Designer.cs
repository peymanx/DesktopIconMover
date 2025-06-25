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
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.ButtonReload = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.panelArrowKeys = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMario = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnPacman = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.panelArrowKeys.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIconList
            // 
            this.cmbIconList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIconList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIconList.FormattingEnabled = true;
            this.cmbIconList.Location = new System.Drawing.Point(15, 24);
            this.cmbIconList.Name = "cmbIconList";
            this.cmbIconList.Size = new System.Drawing.Size(237, 27);
            this.cmbIconList.TabIndex = 10000000;
            this.cmbIconList.TabStop = false;
            this.cmbIconList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numY
            // 
            this.numY.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numY.Location = new System.Drawing.Point(87, 79);
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
            this.numY.Size = new System.Drawing.Size(76, 32);
            this.numY.TabIndex = 3;
            this.numY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
            // 
            // numX
            // 
            this.numX.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numX.Location = new System.Drawing.Point(176, 79);
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
            this.numX.Size = new System.Drawing.Size(76, 32);
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
            this.ButtonReload.Location = new System.Drawing.Point(15, 59);
            this.ButtonReload.Name = "ButtonReload";
            this.ButtonReload.Size = new System.Drawing.Size(66, 57);
            this.ButtonReload.TabIndex = 6;
            this.ButtonReload.Text = "Refresh";
            this.ButtonReload.UseVisualStyleBackColor = true;
            this.ButtonReload.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonUp.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUp.Location = new System.Drawing.Point(59, 3);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(47, 40);
            this.ButtonUp.TabIndex = 2;
            this.ButtonUp.TabStop = false;
            this.ButtonUp.Text = "^";
            this.ButtonUp.UseVisualStyleBackColor = false;
            this.ButtonUp.Click += new System.EventHandler(this.btnUp);
            // 
            // ButtonRight
            // 
            this.ButtonRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonRight.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRight.Location = new System.Drawing.Point(106, 43);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(47, 40);
            this.ButtonRight.TabIndex = 1;
            this.ButtonRight.TabStop = false;
            this.ButtonRight.Text = "<";
            this.ButtonRight.UseVisualStyleBackColor = false;
            this.ButtonRight.Click += new System.EventHandler(this.btnRight);
            this.ButtonRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonRight_MouseClick);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonLeft.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLeft.Location = new System.Drawing.Point(12, 43);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(47, 40);
            this.ButtonLeft.TabIndex = 4;
            this.ButtonLeft.TabStop = false;
            this.ButtonLeft.Text = ">";
            this.ButtonLeft.UseVisualStyleBackColor = false;
            this.ButtonLeft.Click += new System.EventHandler(this.btnLeft);
            // 
            // ButtonDown
            // 
            this.ButtonDown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDown.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDown.Location = new System.Drawing.Point(59, 43);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(47, 40);
            this.ButtonDown.TabIndex = 3;
            this.ButtonDown.TabStop = false;
            this.ButtonDown.Text = "v";
            this.ButtonDown.UseVisualStyleBackColor = false;
            this.ButtonDown.Click += new System.EventHandler(this.btnDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkLock
            // 
            this.chkLock.Location = new System.Drawing.Point(641, 143);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(156, 22);
            this.chkLock.TabIndex = 13;
            this.chkLock.Text = "روی حرکت آخر قفل کن";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panelArrowKeys
            // 
            this.panelArrowKeys.BackColor = System.Drawing.SystemColors.Control;
            this.panelArrowKeys.Controls.Add(this.ButtonRight);
            this.panelArrowKeys.Controls.Add(this.ButtonUp);
            this.panelArrowKeys.Controls.Add(this.ButtonDown);
            this.panelArrowKeys.Controls.Add(this.ButtonLeft);
            this.panelArrowKeys.Location = new System.Drawing.Point(58, 6);
            this.panelArrowKeys.Name = "panelArrowKeys";
            this.panelArrowKeys.Size = new System.Drawing.Size(171, 84);
            this.panelArrowKeys.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 227);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(811, 26);
            this.statusStrip1.TabIndex = 10000001;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel1.Text = "@peymanx";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(530, 163);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar1.Size = new System.Drawing.Size(274, 56);
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TabIndex = 10000003;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(550, 192);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(55, 29);
            this.lblSpeed.TabIndex = 10000005;
            this.lblSpeed.Text = "200";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(82, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 10000017;
            this.label5.Text = "y:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(164, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 10000016;
            this.label2.Text = "x:";
            // 
            // btnMario
            // 
            this.btnMario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMario.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMario.Image = ((System.Drawing.Image)(resources.GetObject("btnMario.Image")));
            this.btnMario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMario.Location = new System.Drawing.Point(316, 12);
            this.btnMario.Name = "btnMario";
            this.btnMario.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMario.Size = new System.Drawing.Size(206, 56);
            this.btnMario.TabIndex = 10000018;
            this.btnMario.TabStop = false;
            this.btnMario.Text = "بازی سوپرماریو";
            this.btnMario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMario.UseVisualStyleBackColor = false;
            this.btnMario.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(248, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 34);
            this.button3.TabIndex = 10000020;
            this.button3.TabStop = false;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Minimize);
            // 
            // btnPacman
            // 
            this.btnPacman.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPacman.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacman.Image = ((System.Drawing.Image)(resources.GetObject("btnPacman.Image")));
            this.btnPacman.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPacman.Location = new System.Drawing.Point(316, 77);
            this.btnPacman.Name = "btnPacman";
            this.btnPacman.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnPacman.Size = new System.Drawing.Size(206, 56);
            this.btnPacman.TabIndex = 10000021;
            this.btnPacman.TabStop = false;
            this.btnPacman.Text = "بازی پک-من";
            this.btnPacman.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacman.UseVisualStyleBackColor = false;
            this.btnPacman.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // btnPaint
            // 
            this.btnPaint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaint.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaint.Image = ((System.Drawing.Image)(resources.GetObject("btnPaint.Image")));
            this.btnPaint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaint.Location = new System.Drawing.Point(316, 141);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnPaint.Size = new System.Drawing.Size(206, 56);
            this.btnPaint.TabIndex = 10000022;
            this.btnPaint.TabStop = false;
            this.btnPaint.Text = "نقاشی روی دسکتاپ";
            this.btnPaint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaint.UseVisualStyleBackColor = false;
            this.btnPaint.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numX);
            this.groupBox1.Controls.Add(this.numY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ButtonReload);
            this.groupBox1.Controls.Add(this.cmbIconList);
            this.groupBox1.Location = new System.Drawing.Point(539, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 123);
            this.groupBox1.TabIndex = 10000023;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "پارامترها";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(91, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10000024;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(811, 253);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPaint);
            this.Controls.Add(this.btnPacman);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnMario);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.panelArrowKeys);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.panelArrowKeys.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIconList;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Button ButtonReload;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Panel panelArrowKeys;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMario;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnPacman;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}