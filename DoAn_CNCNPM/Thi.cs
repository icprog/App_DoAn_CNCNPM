using Newtonsoft.Json;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNCNPM
{
    public partial class Thi : Form
    {
        private int lich_thi_id = 0;
        private List<Question> questions;
        private string token = "";
        private string madethi = "";
        private int thoigianthi = 0;//convert minutes to seconds
        private string tgthi = "0";
        public Thi(int lich_thi_id, string token, string mon)
        {
            InitializeComponent();
            this.lich_thi_id = lich_thi_id;
            this.token = token;
            getQuestions();
            //FulScreen();
            lblmon.Text = "Bài Thi môn: " + mon;
        }

        async private void getQuestions()
        {
            Console.WriteLine("lich thi:" + lich_thi_id.ToString());
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var parameters = new Dictionary<string, string> { { "lichthi_id", lich_thi_id.ToString() } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = client.PostAsync("http://192.168.141.28:8000/api/student/v1/getdethi", encodedContent).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject s = JObject.Parse(responseContent.ToString());
                Console.Write(s);
                madethi = s["madethi"].ToString();
                thoigianthi = Int32.Parse(s["thoigianthi"].ToString()) * 60;
                tgthi = s["thoigianthi"].ToString();
                questions = new List<Question>();
                foreach (var question in s["questions"]) {
                    List<Answer> answers = new List<Answer>();
                    foreach (var ans in question["listdapan"])
                    {
                        answers.Add(new Answer
                        {
                            id = ans["id"].ToString(),
                            AnswerText = ans["noidungdapan"].ToString(),
                            AnswerName = ans["tendapan"].ToString()
                        });
                    }
                    List<Answer> listAnswers = answers.OrderByDescending(a => a.AnswerName).ToList();
                    questions.Add(new Question()
                    {
                        QuestionText = question["noidungcauhoi"].ToString(),
                        AnswerList = listAnswers,
                        id = question["id"].ToString(),
                        AnswerCorrect = question["dapan"].ToString()
                    });
                }
                timer1.Start();
            }
        }

        private List<Question> CreateListQuestion() 
        {
            questions = new List<Question>();
            questions.Add(new Question()
            {
                QuestionText = "Hành tinh nào lớn nhất trong hệ mặt trời",
                AnswerList = new List<Answer>()
                {
                    new Answer(){
                        id = "1",
                        AnswerText = "Trái Đất",
                        AnswerName = "Cau A"
                    },
                    new Answer(){
                        id = "2",
                        AnswerText = "Sao Mộc",
                        AnswerName = "Cau B"
                    },
                    new Answer(){
                        id = "3",
                        AnswerText = "Sao Thổ",
                        AnswerName = "Cau C"
                    },
                    new Answer(){
                        id = "4",
                        AnswerText = "Sao Thiên Vương",
                        AnswerName = "Cau D"
                    }
                },
                id = "1",
                AnswerCorrect = "1,2"
            });
            questions.Add(new Question()
            {
                QuestionText = "Giảm thời gian hồi chiêu trong LOL tối đa là bao nhiêu",
                AnswerList = new List<Answer>()
                {
                    new Answer(){
                        id = "5",
                        AnswerText = "30%",
                        AnswerName = "Cau A"
                    },
                    new Answer(){
                        id = "6",
                        AnswerText = "35%",
                        AnswerName = "Cau B"
                    },
                    new Answer(){
                        id = "7",
                        AnswerText = "40%",
                        AnswerName = "Cau C"
                    },
                    new Answer(){
                        id = "8",
                        AnswerText = "45%",
                        AnswerName = "Cau D"
                    }
                },
                id = "2",
                AnswerCorrect = "8"
            });
            return questions;
        }
        private void Thi_Load(object sender, EventArgs e)
        {
            //FulScreen();
            //questions = CreateListQuestion();
            foreach (Question qs in questions)
            {
                pnllistcauhoi.Controls.Add(new _1DapAn(qs));
            }
        }

        private void FulScreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            NopBai(false);
        }

        private void NopBai(bool overtime)
        {
            if (overtime || MessageBox.Show("Ban co chac chan muon ket thuc bai thi", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //GetResult();
                //this.Close();
                GetResult();
                //this.Dispose();
                //Form1 fl = new Form1();
                //fl.Show();
            }
        }

        async private void GetResult()
        {
            var parameters = new Dictionary<string, string> { { "madethi", madethi }, { "thoigianlam", tgthi } };
            var questions = new List<Dictionary<string, string>>();
            List<CauHoi> ch = new List<CauHoi>();
            foreach (Control c in pnllistcauhoi.Controls)
            {
                _1DapAn da = c as _1DapAn;
                string[] ans = da.getAnswer();
                questions.Add(new Dictionary<string, string>
                {
                    {"id", ans[0]},
                    {"answer", ans[1]},
                    {"dapan", ans[2]}
                });
                ch.Add(new CauHoi
                {
                    id = ans[0],
                    answer = ans[1],
                    dapan = ans[2]
                });
                Console.WriteLine(da.getAnswer());
            }
            var baithi = new BaiThi
            {
                madethi = madethi,
                thoigianlam = tgthi,
                questions = ch
            };
            var jsonRequest = JsonConvert.SerializeObject(baithi);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var encodedContent = new FormUrlEncodedContent(parameters);
            try
            {
                var response = client.PostAsync("http://192.168.141.28:8000/api/student/v1/nopbaithi", content).Result;
                Console.WriteLine(response);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    string s = responseContent.ToString();
                    Console.Write(s);
                    //MessageBox.Show(string.Format("Số điểm bạn làm được là: {0}", (float.Parse(s.ToString())).ToString("0.00")), "Result", MessageBoxButtons.OK);
                    MessageBox.Show(string.Format("Số điểm bạn làm được là: {0}", s), "Result", MessageBoxButtons.OK);
                    this.Dispose();
                    Form1 fl = new Form1();
                    fl.Show();
                }
                else
                {
                    Console.WriteLine("errrorrrrrrrrrrrrrrrrrrrrrr");
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hrerererrere");
                Console.WriteLine(ex);
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void Thi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private string sotostring(int a)
        {
            if (a < 10)
            {
                return "0" + a.ToString();
            }
            return a.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            thoigianthi -= 1;
            if (thoigianthi <= 0)
            {
                timer1.Stop();
                NopBai(true);
                
                return;
            }
            int phut = (int)(thoigianthi / 60);
            int giay = thoigianthi - phut * 60;
            lbltime.Text = sotostring(phut) + ":" + sotostring(giay);
        }
    }
}
