using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public class ChooseOneQuestion : Question
    {
        public List<string> Choices { get; set; }
        public string CorrectAnswer { get; set; }

        public ChooseOneQuestion(string header, int marks,QuestionLevel level, List<string> choices, string correctAnswer): base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine(Header);

            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            if (answer == CorrectAnswer)
                return true;

            return false;
        }
    }

}
