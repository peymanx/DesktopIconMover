namespace DesktopIconMover
{
    partial class DrawForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawForm));
            this.panelArrows = new System.Windows.Forms.Panel();
            this.btnEraser = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnPen = new System.Windows.Forms.Button();
            this.ButtonLeft = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonRight = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectedColor = new System.Windows.Forms.Button();
            this.cmbIconList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClearBoom = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panelArrows.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelArrows
            // 
            this.panelArrows.Controls.Add(this.btnEraser);
            this.panelArrows.Controls.Add(this.button4);
            this.panelArrows.Controls.Add(this.btnPen);
            this.panelArrows.Controls.Add(this.ButtonLeft);
            this.panelArrows.Controls.Add(this.ButtonDown);
            this.panelArrows.Controls.Add(this.ButtonUp);
            this.panelArrows.Controls.Add(this.ButtonRight);
            this.panelArrows.Location = new System.Drawing.Point(12, 12);
            this.panelArrows.Name = "panelArrows";
            this.panelArrows.Size = new System.Drawing.Size(337, 92);
            this.panelArrows.TabIndex = 10000008;
            // 
            // btnEraser
            // 
            this.btnEraser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEraser.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.Location = new System.Drawing.Point(207, 34);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(56, 51);
            this.btnEraser.TabIndex = 10000022;
            this.btnEraser.TabStop = false;
            this.btnEraser.UseVisualStyleBackColor = false;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(283, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 23);
            this.button4.TabIndex = 10000021;
            this.button4.TabStop = false;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Minimize);
            // 
            // btnPen
            // 
            this.btnPen.BackColor = System.Drawing.Color.Gold;
            this.btnPen.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPen.Image = ((System.Drawing.Image)(resources.GetObject("btnPen.Image")));
            this.btnPen.Location = new System.Drawing.Point(268, 34);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(56, 51);
            this.btnPen.TabIndex = 5;
            this.btnPen.TabStop = false;
            this.btnPen.UseVisualStyleBackColor = false;
            this.btnPen.Click += new System.EventHandler(this.BtnPen_Clicked);
            // 
            // ButtonLeft
            // 
            this.ButtonLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonLeft.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLeft.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLeft.Image")));
            this.ButtonLeft.Location = new System.Drawing.Point(20, 45);
            this.ButtonLeft.Name = "ButtonLeft";
            this.ButtonLeft.Size = new System.Drawing.Size(36, 40);
            this.ButtonLeft.TabIndex = 4;
            this.ButtonLeft.TabStop = false;
            this.ButtonLeft.Text = "  ";
            this.ButtonLeft.UseVisualStyleBackColor = false;
            this.ButtonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonDown.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDown.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDown.Image")));
            this.ButtonDown.Location = new System.Drawing.Point(56, 45);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(36, 40);
            this.ButtonDown.TabIndex = 3;
            this.ButtonDown.TabStop = false;
            this.ButtonDown.Text = "  ";
            this.ButtonDown.UseVisualStyleBackColor = false;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // ButtonUp
            // 
            this.ButtonUp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonUp.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUp.Image = ((System.Drawing.Image)(resources.GetObject("ButtonUp.Image")));
            this.ButtonUp.Location = new System.Drawing.Point(56, 5);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(36, 40);
            this.ButtonUp.TabIndex = 2;
            this.ButtonUp.TabStop = false;
            this.ButtonUp.Text = "  ";
            this.ButtonUp.UseVisualStyleBackColor = false;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonRight
            // 
            this.ButtonRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonRight.Font = new System.Drawing.Font("Lucida Console", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRight.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRight.Image")));
            this.ButtonRight.Location = new System.Drawing.Point(93, 45);
            this.ButtonRight.Name = "ButtonRight";
            this.ButtonRight.Size = new System.Drawing.Size(36, 40);
            this.ButtonRight.TabIndex = 1;
            this.ButtonRight.TabStop = false;
            this.ButtonRight.Text = "  ";
            this.ButtonRight.UseVisualStyleBackColor = false;
            this.ButtonRight.Click += new System.EventHandler(this.ButtonRight_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(95, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 39);
            this.button1.TabIndex = 10000009;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Red_clicked);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(135, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 39);
            this.button2.TabIndex = 10000010;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Green_clicked);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(175, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 39);
            this.button3.TabIndex = 10000011;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Blue_Clicked);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(431, 189);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 29);
            this.button5.TabIndex = 10000012;
            this.button5.Text = "تنظیم تصویرزمینه";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.UpdateDesktopBackground);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Gold;
            this.button6.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(55, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 39);
            this.button6.TabIndex = 10000013;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Gold_clicked);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(215, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 39);
            this.button7.TabIndex = 10000014;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.White_Clicked);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Black;
            this.button8.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(15, 22);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(37, 39);
            this.button8.TabIndex = 10000015;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Black_Clicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(84, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 75);
            this.groupBox1.TabIndex = 10000016;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "انتخاب رنگ قلمو";
            // 
            // btnSelectedColor
            // 
            this.btnSelectedColor.BackColor = System.Drawing.Color.White;
            this.btnSelectedColor.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectedColor.ForeColor = System.Drawing.Color.White;
            this.btnSelectedColor.Location = new System.Drawing.Point(11, 120);
            this.btnSelectedColor.Name = "btnSelectedColor";
            this.btnSelectedColor.Size = new System.Drawing.Size(67, 63);
            this.btnSelectedColor.TabIndex = 10000017;
            this.btnSelectedColor.UseVisualStyleBackColor = false;
            // 
            // cmbIconList
            // 
            this.cmbIconList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIconList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIconList.FormattingEnabled = true;
            this.cmbIconList.Location = new System.Drawing.Point(493, 13);
            this.cmbIconList.Name = "cmbIconList";
            this.cmbIconList.Size = new System.Drawing.Size(152, 27);
            this.cmbIconList.TabIndex = 10000024;
            this.cmbIconList.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(547, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 10000025;
            this.label4.Text = "آیکون:";
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(547, 189);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 29);
            this.button9.TabIndex = 10000026;
            this.button9.Text = "انتخاب عکس...";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(431, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClearBoom
            // 
            this.btnClearBoom.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearBoom.Location = new System.Drawing.Point(431, 222);
            this.btnClearBoom.Name = "btnClearBoom";
            this.btnClearBoom.Size = new System.Drawing.Size(256, 29);
            this.btnClearBoom.TabIndex = 10000027;
            this.btnClearBoom.Text = "بوم سیاه";
            this.btnClearBoom.UseVisualStyleBackColor = false;
            this.btnClearBoom.Click += new System.EventHandler(this.button10_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(431, 13);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(58, 27);
            this.button10.TabIndex = 10000028;
            this.button10.Text = "reset";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 442);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnClearBoom);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.cmbIconList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectedColor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panelArrows);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DrawForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.panelArrows.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelArrows;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button ButtonLeft;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectedColor;
        private System.Windows.Forms.ComboBox cmbIconList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnClearBoom;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button button10;
    }
}