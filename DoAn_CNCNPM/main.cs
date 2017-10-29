using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            FulScreen();
            this.getSinhVien();
        }

        private void FulScreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;
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

        async private void getSinhVien() {
            Console.Write("sinh vien");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);
            var response = client.GetAsync("http://192.168.1.123:8000/api/student/v1/details").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject s = JObject.Parse(responseContent.ToString());
                Console.Write(s);
                lblname.Text = "Xin chào " + s["name"];
            }
        }
    }
}
