using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(String text, String answer) : base(text, answer)
        {
        }
        public override bool CheckAnswer(string userAnswer)
        {
            if (userAnswer.Length != 1)
            {
                throw new ArgumentException("Invalid response. Please answer 'T' or 'F'.");
            }
            // Kiểm tra xem câu trả lời có phải T hoặc F không.
            char character = userAnswer[0];
            if (!(character == 'T' || character == 't' || character == 'F' || character == 'f'))
            {
                throw new ArgumentException("Invalid response. Please answer 'T' or 'F'.");
            }
            return string.Equals(userAnswer, answer, StringComparison.OrdinalIgnoreCase);

        }
    }
}
