namespace DesktopIconMover
{
    partial class MarioForm
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
            this.ButtonRight = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonSpace = new System.Windows.Forms.Button();
            this.cmbIconList = new System.Windows.Forms.ComboBox();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.timerJump = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.panelArrows = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.numGround = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numJump = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timerGravity = new System.Windows.Forms.Timer(this.components);
            this.chkMario = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtDesktopPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.chkHardRefresh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.panelArrows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJump)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonRight
            // 
            this.ButtonRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonRight.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRight.Location = new System.Drawing.Point(106, 45);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(41, 40);
            this.ButtonRight.TabIndex = 1;
            this.ButtonRight.TabStop = false;
            this.ButtonRight.Text = "<";
            this.ButtonRight.UseVisualStyleBackColor = false;
            this.ButtonRight.Click += new System.EventHandler(this.ButtonRight_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonUp.Enabled = false;
            this.ButtonUp.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUp.Location = new System.Drawing.Point(64, 5);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(41, 40);
            this.ButtonUp.TabIndex = 2;
            this.ButtonUp.TabStop = false;
            this.ButtonUp.Text = "^";
            this.ButtonUp.UseVisualStyleBackColor = false;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDown.Enabled = false;
            this.ButtonDown.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDown.Location = new System.Drawing.Point(64, 45);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(41, 40);
            this.ButtonDown.TabIndex = 3;
            this.ButtonDown.TabStop = false;
            this.ButtonDown.Text = "v";
            this.ButtonDown.UseVisualStyleBackColor = false;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonLeft.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLeft.Location = new System.Drawing.Point(23, 45);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(41, 40);
            this.ButtonLeft.TabIndex = 4;
            this.ButtonLeft.TabStop = false;
            this.ButtonLeft.Text = ">";
            this.ButtonLeft.UseVisualStyleBackColor = false;
            this.ButtonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
            // 
            // ButtonSpace
            // 
            this.ButtonSpace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonSpace.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSpace.Location = new System.Drawing.Point(166, 49);
            this.ButtonSpace.Name = "ButtonSpace";
            this.ButtonSpace.Size = new System.Drawing.Size(160, 36);
            this.ButtonSpace.TabIndex = 5;
            this.ButtonSpace.TabStop = false;
            this.ButtonSpace.Text = "SPACE";
            this.ButtonSpace.UseVisualStyleBackColor = false;
            this.ButtonSpace.Click += new System.EventHandler(this.ButtonSpace_Click);
            // 
            // cmbIconList
            // 
            this.cmbIconList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIconList.Enabled = false;
            this.cmbIconList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIconList.FormattingEnabled = true;
            this.cmbIconList.Location = new System.Drawing.Point(12, 12);
            this.cmbIconList.Name = "cmbIconList";
            this.cmbIconList.Size = new System.Drawing.Size(234, 27);
            this.cmbIconList.TabIndex = 10000001;
            this.cmbIconList.TabStop = false;
            // 
            // numX
            // 
            this.numX.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numX.Location = new System.Drawing.Point(737, 170);
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
            this.numX.Size = new System.Drawing.Size(97, 32);
            this.numX.TabIndex = 10000004;
            this.numX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numX.ValueChanged += new System.EventHandler(this.numX_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(752, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 10000003;
            this.label2.Text = "x:";
            // 
            // numY
            // 
            this.numY.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numY.Location = new System.Drawing.Point(634, 170);
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
            this.numY.Size = new System.Drawing.Size(97, 32);
            this.numY.TabIndex = 10000002;
            this.numY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
            // 
            // timerJump
            // 
            this.timerJump.Interval = 3;
            this.timerJump.Tick += new System.EventHandler(this.timerJump_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(380, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 36);
            this.button2.TabIndex = 10000006;
            this.button2.TabStop = false;
            this.button2.Text = "Lock";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelArrows
            // 
            this.panelArrows.Controls.Add(this.button4);
            this.panelArrows.Controls.Add(this.ButtonSpace);
            this.panelArrows.Controls.Add(this.ButtonLeft);
            this.panelArrows.Controls.Add(this.ButtonDown);
            this.panelArrows.Controls.Add(this.ButtonUp);
            this.panelArrows.Controls.Add(this.ButtonRight);
            this.panelArrows.Location = new System.Drawing.Point(12, 45);
            this.panelArrows.Name = "panelArrows";
            this.panelArrows.Size = new System.Drawing.Size(341, 92);
            this.panelArrows.TabIndex = 10000007;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(282, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 10000021;
            this.button4.TabStop = false;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // numGround
            // 
            this.numGround.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGround.Location = new System.Drawing.Point(737, 58);
            this.numGround.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGround.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numGround.Name = "numGround";
            this.numGround.Size = new System.Drawing.Size(97, 32);
            this.numGround.TabIndex = 10000010;
            this.numGround.Value = new decimal(new int[] {
            814,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(688, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 10000009;
            this.label1.Text = "زمین:";
            // 
            // numJump
            // 
            this.numJump.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numJump.Location = new System.Drawing.Point(737, 114);
            this.numJump.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numJump.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numJump.Name = "numJump";
            this.numJump.Size = new System.Drawing.Size(97, 32);
            this.numJump.TabIndex = 10000012;
            this.numJump.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(688, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 19);
            this.label3.TabIndex = 10000011;
            this.label3.Text = "ارتفاع پرش:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(213, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 10000013;
            this.label4.Text = "کدوم آیکون باشه؟";
            // 
            // timerGravity
            // 
            this.timerGravity.Enabled = true;
            this.timerGravity.Interval = 3;
            this.timerGravity.Tick += new System.EventHandler(this.timerGravity_Tick);
            // 
            // chkMario
            // 
            this.chkMario.Checked = true;
            this.chkMario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMario.Location = new System.Drawing.Point(151, 26);
            this.chkMario.Name = "chkMario";
            this.chkMario.Size = new System.Drawing.Size(168, 23);
            this.chkMario.TabIndex = 10000014;
            this.chkMario.Text = "ایجاد پیوسته تصویر ماریو";
            this.chkMario.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(649, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 10000015;
            this.label5.Text = "y:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(166, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 33);
            this.button1.TabIndex = 10000016;
            this.button1.TabStop = false;
            this.button1.Text = "تنظیم تصویر زمینه";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.chkMario);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(380, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 112);
            this.groupBox1.TabIndex = 10000017;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "درون ریزی بازی";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(15, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 33);
            this.button3.TabIndex = 10000017;
            this.button3.TabStop = false;
            this.button3.Text = "ساخت گومبا";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtDesktopPath
            // 
            this.txtDesktopPath.Enabled = false;
            this.txtDesktopPath.Location = new System.Drawing.Point(546, 10);
            this.txtDesktopPath.Name = "txtDesktopPath";
            this.txtDesktopPath.Size = new System.Drawing.Size(288, 23);
            this.txtDesktopPath.TabIndex = 10000018;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(380, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(160, 36);
            this.btnBrowse.TabIndex = 10000019;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.Text = "تنظیم مسیر دسکتاپ...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(15, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 33);
            this.button5.TabIndex = 10000018;
            this.button5.TabStop = false;
            this.button5.Text = "ساخت لاکپشت";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chkHardRefresh
            // 
            this.chkHardRefresh.Location = new System.Drawing.Point(197, 187);
            this.chkHardRefresh.Name = "chkHardRefresh";
            this.chkHardRefresh.Size = new System.Drawing.Size(156, 22);
            this.chkHardRefresh.TabIndex = 10000022;
            this.chkHardRefresh.Text = "ریفرش هارد";
            this.chkHardRefresh.UseVisualStyleBackColor = true;
            // 
            // MarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 221);
            this.Controls.Add(this.chkHardRefresh);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDesktopPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbIconList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numJump);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numGround);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelArrows);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.numY);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MarioForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ماریو";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MarioForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MarioForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MarioForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.panelArrows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJump)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonSpace;
        private System.Windows.Forms.ComboBox cmbIconList;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Timer timerJump;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelArrows;
        private System.Windows.Forms.NumericUpDown numGround;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numJump;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerGravity;
        private System.Windows.Forms.CheckBox chkMario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtDesktopPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chkHardRefresh;
    }
}