using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public class OpenendedQuestion : Question
    {
        public OpenendedQuestion(String text, String answer) : base(text, answer)
        {
        }

        public override bool CheckAnswer(string userAnswer)
        {
            // Kiểm tra xem câu trả lời có phải số không
            if (!IsNumber(userAnswer))
            {
                throw new ArgumentException("Invalid response. Please type in a number");
            }
            return string.Equals(userAnswer, answer, StringComparison.OrdinalIgnoreCase);
        }
        static bool IsNumber(string input)
        {
            // Regular expression pattern for a number.
            string pattern = @"^[+-]?(\d*\.)?\d+$";

            // Create a regular expression object.
            Regex regex = new Regex(pattern);

            // Use the regex object to match the input against the pattern.
            return regex.IsMatch(input);
        }
    }
}
