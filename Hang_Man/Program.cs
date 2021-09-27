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

            string[] Names = new string[10] {"maximilian","alessandro","kristopher","abdirahman","montgomery","chancellor","jeancarlos","christiano","wellington","princeston"};
            Random rand = new Random();
            bool TryAgain=true;
            string secret = "";
            string repeated = "";
            string response_2;
            string unrevealed = Names[rand.Next(0, 9)];
            char output;
            List<char> TempList_1 = new List<char>();
            List<char> TempList_2 = new List<char>();
            List<char> TempList_3 = new List<char>();
            List<string> TempList_4 = new List<string>();
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
                            Console.WriteLine("Congratulations! You have revealed the secret");
                            Console.WriteLine($"The secret is  {unrevealed}");
                            live = 0;                           
                            TempList_1.Clear();
                            TempList_2.Clear();
                            TempList_3.Clear();
                            TempList_4.Clear();                           
                            unrevealed = Names[rand.Next(0, 9)];
                            for (int i = 0; i < 10; i++)
                            {
                                TempList_1.Add(unrevealed[i]);
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                TempList_2.Add('_');
                            }
                            break;
                        }
                        else
                        {
                            if (live == 10)
                            {
                                Console.WriteLine("Sorry, you cound not find the secret.");
                            }
                            else
                            {
                                Console.WriteLine(secret);

                                foreach (char c in repeated)
                                {
                                    TempList_3.Add(c);
                                }
                                if (!TempList_4.Contains(value_2))
                                {
                                    TempList_4.Add(value_2);
                                    live++;
                                }
                                Console.ResetColor();
                                if (TempList_4.Count() > 0 && TempList_3.Count > 0)
                                {
                                    Console.WriteLine("You have guessed these letters and words, but they are not match secret word");
                                }
                                else if (TempList_4.Count() == 1)
                                {
                                    Console.WriteLine("You have guessed this word, but it is not match secret word");

                                }
                                else if (TempList_4.Count() > 1)
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

                                foreach (string c in TempList_4)
                                {
                                    Console.Write($"{c} ");
                                }
                                value_2 = "";
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                foreach (char c in TempList_3)
                                {
                                    Console.Write($"{c} ");
                                }
                                TempList_3.Clear();
                                Console.WriteLine();
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
                        foreach (char c in TempList_2)
                        {
                            secret += c.ToString();
                        }

                        if (secret == unrevealed)
                        {
                            Console.WriteLine("Congratulations! You have revealed the secret");
                            Console.WriteLine($"The secret is  {unrevealed}");
                            TempList_1.Clear();
                            TempList_2.Clear();
                            TempList_3.Clear();
                            TempList_4.Clear();
                            unrevealed = Names[rand.Next(0, 9)];
                            for (int i = 0; i < 10; i++)
                            {
                                TempList_1.Add(unrevealed[i]);
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                TempList_2.Add('_');
                            }
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
                                foreach (char c in TempList_3)
                                {
                                    Console.Write($"{c} ");
                                }
                                foreach (string c in TempList_4)
                                {
                                    Console.Write($"{c} ");
                                }
                                TempList_3.Clear();
                                Console.WriteLine();                               
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
