using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

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

        async private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtmssv.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập MSSV và mật khẩu");
                return;
            }
            HttpClient client = new HttpClient();
            var parameters = new Dictionary<string, string> { { "mssv", txtmssv.Text }, { "password", txtpassword.Text } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = client.PostAsync("http://192.168.141.28:8000/api/student/login", encodedContent).Result;
            if (response.StatusCode == HttpStatusCode.OK) {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject s = JObject.Parse(responseContent.ToString());
                this.Hide();
                main fm = new main(s["success"]["token"].ToString());
                fm.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //this.Hide();
            //main fm = new main("token");
            //fm.Show();
        }
    }
}
