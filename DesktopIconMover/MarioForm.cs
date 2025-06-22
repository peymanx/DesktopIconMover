using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopIconMover
{
    public partial class MarioForm : Form
    {
        public MarioForm()
        {
            InitializeComponent();
            LoadDesktopIcons();

        }




        public int Step { get; set; } = 10;
        public string MarioPath { get; set; }

        public int Target { get; set; }
        private readonly List<string> iconNames = new List<string>();

        public enum Direction { Up, Left, Right, Down, Null };

        public Direction Dir { get; set; } = Direction.Null;




        private void LoadDesktopIcons()
        {
            cmbIconList.Items.Clear();

            IntPtr hwndListView = WindowsAPI.GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int count = WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_GETITEMCOUNT, 0, IntPtr.Zero);
            StringBuilder itemText = new StringBuilder(256);

            for (int i = 0; i < count; i++)
            {
                // SendMessage2(hwndListView, LVM_GETITEMTEXT, (IntPtr)i, itemText);
                string iconName = "آیکون شماره " + i;
                iconNames.Add(iconName);
            }


            cmbIconList.Items.AddRange(iconNames.ToArray());

            cmbIconList.SelectedIndex = iconNames.Count - 1;
        }
        public static void MoveIconRelative(int iconIndex, int dx, int dy)
        {
            IntPtr hwndListView = WindowsAPI.GetDesktopListView();
            if (hwndListView == IntPtr.Zero) return;

            int posData = WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_GETITEMPOSITION, iconIndex, IntPtr.Zero);

            int currentX = posData & 0xFFFF;
            int currentY = (posData >> 16) & 0xFFFF;

            int newX = currentX + dx;
            int newY = currentY + dy;

            IntPtr lParam = (IntPtr)((newY << 16) | (newX & 0xFFFF));
            WindowsAPI.SendMessage(hwndListView, WindowsAPI.LVM_SETITEMPOSITION, (IntPtr)iconIndex, lParam);

            Console.WriteLine($"آیکون {iconIndex} به مکان جدید ({newX}, {newY}) منتقل شد.");
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }






        private void ResetArrowButtonColor()
        {
            ButtonRight.BackColor = Color.WhiteSmoke;
            ButtonLeft.BackColor = Color.WhiteSmoke;
            ButtonUp.BackColor = Color.WhiteSmoke;
            ButtonDown.BackColor = Color.WhiteSmoke;
            ButtonSpace.BackColor = Color.WhiteSmoke;
            panelArrows.Focus();
        }




        private void MarioForm_KeyUp(object sender, KeyEventArgs e)
        {



        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Left)
                ButtonLeft_Click(null, null);

            else if (keyData == Keys.Right)
                ButtonRight_Click(null, null);

            else if (keyData == Keys.Space)
            {

                ButtonSpace_Click(null, null);

            }


            panelArrows.Focus();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MarioForm_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {

        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            numX.Value -= Step;
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);
            if (Dir != Direction.Left)
            {
                Dir = Direction.Left;
                if (chkMario.Checked)
                {
                    Properties.Resources.mario_left.Save(MarioPath);
                    if (chkHardRefresh.Checked)
                        DesktopRefresher.HardRefresh();
                    else
                        DesktopRefresher.RefreshDesktop();
                }

                ResetArrowButtonColor();
                ButtonLeft.BackColor = Color.Gold;
            }
            panelArrows.Focus();


        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            numX.Value += Step;

            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            if (Dir != Direction.Right)
            {
                Dir = Direction.Right;
                if (chkMario.Checked)
                {
                    Properties.Resources.mario_right.Save(MarioPath);
                    if (chkHardRefresh.Checked)
                        DesktopRefresher.HardRefresh();
                    else
                        DesktopRefresher.RefreshDesktop();

                }

                ResetArrowButtonColor();
                ButtonRight.BackColor = Color.Gold;
                ButtonRight.Focus();
            }
            panelArrows.Focus();

        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

        }

        private void MarioForm_Load(object sender, EventArgs e)
        {
            numY.Value = numGround.Value;
            txtDesktopPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            MarioPath = Path.Combine(txtDesktopPath.Text, "mario.png");
            button4_Click_2(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbIconList.Enabled = !cmbIconList.Enabled;
        }

        private void ButtonSpace_Click(object sender, EventArgs e)
        {




            if (numY.Value == numGround.Value)
            {
                panelArrows.Focus();

                ResetArrowButtonColor();
                ButtonSpace.BackColor = Color.Gold;
                Target = (int)numY.Value - (int)numJump.Value;
                if (chkMario.Checked)
                {
                    if (Dir == Direction.Right)
                        Properties.Resources.mario_jump_right.Save(MarioPath);
                    else if (Dir == Direction.Left)
                        Properties.Resources.mario_jump_left.Save(MarioPath);
                    else
                        Properties.Resources.mario_jump_right.Save(MarioPath);
                }

                timerJump.Enabled = true;

                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();

            }

        }

        private void timerJump_Tick(object sender, EventArgs e)
        {


            numY.Value -= 5;
            if (numY.Value < Target) // jump ended - grounded
            {
                timerJump.Enabled = false;
                Target = (int)numY.Value + (int)numJump.Value;

                if (chkMario.Checked)
                {
                    if (Dir == Direction.Right)
                        Properties.Resources.mario_right.Save(MarioPath);
                    else if (Dir == Direction.Left)
                        Properties.Resources.mario_left.Save(MarioPath);
                    else
                        Properties.Resources.mario_right.Save(MarioPath);
                }

            }


        }

        private void timerGravity_Tick(object sender, EventArgs e)
        {
            if (numY.Value < numGround.Value && !timerJump.Enabled)
            {
                numY.Value += 6;
                panelArrows.Focus();
                MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);

            }

            if (numY.Value > numGround.Value)
            {
                numY.Value = numGround.Value;
                panelArrows.Focus();
                MoveIconRelative(cmbIconList.SelectedIndex, (int)numX.Value, (int)numY.Value);



                if (chkHardRefresh.Checked)
                    DesktopRefresher.HardRefresh();
                else
                    DesktopRefresher.RefreshDesktop();
            }


        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wallpaper.Set(Properties.Resources.supermario_wallpaper01, Wallpaper.Style.Stretched);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var open = new FolderBrowserDialog();
            if (open.ShowDialog() == DialogResult.OK)
                txtDesktopPath.Text = open.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var randomName = $"goomba_{new Random().Next(1111, 9999)}.png";
            Properties.Resources.goomba.Save(Path.Combine(txtDesktopPath.Text, randomName));
            if (chkHardRefresh.Checked)
                DesktopRefresher.HardRefresh();
            else
                DesktopRefresher.RefreshDesktop();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            WindowsAPI.MoveIconRelative(0, 100, 0);
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (button4.Text == "<<")
            {
                this.Width = 864;
                this.Height = 268;
                button4.Text = ">>";
            }
            else
            {
                this.Width = 382;
                this.Height = 198;
                button4.Text = "<<";

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var rand = new Random().Next(1111, 9999);
            var randomName = $"koopa_{rand}.png";
            if (rand % 2 == 0)
                Properties.Resources.koopa_red.Save(Path.Combine(txtDesktopPath.Text, randomName));
            else
                Properties.Resources.koopa_green.Save(Path.Combine(txtDesktopPath.Text, randomName));

            if (chkHardRefresh.Checked)
                DesktopRefresher.HardRefresh();
            else
                DesktopRefresher.RefreshDesktop();

        }
    }
}
