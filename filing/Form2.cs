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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = Form1.f2Action;
            this.button1.Text = this.Text;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                this.comboBox1.Items.Add(d.Name);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "Create File") {
                createFile();
            }
            else if (this.Text == "Find File") {

            }
            
        }

        private void createFile() {
            string finalPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.textBox1.Text + "." + this.comboBox3.Text;
            FileStream fs = null;
            if (File.Exists(finalPath))
            {
                MessageBox.Show("!File Already Exist");
            }
            else
            {
                File.Create(finalPath).Close();
                MessageBox.Show("File successfully creat");
                this.Hide();
            }
        }

        private void findFile()
        {
            string finalPath = this.comboBox1.Text + this.comboBox2.Text + "\\" + this.textBox1.Text + "." + this.comboBox3.Text;
            FileStream fs = null;
            if (File.Exists(finalPath))
            {
                MessageBox.Show("! File is not found");
            }
            else
            {
                MessageBox.Show("File is found");
                this.Hide();
            }
        }
    }
}
