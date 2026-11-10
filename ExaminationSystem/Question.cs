using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    public abstract class Question
    {
        public Question(string header, int marks, QuestionLevel level)
        {
            Header = header;
            Marks = marks;
            Level = level;
        }

        public string Header { get; set; }
        public int Marks { get; set; }
        public QuestionLevel Level { get; set; }

        public abstract void Display();
        public abstract bool CheckAnswer(string answer);
    }
}
