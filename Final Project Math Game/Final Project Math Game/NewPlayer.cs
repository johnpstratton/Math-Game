using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Math_Game
{
    
    public class NewPlayer //create new player class
    {
        public string FirstName { get; set; } //assign fields to get/set later
        public string LastName { get; set; } //assign fields to get/set later
        public int Grade { get; set; } //assign fields to get/set later
        public ExperienceLevel LevelAchieved { get; set; } //assign fields to get/set later

        public enum ExperienceLevel
        {
            None, //used to validate user progress
            Beginner, //used to validate user progress
            Intermediate, //used to validate user progress
            Advanced //used to validate user progress

        }
        public NewPlayer(string firstname, string lastname, int grade) //NewPlayer constructor
        {
            FirstName = firstname;
            LastName = lastname;
            Grade = grade;
            LevelAchieved = ExperienceLevel.None;

            
        }
        public static void PrintGameInstructions() //Declare method to print the game instructions
        {
            StreamReader inFile = new StreamReader("mathgame.txt");
            Console.WriteLine(inFile.ReadToEnd());

            inFile.Close();
        }
         static string UserFirstName() // Get Users first name
        {
            Console.Write("Please enter your first name: ");
            string firstname = Console.ReadLine();
            while (string.IsNullOrEmpty(firstname))
            {
                Console.WriteLine("Please enter a valid name");
                Console.Write("Please enter your last name: ");
                firstname = Console.ReadLine();
            }
            return firstname;
        }
        static string UserLastName() // Get user's last name
        {
            Console.Write("Please enter your last name: ");
            string lastname = Console.ReadLine();
            while (string.IsNullOrEmpty(lastname))
            {
                Console.WriteLine("Please enter a valid name");
                Console.Write("Please enter your last name: ");
                lastname = Console.ReadLine();
            }
            return lastname;
        }
        //Find out what grade they are in for when game is scaled and can make specific questions for different grade levels
        static int UserGrade() 
        {
            Console.Write("Please enter your grade in a number format(i.e. 1, 2, 3): ");
            int grade;
            bool isgrade = int.TryParse(Console.ReadLine(), out grade);
            while(isgrade == false)
            {
                Console.Write("Please enter your grade in a number format(i.e. 1, 2, 3): ");
                isgrade = int.TryParse(Console.ReadLine(), out grade);
            }
            return grade;
        }
        public static NewPlayer GenerateNewPlayer() //Method to create NewPlayer instance with user's information
        {
            
            NewPlayer player = new NewPlayer(UserFirstName(), UserLastName(), UserGrade());
            player.LevelAchieved = ExperienceLevel.None;
            return player;
        }
        public static void PrintPlayer(NewPlayer newPlayer) //say hi to the player
        {
            Console.WriteLine($"Welcome to Math Game {newPlayer.FirstName} {newPlayer.LastName} {newPlayer.Grade} {newPlayer.LevelAchieved}");
        }
    }
}
