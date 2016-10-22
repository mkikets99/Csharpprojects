using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progect1
{
    public partial class Form1 : Form
    {
        public static string addfrf2;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("history.txt"))
            {
                StreamReader sr = new StreamReader("history.txt");
                while (!sr.EndOfStream)
                {
                    listBox1.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            
            ToolStripMenuItem f = (ToolStripMenuItem) menuStrip1.Items.Add("File");
            ToolStripMenuItem d = (ToolStripMenuItem)f.DropDownItems.Add("Save");
            ToolStripMenuItem l = (ToolStripMenuItem)menuStrip1.Items.Add("dt");
            l.Visible = false;
            l.ShortcutKeys = Keys.Control | Keys.D;
            l.Click += doProcess;
            d.ShortcutKeys = Keys.Control | Keys.S;
            d.Click += csonclick;
        }
        private void doProcess(object s,EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            Process pr = new Process();
            pr.StartInfo.FileName = openFileDialog1.FileName;
            pr.Start();
            var dft = pr.Id; 
            pr.WaitForExit();
            MessageBox.Show("process with id:"+dft+" is ended");
        }
        private void csonclick(object s,EventArgs e)
        {
            StreamWriter sw = new StreamWriter("history.txt");
            for(var i = 0; i < listBox1.Items.Count; i++)
            {
                sw.WriteLine(listBox1.Items[i].ToString());
            }
            sw.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            listBox1.Items.Add(addfrf2);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(listBox1.Items[listBox1.SelectedIndex].ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            webBrowser1.Size = new Size(this.Width - webBrowser1.Left-20, this.Height - webBrowser1.Top-40);
        }
    }
}
