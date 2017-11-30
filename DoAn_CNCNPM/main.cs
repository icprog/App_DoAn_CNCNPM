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
            //FulScreen();
            this.getSinhVien();
            this.getMonThi();
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
            this.Hide();
            Form1 fl = new Form1();
            fl.Show();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        async private void getSinhVien() {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);
            var response = client.GetAsync("http://192.168.141.28:8000/api/student/v1/details").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject s = JObject.Parse(responseContent.ToString());
                lblname.Text = "Xin chào " + s["name"];
                this.Text = "" + s["name"];
            }
        }

        async private void getMonThi()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);
            var response = client.GetAsync("http://192.168.141.28:8000/api/student/v1/getdanhsachmonthi").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                int rows = pnlmonthi.Width / 117;
                int height = 0;
                int row = 0;
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject s = JObject.Parse(@"{ ""data"" : " + responseContent.ToString() + "}");
                foreach(var mon in s["data"]){
                    Button btn = new Button();
                    btn.Text = mon["lichthi"]["malophp"].ToString() + ":" + mon["mon"]["tenmon"].ToString();
                    btn.Tag = mon["lichthi"]["id"].ToString();
                    btn.Name = mon["mon"]["tenmon"].ToString();
                    btn.Size = new Size(113, 63);
                    btn.Font = new Font(btn.Font.FontFamily, 14);
                    btn.ForeColor = Color.Lime;
                    btn.BackColor = Color.White;
                    btn.Location = new Point(row * btn.Width + row * 3, height);
                    btn.Click += new EventHandler(button_Click);
                    pnlmonthi.Controls.Add(btn);
                    row++;
                    if (row >= rows)
                    {
                        row = 0;
                        height += 70;
                    }
                    Console.Write(mon["tenmon"]);
                }
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Console.Write(button.Tag);
            Thi t = new Thi(Int32.Parse(button.Tag.ToString()), token, button.Name);
            this.Dispose();
            t.Show();
        }

        private void main_Shown(object sender, EventArgs e)
        {
            //Thi t = new Thi();
            //this.Dispose();
            //t.Show();
        }
    }
}
