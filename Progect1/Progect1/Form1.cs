using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            listBox1.Items.Add(addfrf2);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.Navigate(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            webBrowser1.Size = new Size(this.Width - webBrowser1.Left-20, this.Height - webBrowser1.Top-40);
        }
    }
}
