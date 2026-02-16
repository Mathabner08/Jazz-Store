using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loja
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void ToolStripButton12_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void ToolStripButton11_Click(object sender, EventArgs e)
        {
            Process.Start("winword");
        }

        private void ToolStripButton15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EncerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new Form4(this).Show();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new Form4(this).Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
