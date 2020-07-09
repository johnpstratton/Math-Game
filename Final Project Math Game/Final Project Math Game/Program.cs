using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Math_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            NewPlayer.PrintGameInstructions(); //Invokes Method to give the User instructions on how to play
            Console.WriteLine("--------------------------------------------");
            Levels.PlayGame(NewPlayer.GenerateNewPlayer()); // Generates a new player and begins game
            Console.ReadLine();
        }
    }
}


         
       