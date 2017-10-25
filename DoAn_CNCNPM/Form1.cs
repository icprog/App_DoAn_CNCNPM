using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;

namespace DoAn_CNCNPM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTextPosition();
        }
        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        async  private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtmssv.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập MSSV và mật khẩu");
                return;
            }
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
               { "mssv", txtmssv.Text },
               { "password", txtpassword.Text }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://192.168.1.123:8000/api/auth/login", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.Write(responseString);
            this.Hide();
            main fm = new main("token");
            fm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
