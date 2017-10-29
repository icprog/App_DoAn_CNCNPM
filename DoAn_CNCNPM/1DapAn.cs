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
            foreach (Answer answer in question.AnswerList)
            {
                RadioButton rdbtn = new RadioButton();
                rdbtn.Text = answer.AnswerText;
                rdbtn.Tag = answer.id;
                pnlDapan.Controls.Add(rdbtn);
            }
        }
    }
}
