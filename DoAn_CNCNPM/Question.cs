using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CNCNPM
{
    class Question
    {
        public String QuestionText { get; set; };
        public List<Answer> AnswerList { get; set; }
        public string UserAswer { get; set; }
        public string id { get; set; }
        public string AnswerCorrect { get; set; }

        public Question() {
            UserAswer = "";
        }
    }
}
