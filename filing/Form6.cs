using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace filing
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private static string WFPath = "";
        private static string RFPath = "";

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Text = "Stream Writer and Reader";
            this.button1.Text = "Read Text";
            this.button2.Text = "Edit Text";
            this.groupBox1.Text = "Stream Writer";
            this.groupBox2.Text = "Stream Reader";
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                this.comboBox1.Items.Add(d.Name);
                this.comboBox4.Items.Add(d.Name);
            }
            this.textBox1.ReadOnly = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox2.Text = "";
            this.comboBox2.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                this.comboBox2.Items.Add(d.Name);
            }
            WFPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox3.Text = "";
            this.comboBox3.Items.Clear();
            string fPath = this.comboBox1.Text + this.comboBox2.Text + "\\";
            DirectoryInfo di = new DirectoryInfo(fPath);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                this.comboBox3.Items.Add(file.Name);
            }
            WFPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            WFPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;

            this.textBox1.Clear();
            byte[] b = new byte[1024];
            char[] c = new char[1024];
            char[] f = new char[1024];
            FileStream fs = new FileStream(WFPath, FileMode.Open, FileAccess.Read);
            fs.Read(b, 0, b.Length);
            Decoder d = Encoding.UTF8.GetDecoder();
            d.GetChars(b, 0, b.Length, c, 0, true);
            string s = new string(c);
            this.textBox1.Text = s;
            fs.Close();

            this.textBox1.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WFPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
            if (File.Exists(WFPath))
            {
                byte[] b = new byte[1024];
                char[] c = new char[1024];
                FileStream fs = new FileStream(WFPath, FileMode.Open, FileAccess.ReadWrite);
                c = this.textBox1.Text.ToCharArray();
                Encoder en = Encoding.UTF8.GetEncoder();
                en.GetBytes(c, 0, c.Length, b, 0, true);
                fs.Write(b, 0, b.Length);
                fs.Close();
                MessageBox.Show("File Edited!");
            }
            else MessageBox.Show("File not found.");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox5.Text = "";
            this.comboBox5.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(comboBox4.Text);
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                this.comboBox5.Items.Add(d.Name);
            }
            RFPath = this.comboBox4.Text + this.comboBox5.Text + "\\" + this.comboBox6.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox6.Text = "";
            this.comboBox6.Items.Clear();
            string fPath = this.comboBox4.Text + this.comboBox5.Text + "\\";
            DirectoryInfo di = new DirectoryInfo(fPath);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                this.comboBox6.Items.Add(file.Name);
            }
            RFPath = this.comboBox4.Text + this.comboBox5.Text + "\\" + this.comboBox6.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            RFPath = this.comboBox4.Text + this.comboBox5.Text + "\\" + this.comboBox6.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RFPath = this.comboBox4.Text + this.comboBox5.Text + "\\" + this.comboBox6.Text;
            if (File.Exists(RFPath))
            {
                byte[] b = new byte[1024];
                char[] c = new char[1024];
                char[] f = new char[1024];
                FileStream fs = new FileStream(RFPath, FileMode.Open, FileAccess.Read);
                fs.Read(b, 0, b.Length);
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(b, 0, b.Length, c, 0, true);
                string s = new string(c);
                this.textBox2.Text = s;
                fs.Close();
            }
            else
                MessageBox.Show("File not found.");
        }
    }
}
