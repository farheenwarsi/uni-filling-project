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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private static string WFPath = "";
        private static string RFPath = "";

        private void Form5_Load(object sender, EventArgs e)
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
            StreamReader sr = new StreamReader(WFPath);
            string text = sr.ReadToEnd();
            this.textBox1.Text = text;
            sr.Close();
            this.textBox1.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WFPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
            if (File.Exists(WFPath))
            {
                StreamWriter sw = new StreamWriter(WFPath, false);
                sw.WriteLine(this.textBox1.Text);
                sw.Close();
                MessageBox.Show("File Edited.");
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
                StreamReader sr = new StreamReader(RFPath);
                string text = sr.ReadToEnd();
                this.textBox2.Text = text;
                sr.Close();
            }
            else MessageBox.Show("File not found.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
