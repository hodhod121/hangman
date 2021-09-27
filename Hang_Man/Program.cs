using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine(" 0) Exit");
            Console.WriteLine(" 1) Variables");      
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    RunExerciseOne();
                    return true;            

                default:
                    return true;
            }
        }
        private static string RunExerciseOne()
        {
            Console.Clear();
            string[] Names = new string[10] {"maximilian","alessandro","kristopher","abdirahman","montgomery","chancellor","jeancarlos","christiano","wellington","princeston"
        };
            Random rand = new Random();
            bool TryAgain=true;
            string secret = "";
            string repeated = "";
            while (TryAgain) { 
            string unrevealed = Names[rand.Next(0, 9)];           
            char output;
            List<char> TempList_1= new List<char>();
            List<char> TempList_2= new List<char>();
            for (int i = 0; i < 10; i++)
            {
                TempList_1.Add(unrevealed[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                TempList_2.Add('_');
            }         
            string response;           
            int live = 0;
            while (live < 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to Hangman Game");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Guess for a {unrevealed.Length} letter Word ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"You have {10-live} live");
                string val = Console.ReadLine();
                while (!char.TryParse(val, out output))
                {
                    Console.WriteLine("Enter just a letter");
                    val = Console.ReadLine();
                }
                if (!TempList_2.Contains(output) && !repeated.Contains(output) && !unrevealed.Contains(output))
                {
                    live++;
                        repeated += output.ToString();
                }
                for (int i = 0; i < 10; i++)
                {
                    if (TempList_1[i] == output)
                    {
                        TempList_2[i] = output;
                    }
                }
                foreach(char c in TempList_2)
                    {
                        secret += c.ToString();
                    }

                    if (secret == unrevealed)
                    {
                        Console.WriteLine("Congratulations! You have revealed the secret");
                        Console.WriteLine($"The secret is  {secret}");                  
                        live = 0;
                        break;
                    }
                    else
                    {
                        if (secret.Contains("_") && live == 10)
                        {
                            Console.WriteLine("Sorry, you cound not find the secret.");
                        }
                        else
                        {
                            Console.WriteLine(secret);
                            secret = "";
                        }                      
                    }                 
            }                
                Console.WriteLine();
                secret = "";
                repeated = "";
                Console.ResetColor();
                Console.WriteLine("Would you like to play again (Y/N): ");
                response = Console.ReadLine();
                response = response.ToUpper();
                if (response == "Y" || response == "YES")
                {
                    TryAgain = true;
                }
                else
                {
                    TryAgain = false;
                    break;
                }
            }
                Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }      
    }
}
