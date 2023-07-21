using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Question
    {
        protected String text;
        protected String answer;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        public Question(String text, String answer) {
            this.text = text;
            this.answer = answer;
        }
        public abstract bool CheckAnswer(string userAnswer);
    }
}
