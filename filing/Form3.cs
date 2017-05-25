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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private static string sPath = "";
        private static string dPath = "";
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = Form1.f3Action;
            this.button1.Text = this.Text;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                this.comboBox1.Items.Add(d.Name);
                this.comboBox4.Items.Add(d.Name);
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
            sPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.comboBox3.Text;
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
            dPath = this.comboBox4.Text + this.comboBox5.Text + "\\";
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dPath = this.comboBox4.Text + this.comboBox5.Text + "\\";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "Copy And Paste")
            {
                copyFile();
            }
            else {
                moveFile();
            }
            
        }

        private void copyFile() {
            if (File.Exists(dPath + this.comboBox3.Text))
            {
                MessageBox.Show("!File Already Exist.");
            }
            else
            {
                File.Copy(sPath, dPath + this.comboBox3.Text);
                MessageBox.Show("File Successfully Copyed.");
                this.Hide();
            }
        }

        private void moveFile()
        {
            if (File.Exists(dPath + this.comboBox3.Text))
            {
                MessageBox.Show("!File Already Exist.");
            }
            else
            {
                File.Move(sPath, dPath + this.comboBox3.Text);
                MessageBox.Show("File Successfully Moved.");
                this.Hide();
            }
        }
    }
}
