using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS3Lib;

namespace Project_Far_Cry_4_Private
{
    public partial class Form1 : Form
    {
        public static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        //
        private byte[] byteGodOn = new byte[] { 0xd0, 0x43, 0, 0x10 };
        private byte[] byteGodOff = new byte[] { 0x48, 0x04, };
        //
        private byte[] byteMunOn = new byte[] { 0x7c, 0xa4, 0x2b, 120 };
        private byte[] byteMunOff = new byte[] { 0x7c, 0x9f, 40, 0x10 };
        private byte[] byteMunOff2 = new byte[] { 0x7c, 0x9f, 0x20, 0x10 };
        //
        private byte[] byteMoneyOn1 = new byte[] { 60, 0xc0, 0x3b, 0x9a };
        private byte[] byteMoneyOn2 = new byte[] { 0x60, 0xc6, 0xc9, 0xff };
        //
        private byte[] byteXP100 = new byte[] { 0x1f, 0xc4, 0, 100 };
        private byte[] byteXP1000 = new byte[] { 0x1f, 0xc4, 3, 0xe8 };
        //
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PS3.DisconnectTarget();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PS3.ConnectTarget())
            {
                MessageBox.Show("Connected");
                notConnectedToolStripMenuItem.Text = "Connected";
                notConnectedToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MessageBox.Show("Cant Connect");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PS3.AttachProcess())
            {
                MessageBox.Show("Attached");
                idleToolStripMenuItem.Text = "Attached";
                idleToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MessageBox.Show("Cant Attached Process");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PS3.SetMemory(0x4d21d0, byteGodOn);
            }
            else
            {
                PS3.SetMemory(0x4d21d0, byteGodOff);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                PS3.SetMemory(0x7895c8, byteMunOn);
                byte[] buffer = new byte[4];
                buffer[0] = 0x60;
                PS3.SetMemory(0x68e7dc, buffer);
            }
            else
            {
                PS3.SetMemory(0x7895c8, byteMunOff);
                PS3.SetMemory(0x68e7dc, byteMunOff2);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                PS3.SetMemory(0x6aeb58, byteMoneyOn1);
                PS3.SetMemory(0x6aeb5c, byteMoneyOn2);
            }
            else
            {
                PS3.SetMemory(0x6aeb58, new byte[] { 0x40, 0x80, 0, 8 });
                byte[] buffer = new byte[4];
                buffer[0] = 0x38;
                buffer[1] = 0xc0;
                PS3.SetMemory(0x6aeb5c, buffer);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PS3.SetMemory(0x10a2a54, byteXP100);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            PS3.SetMemory(0x10a2a54, byteXP1000);
        }
    }
}
