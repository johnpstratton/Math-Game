using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Math_Game
{
    struct Levels  // Declare struct to organize levels
    {
        public bool IsGameComplete { get; set; } // one field to validate when the game has been completed

        public Levels(bool isgamecomplete) // Declare Levels Constructor
        {
            IsGameComplete = isgamecomplete;
        }

        //This whole block will be used to store the users wrong answers and display them at the end of each level
        
        private static readonly List<string> wrongAnswers = new List<string>();
        public static void WrongAnswerWriter()
        {
            StreamWriter streamWriter = new StreamWriter("wronganswers.txt");
            
            
            for(int i = 0; i < wrongAnswers.Count; i++ )
            {
                streamWriter.WriteLine(wrongAnswers[i]);
            }
            streamWriter.Close();
        }
        public static void RevealWrongAnswers()
        {
            StreamReader streamReader = new StreamReader("wronganswers.txt");
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }

       // END OF WRONG ANSWERS CODE BLOCK

            //CREATE METHODS TO DEFINE THE LEVELS AND ASK THE USER QUESTIONS
        public static bool GenerateBeginnerQuestions()  
        {                                                       
            Random random = new Random(); // create new instance of random
            string[] operators = { "+", "-" }; //holds operators to be randomized
            int questionsRight = 0; // counter for while loop
            bool levelUp; 
            while (questionsRight < 10)
            {
                int operation = random.Next(2); //create random number for operators
                int num1 = random.Next(1, 300); // create random number 
                int num2 = random.Next(1, 300); // create random number 

                string question = $"{num1}  {operators[operation]}  {num2}"; // define string to ask user
                double calculate = Convert.ToDouble(new DataTable().Compute(question, null)); //convert string and compute
                int solution = Convert.ToInt32(Math.Round(calculate)); // convert double back to int and round it
                Console.Write($"Please complete the following problem and round to the nearest whole number: \t{question}: ");
                Console.WriteLine(solution);
                Console.WriteLine(calculate);
                int answer;
                bool isNum = int.TryParse(Console.ReadLine(), out answer);
                if (answer == solution)
                {
                    Console.WriteLine("Congratulations you got it right!");
                    questionsRight += 1; //increment if answer right
                }
                else
                {
                    wrongAnswers.Add(question); // add the question to wrongAnswers list if wrong answer given
                    Console.WriteLine("Try Again");
                    Console.Write($"Please complete the following problem and round to the nearest whole number: \t{question}: ");
                    isNum = int.TryParse(Console.ReadLine(), out answer);
                }
            }
            levelUp = true; //successfully completed Beginner level
            return levelUp; //return to levelup to intermediate
        }



        
        public static bool GenerateIntermediateQuestions()
        {
            Random random = new Random(); //create new instance of random
            //double power = random.Next(10);
            //double exponentiation = Math.Pow(10, power);
            //List<object> list = new List<object>() { exponentiation, "+", "-", "/", "*" };
            string[] operators = { "-", "+", "/", "*" }; //holds operators to be randomized
            int questionsRight = 0; // counter for while loop
            bool levelUp;
            while (questionsRight < 10)
            {
                //int operation1 = random.Next(list.Count);
                int operation1 = random.Next(operators.Length - 1); //create random number for operators
                double num1 = random.Next(Convert.ToInt32(-10 * random.NextDouble()), Convert.ToInt32(10 * random.NextDouble()));
                double num2 = random.Next(10, 10); //create random number 
                //int operation2 = random.Next(list.Count);
                int operation2 = random.Next(operators.Length - 1); //create random number for operators
                double num3 = random.Next(-10, 10); //create random number 
                double num4 = random.Next(Convert.ToInt32(-10 * random.NextDouble()), Convert.ToInt32(10 * random.NextDouble()));

                //string question = $"({num1}  {list.ElementAt(operation1)}  {num2}) {list.ElementAt(operation2)} {num3}"; // define string to ask user
                string question = $"({num1}  {operators[operation1]}  {num2}) {operators[operation2]} ({num4} {operators[operation2]} {num3})"; // define string to ask user
                double calculate = Convert.ToDouble(new DataTable().Compute(question, null)); //convert string and compute
                //long solution = Convert.ToInt64(Math.Round(calculate)); // convert double to long and round it

                try
                {
                    long solution = Convert.ToInt64(Math.Round(calculate)); // convert double to long and round it
                    
                    Console.Write($"Please complete the following problem and round to the nearest whole number: \t{question}: ");
                    Console.WriteLine(solution);
                    Console.WriteLine(calculate);
                    int answer;
                    bool isNum = int.TryParse(Console.ReadLine(), out answer);

                    if (answer == solution)
                    {
                        Console.WriteLine("Congratulations you got it right!");
                        questionsRight += 1; //increment if answer right
                    }
                    else
                    {
                        wrongAnswers.Add(question); // Add question to wrongAnswers if answered incorrectly
                        Console.WriteLine("Try Again");
                        Console.Write($"Please complete the following problem and round to the nearest whole number: \t{question}: ");
                        isNum = int.TryParse(Console.ReadLine(), out answer);
                    }
                }
                catch(OverflowException e)
                {
                    int solution = 0;
                    Console.WriteLine("System cannot divide by 0");
                    
                }
            }
            levelUp = true; //Proceed to next level if successfully complete this level
            return levelUp; 
        }


        public static bool GenerateAdvancedQuestions() 
        {                                                          
            Random random = new Random();
            //double power = random.Next(10);
            //double exponentiation = Math.Pow(10, power);
            //List<object> list = new List<object>() { exponentiation, "+", "-", "/", "*" };
            string[] operators = { "/", "*", "+", "-" };
            int questionsRight = 0;
            bool levelUp;
            while (questionsRight < 10)
            {
                int operation1 = random.Next(operators.Length - 1);
                double num1 = random.Next(Convert.ToInt32(-10 * random.NextDouble()), Convert.ToInt32(10 * random.NextDouble()));
                double num2 = random.Next(10, 20);
                int operation2 = random.Next(operators.Length - 1);
                double num3 = random.Next(Convert.ToInt32(-10 * random.NextDouble()), Convert.ToInt32(10 * random.NextDouble()));
                int operation3 = random.Next(operators.Length - 1);
                double num4 = random.Next(10, 20);
                double num5 = random.Next(Convert.ToInt32(-10 * random.NextDouble()), Convert.ToInt32(10 * random.NextDouble()));
                double num6 = random.Next(10, 20);


                string question = $"(({num1}  {operators[operation1]}  {num2}) {operators[operation1]} ({num5}  {operators[operation3]} {num6}) {operators[operation2]} ({num3} {operators[operation3]} {num4}))";
                double calculate = Convert.ToDouble(new DataTable().Compute(question, null));
                //int solution = Convert.ToInt32(Math.Round(calculate));
                try
                {
                    int solution = Convert.ToInt32(Math.Round(calculate)); // convert double to long and round it
                    Console.Write($"Please complete the following problem and round to the nearest whole number: \t{question}: ");
                    Console.WriteLine(solution);
                    Console.WriteLine(calculate);
                    int answer;
                    bool isNum = int.TryParse(Console.ReadLine(), out answer);
                    if (answer == solution)
                    {
                        Console.WriteLine("Congratulations you got it right!");
                        questionsRight += 1;
                    }
                    else
                    {
                        wrongAnswers.Add(question);
                        Console.WriteLine("Try Again");
                        Console.Write($"Please complete the following problem and round to the nearest whole number: \t{question}: ");
                        isNum = int.TryParse(Console.ReadLine(), out answer);
                    }
                }
                catch (OverflowException e)
                {
                    int solution = 0;
                    Console.WriteLine("System cannot divide by 0, answer is 0");
                }

                
            }
            levelUp = true;
            return levelUp;
        }
        //Initialize method to call all GenerateQuestions Methods and pass instance of NewPlayer as parameter
        public static Levels PlayGame(NewPlayer newPlayer) 
        {
            Console.WriteLine($"Welcome to Math Game {newPlayer.FirstName} {newPlayer.LastName}!"); //Greets User using input from NewPlayer class
            GenerateBeginnerQuestions();    //Call BeginnerQuestions
            if(true) //If Level is successfully passed
            {
                newPlayer.LevelAchieved = NewPlayer.ExperienceLevel.Beginner; //User ranks up
                Console.WriteLine("Congratulations you have passed the beginner level!!");
                Console.WriteLine($"{newPlayer.FirstName} you have advanced to the {newPlayer.LevelAchieved} level");
                WrongAnswerWriter(); //calls wrong answer method and transfers list to .txt document
                Console.WriteLine("These are the questions you got wrong: \n"); 
                RevealWrongAnswers(); //Display wrong answers from Beginner Level
                Console.WriteLine("----------------------------------------------------------");
                GenerateIntermediateQuestions(); //Call Intermediate Method and start next level
                if (true) //if level successfully passed
                {
                    newPlayer.LevelAchieved = NewPlayer.ExperienceLevel.Intermediate; //User ranks up
                    Console.WriteLine("Congratulations you have passed the intermediate level!!");
                    WrongAnswerWriter();//calls wrong answer method and transfers list to .txt document
                    Console.WriteLine("These are the questions you got wrong: \n");
                    RevealWrongAnswers(); //Display wrong answers from Intermediate Level
                    Console.WriteLine("----------------------------------------------------------");
                    GenerateAdvancedQuestions(); //Call Advanced Method and start next level
                    if (true) //if level successfully passed
                    {
                        newPlayer.LevelAchieved = NewPlayer.ExperienceLevel.Advanced; //User ranks up
                        Levels AllLevelsComplete = new Levels(true); //Creates new instance of Levels
                        Console.WriteLine("Congratulations you have won the game!!");
                        WrongAnswerWriter(); //calls wrong answer method and transfers list to .txt document
                        Console.WriteLine("These are the questions you got wrong: \n");
                        RevealWrongAnswers(); //Display wrong answers from Advanced Level

                        Console.WriteLine("----------------------------------------------------------");
                        return AllLevelsComplete; //Game complete
                    }
                }
            }
            
            
            
        }
    }
}
