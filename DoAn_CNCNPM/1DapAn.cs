using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNCNPM
{
    public partial class _1DapAn : UserControl
    {
        public Question question { get; set; }
        public _1DapAn(Question question)
        {
            InitializeComponent();
            this.question = question;
            LoadQuestion();
            this.Dock = DockStyle.Top;
        }

        private void LoadQuestion()
        {
            if (question.AnswerCorrect[question.AnswerCorrect.Length - 1] == ',')
            {
                question.AnswerCorrect = question.AnswerCorrect.Substring(0, question.AnswerCorrect.Length - 1);
            }
            String[] dapandung = question.AnswerCorrect.Split(',').ToArray();
            lblCauhoi.Text = question.QuestionText + "(" + dapandung.Length.ToString() + "  đáp án)";
            if (dapandung.Length > 1)
            {
                foreach (Answer answer in question.AnswerList)
                {
                    CheckBox cbbtn = new CheckBox();
                    cbbtn.Text = answer.AnswerName + ":" + answer.AnswerText;
                    cbbtn.Tag = answer.id;
                    cbbtn.Dock = DockStyle.Top;
                    cbbtn.CheckedChanged += new EventHandler(CheckChanged);
                    pnlDapan.Controls.Add(cbbtn);
                }
            }
            else
            {
                foreach (Answer answer in question.AnswerList)
                {
                    RadioButton rdbtn = new RadioButton();
                    rdbtn.Text = answer.AnswerName + ":" + answer.AnswerText;
                    rdbtn.Tag = answer.id;
                    rdbtn.Dock = DockStyle.Top;
                    rdbtn.CheckedChanged += new EventHandler(RadioChanged);
                    pnlDapan.Controls.Add(rdbtn);
                }
            }
        }

        protected void RadioChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = ((RadioButton)sender);
            question.UserAswer = rbtn.Tag.ToString();
            Console.WriteLine(rbtn.Tag.ToString());
        }

        protected void CheckChanged(object sender, EventArgs e)
        {
            CheckBox cbbtn = ((CheckBox)sender);
            Console.WriteLine(cbbtn.Checked);
            Console.WriteLine(cbbtn.Tag.ToString());
            if (cbbtn.Checked)
            {
                if (question.UserAswer.Length < 1)
                {
                    question.UserAswer = cbbtn.Tag.ToString();
                }
                else
                {
                    question.UserAswer = question.UserAswer + "," + cbbtn.Tag.ToString();
                }
            }
            else
            {
                string[] listanswer = question.UserAswer.Split(',').ToArray();
                string answers = "";
                foreach(string a in listanswer) {
                    if (a != cbbtn.Tag.ToString())
                    {
                        if (answers.Length < 1)
                        {
                            answers = a;
                        }
                        else
                        {
                            answers += "," + a;
                        }
                    }
                }
                question.UserAswer = answers;
            }
        }
        public string[] getAnswer()
        {
            string[] answer = new string[3];
            answer[0] = question.id;
            answer[1] = question.UserAswer;// answer
            answer[2] = question.AnswerCorrect;//dap an
            Console.WriteLine(question.UserAswer);
            return answer;
        }
    }
}
