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
            Console.WriteLine(" 1) Hangman Game");      
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
        private static void doCustomCode(Action action)
        {
            action();  
        }

        private static string RunExerciseOne()
        {
            Console.Clear();             

            string[] Names = new string[10] {"maximilian","alessandro","kristopher","abdirahman","montgomery","chancellor","jeancarlos","christiano","wellington","princeston"};
            Random rand = new Random();
            bool TryAgain=true;
            string secret = "";
            string repeated = "";
            string response_2;
            string unrevealed = Names[rand.Next(0, 9)];
            char output;
            char[] CharArr_1=new char[10];
            char[] CharArr_2=new char[10];                    
            List<char> TempList_3 = new List<char>();
            List<string> TempList_4 = new List<string>();         
            for (int i = 0; i < 10; i++)
            {
                CharArr_1[i] = unrevealed[i];
            }         
            for (int i = 0; i < 10; i++)
            {
                CharArr_2[i] = '_';
            }
            string response;
            int live = 0;
            while (TryAgain)
            {
                
                while (live < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Welcome to Hangman Game");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Guess for a {unrevealed.Length} letter Word ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"You have {10 - live} life");
                    Console.ResetColor();
                    Console.WriteLine("If you want guess a letter, enter 'l' or 'letter'");
                    Console.WriteLine("If you want guess the secret word, enter 'w' or 'word'");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    response_2 = Console.ReadLine();
                    response_2 = response_2.ToUpper();
                    if (response_2 == "W" || response_2 == "WORD")
                    {
                        Console.WriteLine("Enter your guessed secret word");
                        string value_2 = Console.ReadLine();
                        while (value_2?.Length != 10)
                        {
                            Console.WriteLine("Your secret word has to contain ten letters!");
                            value_2 = Console.ReadLine();
                        }
                        if (value_2 == unrevealed)
                        {                       
                            doCustomCode_1();
                            break;
                        }
                        else
                        {
                            if (live == 9)
                            {
                                Console.WriteLine("Sorry, you cound not find the secret.");
                                break;
                            }
                            else
                            {                               
                                if (!TempList_4.Contains(value_2))
                                {
                                    TempList_4.Add(value_2);
                                    live++;
                                }
                                doCustomCode_2();                         
                                value_2 = "";                             
                                secret = "";
                            }
                        }
                    }
                    else if (response_2 == "L" || response_2 == "LETTER")
                    {
                        secret = "";
                        Console.WriteLine("Enter your guessed letter");
                        string val = Console.ReadLine();
                        while (!char.TryParse(val, out output))
                        {
                            Console.WriteLine("Enter just a letter");
                            val = Console.ReadLine();
                        }                    
                        if (!CharArr_1.Contains(output) && !repeated.Contains(output) && !unrevealed.Contains(output))
                        {
                            live++;
                            repeated += output.ToString();
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            if (CharArr_1[i] == output)
                            {
                                CharArr_2[i] = output;
                            }
                        }
                        foreach (char c in CharArr_2)
                        {
                            secret += c.ToString();
                        }

                        if (secret == unrevealed)
                        {                       
                            doCustomCode_1();
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
                                doCustomCode_2();                                                        
                            }
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
                    live = 0;
                }
                else
                {
                    TryAgain = false;
                    break;
                }

            }
            void doCustomCode_1()
            {
                Console.Clear();              
                Console.WriteLine("Congratulations! You have revealed the secret");
                Console.WriteLine($"The secret is  {unrevealed}");
                TempList_3.Clear();
                TempList_4.Clear();
                unrevealed = Names[rand.Next(0, 9)];
                for (int i = 0; i < 10; i++)
                {
                    CharArr_1[i] = unrevealed[i];
                }
                for (int i = 0; i < 10; i++)
                {
                    CharArr_2[i] = '_';
                }

            }
            void doCustomCode_2()
            {             
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is your revealed letters of the secret word");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(secret);               
                foreach (char c in repeated)
                {
                    TempList_3.Add(c);
                }
                Console.ResetColor();
                if (TempList_4.Count() > 0 && TempList_3.Count > 0)
                {
                    Console.WriteLine("You have guessed these letters and words, but they are not match secret word");
                }
                else if (TempList_4.Count() > 0)
                {
                    Console.WriteLine("You have guessed these words, but they are not match secret word");

                }
                else if (TempList_3.Count() == 1)
                {
                    Console.WriteLine("You have guessed this letter, but it is not match secret word");
                }
                else if (TempList_3.Count() > 1)
                {
                    Console.WriteLine("You have guessed these letters, but they are not match secret word");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                StringBuilder sb = new StringBuilder();
                foreach (string c in TempList_4)
                {
                    Console.Write($"{c} ");
                }
                foreach (char c in TempList_3)
                {
                    sb.Append($"{c} ");
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Console.WriteLine(sb);
                TempList_3.Clear();
                Console.WriteLine();
            }
                Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }      
    }
}
