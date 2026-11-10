using Microsoft.VisualBasic.FileIO;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello for the Examination System");
            Console.WriteLine("---------------------------------");
            int option;
            List<Question> questions = new List<Question>();
            do
            {
                Console.WriteLine("\nMain Menu :");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option:");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        DoctorMode(questions);
                        break;
                    case 2:
                        StudentMode(questions);
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            } while (option != 3);

        }


        static void DoctorMode(List<Question> questions)
        {
            Console.Write("How many questions do you want to add? ");
            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"\nAdding Question {i + 1}:");

                Console.WriteLine("Select Question Type:");
                Console.WriteLine("1- True/False");
                Console.WriteLine("2- Choose One");
                Console.WriteLine("3- Multiple Choice");

                Console.Write("Choose: ");
                int type = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Question Level (easy/medium/hard): ");
                string levelInput = Console.ReadLine();

                QuestionLevel level;

                if (levelInput == "easy")
                {
                    level = QuestionLevel.Easy;
                }
                else if (levelInput == "medium")
                {
                    level = QuestionLevel.Medium;
                }
                else
                {
                    level = QuestionLevel.Hard;
                }

                Console.Write("Enter Question Header: ");
                string header = Console.ReadLine();

                Console.Write("Enter Question Marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                switch (type)
                {
                    case 1:
                        Console.Write("Enter Correct Answer (true/false): ");
                        string answer = Console.ReadLine();

                        bool trueFalseAnswer;

                        if (answer == "true")
                        {
                            trueFalseAnswer = true;
                        }
                        else
                        {
                            trueFalseAnswer = false;
                        }

                        questions.Add(new TrueFalseQuestion(header, marks, level, trueFalseAnswer));
                        break;

                    case 2:
                        List<string> choices = new List<string>();

                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter choice {j + 1}: ");
                            choices.Add(Console.ReadLine());
                        }

                        Console.Write("Enter correct choice number (1-4): ");
                        string correctAnswer = Console.ReadLine();

                        questions.Add(new ChooseOneQuestion(header, marks, level, choices, correctAnswer));
                        break;

                    case 3:
                        List<string> multipleChoices = new List<string>();

                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter choice {j + 1}: ");
                            multipleChoices.Add(Console.ReadLine());
                        }

                        Console.Write("Enter correct answers (comma separated, e.g. 1,3): ");
                        string answers = Console.ReadLine();

                        string[] answerArray = answers.Split(',');
                        List<int> correctAnswers = new List<int>();

                        for (int j = 0; j < answerArray.Length; j++)
                        {
                            correctAnswers.Add(Convert.ToInt32(answerArray[j]));
                        }

                        questions.Add(new MultipleChoiceQuestion(
                            header, marks, level, multipleChoices, correctAnswers));

                        break;

                    default:
                        Console.WriteLine("Invalid Question Type.");
                        i--;
                        break;
                }
            }

            Console.WriteLine("\nQuestions Added Successfully!");
        }

        static void StudentMode(List<Question> questions)
        {
            Console.WriteLine("\nChoose Exam Type:");
            Console.WriteLine("1- Practical Exam");
            Console.WriteLine("2- Final Exam");

            Console.Write("Choose: ");
            int examOption = Convert.ToInt32(Console.ReadLine());

            ExamType examType;

            if (examOption == 1)
                examType = ExamType.Practical;
            else
                examType = ExamType.Final;

            Console.Write("Enter Exam Level (easy/medium/hard): ");
            string levelInput = Console.ReadLine();

            QuestionLevel level;

            if (levelInput == "easy")
                level = QuestionLevel.Easy;
            else if (levelInput == "medium")
                level = QuestionLevel.Medium;
            else
                level = QuestionLevel.Hard;

            List<Question> examQuestions = new List<Question>();

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Level == level)
                {
                    examQuestions.Add(questions[i]);
                }
            }

            if (examQuestions.Count == 0)
            {
                Console.WriteLine("No questions available for this level.");
                return;
            }

            int questionsToShow = examQuestions.Count;

            if (examType == ExamType.Practical)
            {
                questionsToShow = (examQuestions.Count + 1) / 2;
            }

            int totalMarks = 0;
            int studentMarks = 0;

            Console.WriteLine("\n--- Exam Started ---\n");

            for (int i = 0; i < questionsToShow; i++)
            {
                Question question = examQuestions[i];

                question.Display();

                Console.WriteLine("Marks: " + question.Marks);
                Console.Write("Your Answer: ");

                string answer = Console.ReadLine();

                if (question.CheckAnswer(answer))
                {
                    studentMarks += question.Marks;
                }

                totalMarks += question.Marks;

                Console.WriteLine();
            }

            Console.WriteLine("Your Result: " + studentMarks + " / " + totalMarks);
        }


    }
}
