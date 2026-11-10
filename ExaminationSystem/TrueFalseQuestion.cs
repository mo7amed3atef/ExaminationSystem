using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
        public TrueFalseQuestion(string header, int marks, QuestionLevel level, bool correctAnswer) : base(header, marks, level)
        {
            CorrectAnswer = correctAnswer;
        }
        public override void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
        public override bool CheckAnswer(string answer)
        {
            if (answer == "True" && CorrectAnswer == true)
                return true;

            if (answer == "False" && CorrectAnswer == false)
                return true;

            return false;
        }
    }
}
