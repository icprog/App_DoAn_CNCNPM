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
        public Thi(int lich_thi_id, string token)
        {
            InitializeComponent();
            this.lich_thi_id = lich_thi_id;
            this.token = token;
            getQuestions();
        }

        async private void getQuestions()
        {
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
                questions = new List<Question>();
                foreach (var question in s["questions"]) {
                    List<Answer> answers = new List<Answer>();
                    foreach (var ans in question["listdapan"])
                    {
                        answers.Add(new Answer
                        {
                            id = ans["id"].ToString(),
                            AnswerText = ans["tendapan"].ToString() + ": " + ans["noidungdapan"]
                        });
                    }
                    questions.Add(new Question()
                    {
                        QuestionText = question["noidungcauhoi"].ToString(),
                        AnswerList = answers,
                        id = question["id"].ToString(),
                        AnswerCorrect = question["dapan"].ToString()
                    });
                }
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
                        AnswerText = "Cau A: Trái Đất"
                    },
                    new Answer(){
                        id = "2",
                        AnswerText = "Cau B: Sao Mộc"
                    },
                    new Answer(){
                        id = "3",
                        AnswerText = "Cau C: Sao Thổ"
                    },
                    new Answer(){
                        id = "4",
                        AnswerText = "Cau D: Sao Thiên Vương"
                    }
                },
                id = "1",
                AnswerCorrect = "1"
            });
            questions.Add(new Question()
            {
                QuestionText = "Giảm thời gian hồi chiêu trong LOL tối đa là bao nhiêu",
                AnswerList = new List<Answer>()
                {
                    new Answer(){
                        id = "5",
                        AnswerText = "Cau A: 30%"
                    },
                    new Answer(){
                        id = "6",
                        AnswerText = "Cau B: 35%"
                    },
                    new Answer(){
                        id = "7",
                        AnswerText = "Cau C: 40%"
                    },
                    new Answer(){
                        id = "8",
                        AnswerText = "Cau D: 45%"
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
            if (MessageBox.Show("Ban co chac chan muon ket thuc bai thi", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GetResult();
                //this.Close();
                this.Dispose();
                Form1 fl = new Form1();
                fl.Show();
            }
        }

        private void GetResult()
        {
            foreach (Control c in pnllistcauhoi.Controls)
            {
                _1DapAn da = c as _1DapAn;
                Console.WriteLine(da.getAnswer());
            }
            MessageBox.Show(string.Format("Ban da tra loi dung {0} cau hoi", 69), "Result", MessageBoxButtons.OK);
        }

        private void Thi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
