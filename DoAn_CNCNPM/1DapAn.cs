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
            lblCauhoi.Text = question.QuestionText;
            foreach (Answer answer in question.AnswerList)
            {
                RadioButton rdbtn = new RadioButton();
                rdbtn.Text = answer.AnswerText;
                rdbtn.Tag = answer.id;
                rdbtn.Dock = DockStyle.Top;
                rdbtn.CheckedChanged += new EventHandler(CheckedChanged);
                pnlDapan.Controls.Add(rdbtn);
            }
        }

        protected void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = ((RadioButton)sender);
            question.UserAswer = rbtn.Tag.ToString();
            Console.WriteLine(rbtn.Tag.ToString());
        }
        public string getAnswer()
        {
            return question.UserAswer;
        }
    }
}
