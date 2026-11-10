using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Choices { get; set; }
        public List<int> CorrectAnswers { get; set; }

        public MultipleChoiceQuestion(string header, int marks,QuestionLevel level, List<string> choices,List<int> correctAnswers): base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswers = correctAnswers;
        }

        public override void Display()
        {
            Console.WriteLine(Header);

            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }

            Console.WriteLine("Enter answers separated by commas:");
        }

        public override bool CheckAnswer(string answer)
        {
            string[] studentAnswers = answer.Split(',');

            if (studentAnswers.Length != CorrectAnswers.Count)
                return false;

            List<int> answers = new List<int>();

            try
            {
                for (int i = 0; i < studentAnswers.Length; i++)
                {
                    int studentAnswer = Convert.ToInt32(studentAnswers[i]);

                    if (studentAnswer < 1 || studentAnswer > Choices.Count)
                        return false;

                    if (answers.Contains(studentAnswer))
                        return false;

                    answers.Add(studentAnswer);
                }
            }
            catch
            {
                return false;
            }

            for (int i = 0; i < CorrectAnswers.Count; i++)
            {
                if (!answers.Contains(CorrectAnswers[i]))
                    return false;
            }

            return true;
        }
    }
}
