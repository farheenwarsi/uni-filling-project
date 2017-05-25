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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private static string sPath = "";

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = Form1.f4Action;
            this.button1.Text = this.Text;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                this.comboBox1.Items.Add(d.Name);
            }

            this.label3.Visible = false;
            this.textBox1.Visible = false;

            if (this.Text == "Rename File") {
                this.label3.Visible = true;
                this.textBox1.Visible = true;
            }
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
            sPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(sPath))
            {
                File.Delete(sPath);
                MessageBox.Show("!File is removed.");
                this.Hide();
            }
            else {
                MessageBox.Show("!File is not found");
            }
        }
    }
}
