using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAn_CNCNPM
{
    public partial class main : Form
    {
        private string token = "";
        public main(String token)
        {
            this.token = token;
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Console.Write(token);
            this.Hide();
            Form1 fl = new Form1();
            fl.Show();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
