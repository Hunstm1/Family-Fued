﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fued
{
    public struct Name
    {
        public string firstName;
        public string lastName;
        public string intrest;

    }
    public struct Question
    {
        public string question;
        public string answer;

    }
    class Program
    {
        static void Main()
        {
            Name[] names = new Name[43];
            Read(names);
            Sort(names);
            bool again = true;

            while (again == true)
            {
                string menu = Menu();
               
                switch (menu)
                {
                    case "1":
                        //Console.WriteLine("case 1");
                        Listing(names);
                        break;
                    case "2":
                        // Console.WriteLine("case 2");
                        Update(names);
                        Sort(names);
                        break;
                    case "3":
                        //       Console.WriteLine("case 3");
                        People(names);
                        Play();
                        break;
                    default:
                        again = false;
                        break;
                }
            }
        }

        public static void Listing(Name[] names)
        {
            Console.Clear();
            Console.WriteLine($"{ "".PadRight(68, '-')}");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"|{names[i].firstName.PadRight(20)} | {names[i].lastName.PadRight(20)} | {names[i].intrest.PadRight(20)}|");
                Console.WriteLine($"{ "".PadRight(68, '-')}");
            }

        }

        public static void Update(Name[] names)
        {

            Console.Clear();

            bool many = true;
            int pos = 0;

            while (many == true)
            {
                int count = 0;
                Console.WriteLine("Who would you like to update?");
                string update = Console.ReadLine();



                Console.WriteLine($"{ "".PadRight(68, '-')}");
                for (int i = 0; i < names.Length; i++)
                {
                    if ((names[i].lastName.Contains(update)) || (names[i].firstName.Contains(update)) || (names[i].intrest.Contains(update)))
                    {
                        Console.WriteLine($"|{names[i].firstName.PadRight(20)} | {names[i].lastName.PadRight(20)} | {names[i].intrest.PadRight(20)}|");
                        Console.WriteLine($"{ "".PadRight(68, '-')}");
                        count++;
                        pos = i;

                    }
                }
                if (count != 1)
                {
                    Console.WriteLine("Please be more direct with your search");
                }
                else
                {
                    many = false;
                }
            }
            bool again = true;
            while (again == true)
            {
                Console.WriteLine("What feild would you like to update?" +
                                  "\n: Intrest" +
                                  "\n: First Name" +
                                  "\n: Last Name ");
                switch (Console.ReadLine())
                {
                    case "Intrest":
                        Console.WriteLine("Please enter what you want to change the Intrest to: ");
                        names[pos].intrest = Console.ReadLine();
                        break;
                    case "First Name":
                        Console.WriteLine("Please enter what you want to change the First Name to: ");
                        names[pos].firstName = Console.ReadLine();
                        break;
                    case "Last Name":
                        Console.WriteLine("Please enter what you want to change the Last Name to: ");
                        names[pos].lastName = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please select one of the list");
                        break;

                }
                Console.WriteLine("Would you like to change anything else about this person? (Y/N)");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    again = false;
                    Console.WriteLine("Would you like to update the file with these new changes? (Y/N)");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        StreamWriter sw = new StreamWriter("familyFeud.txt");
                        for (int i = 0; i < names.Length; i++)
                        {
                            sw.WriteLine(names[i].firstName);
                            sw.WriteLine(names[i].lastName);
                            sw.WriteLine(names[i].intrest);
                        }
                        sw.Close();
                    }
                }
            }


            Console.Clear();
        }

        public static void Sort(Name[] names)
        {
            for (int i = 0; i < names.Length - 1; i++)
            {
                for (int pos = 0; pos < names.Length - 1; pos++)
                {
                    if (names[pos + 1].lastName.CompareTo(names[pos].lastName) < 0)
                    {
                        Name temp = names[pos + 1];
                        names[pos + 1] = names[pos];
                        names[pos] = temp;
                    }
                }
            }
        }

        public static void Read(Name[] names)
        {
            StreamReader first = new StreamReader(@"familyFeud.txt");
            for (int i = 0; i < 43; i++)
            {
                names[i].firstName = first.ReadLine();
                names[i].lastName = first.ReadLine();
                names[i].intrest = first.ReadLine();
            }
            first.Close();
        }
        public static string Menu()
        {
            string menu;
            Console.Clear();
            
            
            Console.WriteLine(@"  █████▒▄▄▄       ███▄ ▄███▓ ██▓ ██▓   ▓██   ██▓");
            Console.WriteLine(@"▓██   ▒▒████▄    ▓██▒▀█▀ ██▒▓██▒▓██▒    ▒██  ██▒");
            Console.WriteLine(@"▒████ ░▒██  ▀█▄  ▓██    ▓██░▒██▒▒██░     ▒██ ██░");
            Console.WriteLine(@"░▓█▒  ░░██▄▄▄▄██ ▒██    ▒██ ░██░▒██░     ░ ▐██▓░");
            Console.WriteLine(@"░▒█░    ▓█   ▓██▒▒██▒   ░██▒░██░░██████▒ ░ ██▒▓░");
            Console.WriteLine(@" ▒ ░    ▒▒   ▓▒█░░ ▒░   ░  ░░▓  ░ ▒░▓  ░  ██▒▒▒ ");
            Console.WriteLine(@" ░       ▒   ▒▒ ░░  ░      ░ ▒ ░░ ░ ▒  ░▓██ ░▒░ ");
            Console.WriteLine(@" ░ ░     ░   ▒   ░      ░    ▒ ░  ░ ░   ▒ ▒ ░░  ");
            Console.WriteLine(@"             ░  ░       ░    ░      ░  ░░ ░     ");
            Console.WriteLine(@"                                        ░ ░     ");
           
            Console.WriteLine(@"  █████▒█    ██ ▓█████ ▓█████▄ ");
            Console.WriteLine(@"▓██   ▒ ██  ▓██▒▓█   ▀ ▒██▀ ██▌");
            Console.WriteLine(@"▒████ ░▓██  ▒██░▒███   ░██   █▌");
            Console.WriteLine(@"░▓█▒  ░▓▓█  ░██░▒▓█  ▄ ░▓█▄   ▌");
            Console.WriteLine(@"░▒█░   ▒▒█████▓ ░▒████▒░▒████▓ ");
            Console.WriteLine(@" ▒ ░   ░▒▓▒ ▒ ▒ ░░ ▒░ ░ ▒▒▓  ▒ ");
            Console.WriteLine(@" ░     ░░▒░ ░ ░  ░ ░  ░ ░ ▒  ▒ ");
            Console.WriteLine(@" ░ ░    ░░░ ░ ░    ░    ░ ░  ░ ");
            Console.WriteLine(@"          ░        ░  ░   ░    ");
            Console.WriteLine(@"                        ░      ");

            Thread.Sleep(2500);
            Console.Clear();
            do
            {
                Console.WriteLine("Menu:" +
                                  "\n===========" +
                                  "\n 1:List Database of players" +
                                  "\n 2:Update an entrey" +
                                  "\n 3:Play" +
                                  "\n 0:EXIT" +
                                  "\n===========");              
              menu = Console.ReadLine();
            } while ((menu != "1") && (menu != "2") && (menu != "3") && (menu != "0"));
            return menu;
        }
        public static void Play()
        {
            Console.Clear();
            bool check = true;
            int winCheck = 0;
            int guess = 0;
            int pos = 0;
            int score = 0;
            int totalScore = 0;
            bool won = false;
            String[] show = { "1", "2", "3", "4", "5", "6", "7" };
            String[] showBase = { "1", "2", "3", "4", "5", "6", "7" };
            StreamReader quest = new StreamReader("Questions.txt");
            Question[] questions = new Question[7];




            //Question one
            Console.Clear();
            Console.WriteLine(@"  █████   █    ██ ▓█████   ██████ ▄▄▄█████▓ ██▓ ▒█████   ███▄    █     ▒█████   ███▄    █ ▓█████ ");
            Console.WriteLine(@"▒██▓  ██▒ ██  ▓██▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █    ▒██▒  ██▒ ██ ▀█   █ ▓█   ▀ ");
            Console.WriteLine(@"▒██▒  ██░▓██  ▒██░▒███   ░ ▓██▄   ▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒   ▒██░  ██▒▓██  ▀█ ██▒▒███   ");
            Console.WriteLine(@"░██  █▀ ░▓▓█  ░██░▒▓█  ▄   ▒   ██▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒   ▒██   ██░▓██▒  ▐▌██▒▒▓█  ▄ ");
            Console.WriteLine(@"░▒███▒█▄ ▒▒█████▓ ░▒████▒▒██████▒▒  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░   ░ ████▓▒░▒██░   ▓██░░▒████▒");
            Console.WriteLine(@"░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒    ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ░░ ▒░ ░");
            Console.WriteLine(@" ░ ▒░  ░ ░░▒░ ░ ░  ░ ░  ░░ ░▒  ░ ░    ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░     ░ ▒ ▒░ ░ ░░   ░ ▒░ ░ ░  ░");
            Console.WriteLine(@"   ░   ░  ░░░ ░ ░    ░   ░  ░  ░    ░       ▒ ░░ ░ ░ ▒     ░   ░ ░    ░ ░ ░ ▒     ░   ░ ░    ░   ");
            Console.WriteLine(@"    ░       ░        ░  ░      ░            ░      ░ ░           ░        ░ ░           ░    ░  ░");
            Break();



            questions[0].question = quest.ReadLine();
            for (int i = 0; i < 7; i++)
            {
                questions[i].answer = quest.ReadLine();
            }


            //Testing answers
            string[] quest1 = File.ReadAllLines("Q1Answers.txt");
            for (int i = 0; i < quest1.Length; i++)
            {
                Console.WriteLine(quest1[i]);
            }
            //Testing answers

            do
            {
                Console.Clear();
                Console.WriteLine($"| {questions[0].question} |");
                Console.WriteLine($"| {"*".PadRight(43, '*')} |");
                Console.WriteLine($"| {show[0].PadRight(20, '=')} | {show[4].PadRight(20, '=')} |");
                Console.WriteLine($"| {show[1].PadRight(20, '=')} | {show[5].PadRight(20, '=')} |");
                Console.WriteLine($"| {show[2].PadRight(20, '=')} | {show[6].PadRight(20, '=')} |");
                Console.WriteLine($"| {show[3].PadRight(20, '=')} | {" = ".PadRight(20, '=')} |");
                Console.WriteLine($"| {"*".PadRight(43, '*')} |");

                Console.WriteLine($"Your Score is :  {score}");
                Console.WriteLine($"You have {3 - guess} guesses left");
                Console.Write(": ");
                string user = Console.ReadLine();

                for (int i = 0; i < questions.Length; i++)
                {
                    if (quest1[i].ToLower().Equals(user.ToLower()))
                    {
                        if (show[i] != questions[i].answer)
                        {
                            Correct();
                            show[i] = questions[i].answer;
                            pos = i;
                            score = Score(pos, score);
                            check = false;
                            winCheck++;
                        }
                    }
                }
                if (check == true)
                {
                    Wrong();
                    guess++;
                }
                else
                {
                    check = true;
                }
                if (winCheck == 7)
                {
                    won = true;
                }

                Console.WriteLine(score);

            } while ((guess < 3) || (won == true));
            totalScore = totalScore + 175;
            won = false;

            //Answers

            for (int i = 0; i < questions.Length; i++)
            {
                show[i] = questions[i].answer;
            }
            Console.Clear();
            Console.WriteLine($"| {questions[0].question} |");
            Console.WriteLine($"| {"*".PadRight(43, '*')} |");
            Console.WriteLine($"| {show[0].PadRight(20, '=')} | {show[4].PadRight(20, '=')} |");
            Console.WriteLine($"| {show[1].PadRight(20, '=')} | {show[5].PadRight(20, '=')} |");
            Console.WriteLine($"| {show[2].PadRight(20, '=')} | {show[6].PadRight(20, '=')} |");
            Console.WriteLine($"| {show[3].PadRight(20, '=')} | {" = ".PadRight(20, '=')} |");
            Console.WriteLine($"| {"*".PadRight(43, '*')} |");
            Thread.Sleep(2500);
            //Answers








            Console.Clear();
            Console.WriteLine(@"  █████   █    ██ ▓█████   ██████ ▄▄▄█████▓ ██▓ ▒█████   ███▄    █    ▄▄▄█████▓ █     █░ ▒█████  ");
            Console.WriteLine(@"▒██▓  ██▒ ██  ▓██▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █    ▓  ██▒ ▓▒▓█░ █ ░█░▒██▒  ██▒");
            Console.WriteLine(@"▒██▒  ██░▓██  ▒██░▒███   ░ ▓██▄   ▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒   ▒ ▓██░ ▒░▒█░ █ ░█ ▒██░  ██▒");
            Console.WriteLine(@"░██  █▀ ░▓▓█  ░██░▒▓█  ▄   ▒   ██▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒   ░ ▓██▓ ░ ░█░ █ ░█ ▒██   ██░");
            Console.WriteLine(@"░▒███▒█▄ ▒▒█████▓ ░▒████▒▒██████▒▒  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░     ▒██▒ ░ ░░██▒██▓ ░ ████▓▒░");
            Console.WriteLine(@"░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒      ▒ ░░   ░ ▓░▒ ▒  ░ ▒░▒░▒░ ");
            Console.WriteLine(@" ░ ▒░  ░ ░░▒░ ░ ░  ░ ░  ░░ ░▒  ░ ░    ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░       ░      ▒ ░ ░    ░ ▒ ▒░ ");
            Console.WriteLine(@"   ░   ░  ░░░ ░ ░    ░   ░  ░  ░    ░       ▒ ░░ ░ ░ ▒     ░   ░ ░      ░        ░   ░  ░ ░ ░ ▒  ");
            Console.WriteLine(@"    ░       ░        ░  ░      ░            ░      ░ ░           ░                 ░        ░ ░  ");



            Break();

    
            winCheck = 0;
            Copy(show, showBase);
            guess = 0;
            questions[0].question = quest.ReadLine();
            for (int i = 0; i < 6; i++)
            {
                questions[i].answer = quest.ReadLine();
            }
            quest1 = File.ReadAllLines("Q2Answers.txt");





            do
            {
                Console.Clear();
                Console.WriteLine($"| {questions[0].question}");
                Console.WriteLine($"| {"*".PadRight(63, '*')} |");
                Console.WriteLine($"| {show[0].PadRight(30, '=')} | {show[4].PadRight(30, '=')} |");
                Console.WriteLine($"| {show[1].PadRight(30, '=')} | {show[5].PadRight(30, '=')} |");
                Console.WriteLine($"| {show[2].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
                Console.WriteLine($"| {show[3].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
                Console.WriteLine($"| {"*".PadRight(63, '*')} |");

                Console.WriteLine($"Your Score is :  {score}");
                Console.WriteLine($"You have {3 - guess} guesses left");
                Console.Write(": ");
                string user = Console.ReadLine();

                for (int i = 0; i < quest1.Length; i++)
                {
                    if (quest1[i].ToLower().Equals(user.ToLower()))
                    {
                        if (show[i] != questions[i].answer)
                        {
                            Correct();
                            show[i] = questions[i].answer;
                            pos = i;
                            score = Score(pos, score);
                            check = false;
                            winCheck++;
                        }
                    }

                }

                if (check == true)
                {
                    Wrong();
                    guess++;
                }
                else
                {
                    check = true;
                }
                if (winCheck == 6)
                {
                    won = true;
                }
                Console.WriteLine(score);

            } while (guess < 3);
            totalScore = totalScore + 165;
            won = false;

            //Answers

            for (int i = 0; i < quest1.Length; i++)
            {
                show[i] = questions[i].answer;
            }
            Console.Clear();
            Console.WriteLine($"| {questions[0].question} |");
            Console.WriteLine($"| {"*".PadRight(63, '*')} |");
            Console.WriteLine($"| {show[0].PadRight(30, '=')} | {show[4].PadRight(30, '=')} |");
            Console.WriteLine($"| {show[1].PadRight(30, '=')} | {show[5].PadRight(30, '=')} |");
            Console.WriteLine($"| {show[2].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
            Console.WriteLine($"| {show[3].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
            Console.WriteLine($"| {"*".PadRight(63, '*')} |");
            Thread.Sleep(2500);
            //Answers














            Console.Clear();
     
            Console.WriteLine(@"  █████   █    ██ ▓█████   ██████ ▄▄▄█████▓ ██▓ ▒█████   ███▄    █    ▄▄▄█████▓ ██░ ██  ██▀███  ▓█████ ▓█████ ");
            Console.WriteLine(@"▒██▓  ██▒ ██  ▓██▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █    ▓  ██▒ ▓▒▓██░ ██▒▓██ ▒ ██▒▓█   ▀ ▓█   ▀ ");
            Console.WriteLine(@"▒██▒  ██░▓██  ▒██░▒███   ░ ▓██▄   ▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒   ▒ ▓██░ ▒░▒██▀▀██░▓██ ░▄█ ▒▒███   ▒███   ");
            Console.WriteLine(@"░██  █▀ ░▓▓█  ░██░▒▓█  ▄   ▒   ██▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒   ░ ▓██▓ ░ ░▓█ ░██ ▒██▀▀█▄  ▒▓█  ▄ ▒▓█  ▄ ");
            Console.WriteLine(@"░▒███▒█▄ ▒▒█████▓ ░▒████▒▒██████▒▒  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░     ▒██▒ ░ ░▓█▒░██▓░██▓ ▒██▒░▒████▒░▒████▒");
            Console.WriteLine(@"░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒      ▒ ░░    ▒ ░░▒░▒░ ▒▓ ░▒▓░░░ ▒░ ░░░ ▒░ ░");
            Console.WriteLine(@" ░ ▒░  ░ ░░▒░ ░ ░  ░ ░  ░░ ░▒  ░ ░    ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░       ░     ▒ ░▒░ ░  ░▒ ░ ▒░ ░ ░  ░ ░ ░  ░");
            Console.WriteLine(@"   ░   ░  ░░░ ░ ░    ░   ░  ░  ░    ░       ▒ ░░ ░ ░ ▒     ░   ░ ░      ░       ░  ░░ ░  ░░   ░    ░      ░   ");
            Console.WriteLine(@"    ░       ░        ░  ░      ░            ░      ░ ░           ░              ░  ░  ░   ░        ░  ░   ░  ░");                                                                                  

            Break();





            //Question 3
            winCheck = 0;
            Copy(show,showBase);
            guess = 0;
            questions[0].question = quest.ReadLine();
            for (int i = 0; i < 6; i++)
            {
                questions[i].answer = quest.ReadLine();
            }
            quest1 = File.ReadAllLines("Q3Answers.txt");





            do
            {
                Console.Clear();
                Console.WriteLine($"| {questions[0].question}");
                Console.WriteLine($"| {"*".PadRight(63, '*')} |");
                Console.WriteLine($"| {show[0].PadRight(30, '=')} | {show[4].PadRight(30, '=')} |");
                Console.WriteLine($"| {show[1].PadRight(30, '=')} | {show[5].PadRight(30, '=')} |");
                Console.WriteLine($"| {show[2].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
                Console.WriteLine($"| {show[3].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
                Console.WriteLine($"| {"*".PadRight(63, '*')} |");

                Console.WriteLine($"Your Score is :  {score}");
                Console.WriteLine($"You have {3 - guess} guesses left");
                Console.Write(": ");
                string user = Console.ReadLine();

                for (int i = 0; i < quest1.Length; i++)
                {
                    if (quest1[i].ToLower().Equals(user.ToLower()))
                    {
                        if (show[i] != questions[i].answer)
                        {
                            Correct();
                            show[i] = questions[i].answer;
                            pos = i;
                            score = Score(pos, score);
                            check = false;
                            winCheck++;
                        }
                    }

                }

                if (check == true)
                {
                    Wrong();
                    guess++;
                }
                else
                {
                    check = true;
                }
                if (winCheck == 6)
                {
                    won = true;
                }
                Console.WriteLine(score);

            } while (guess < 3);
            totalScore = totalScore + 165;
            won = false;
            //Answers

            for (int i = 0; i < quest1.Length; i++)
            {
                show[i] = questions[i].answer;
            }
            Console.Clear();
            Console.WriteLine($"| {questions[0].question} |");
            Console.WriteLine($"| {"*".PadRight(63, '*')} |");
            Console.WriteLine($"| {show[0].PadRight(30, '=')} | {show[4].PadRight(30, '=')} |");
            Console.WriteLine($"| {show[1].PadRight(30, '=')} | {show[5].PadRight(30, '=')} |");
            Console.WriteLine($"| {show[2].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
            Console.WriteLine($"| {show[3].PadRight(30, '=')} | {" = ".PadRight(30, '=')} |");
            Console.WriteLine($"| {"*".PadRight(63, '*')} |");
            Thread.Sleep(2500);
            //Answers


            Console.Clear();

            //Final score
            Console.WriteLine("Your final score is..");
            Console.WriteLine(score);
            Console.WriteLine("Out of..");
            Console.WriteLine(totalScore);
            Console.WriteLine("--------------");
            Console.WriteLine("You will be taken back to the main menu");
            Thread.Sleep(4000);

        }

        public static void Break()
        {
            Thread.Sleep(2500);
            Console.Clear();
        }
        public static void Correct()
        {
            Console.Clear();
            
            Console.WriteLine(@" ▄████▄   ▒█████   ██▀███   ██▀███  ▓█████  ▄████▄  ▄▄▄█████▓");
            Console.WriteLine(@"▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓██ ▒ ██▒▓█   ▀ ▒██▀ ▀█  ▓  ██▒ ▓▒");
            Console.WriteLine(@"▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▓██ ░▄█ ▒▒███   ▒▓█    ▄ ▒ ▓██░ ▒░");
            Console.WriteLine(@"▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒██▀▀█▄  ▒▓█  ▄ ▒▓▓▄ ▄██▒░ ▓██▓ ░ ");
            Console.WriteLine(@"▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░██▓ ▒██▒░▒████▒▒ ▓███▀ ░  ▒██▒ ░ ");
            Console.WriteLine(@"░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░ ▒▓ ░▒▓░░░ ▒░ ░░ ░▒ ▒  ░  ▒ ░░   ");
            Console.WriteLine(@"  ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░  ░▒ ░ ▒░ ░ ░  ░  ░  ▒       ░    ");
            Console.WriteLine(@"░        ░ ░ ░ ▒    ░░   ░   ░░   ░    ░   ░          ░      ");
            Console.WriteLine(@"░ ░          ░ ░     ░        ░        ░  ░░ ░               ");
            Console.WriteLine(@"░                                          ░                 ");

            Thread.Sleep(2000);

        }
        public static void Wrong()
        {
            Console.Clear();

            Console.WriteLine(@" █     █░ ██▀███   ▒█████   ███▄    █   ▄████ ");
            Console.WriteLine(@"▓█░ █ ░█░▓██ ▒ ██▒▒██▒  ██▒ ██ ▀█   █  ██▒ ▀█▒");
            Console.WriteLine(@"▒█░ █ ░█ ▓██ ░▄█ ▒▒██░  ██▒▓██  ▀█ ██▒▒██░▄▄▄░");
            Console.WriteLine(@"░█░ █ ░█ ▒██▀▀█▄  ▒██   ██░▓██▒  ▐▌██▒░▓█  ██▓");
            Console.WriteLine(@"░░██▒██▓ ░██▓ ▒██▒░ ████▓▒░▒██░   ▓██░░▒▓███▀▒");
            Console.WriteLine(@"░ ▓░▒ ▒  ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░   ▒ ▒  ░▒   ▒ ");
            Console.WriteLine(@"  ▒ ░ ░    ░▒ ░ ▒░  ░ ▒ ▒░ ░ ░░   ░ ▒░  ░   ░ ");
            Console.WriteLine(@"  ░   ░    ░░   ░ ░ ░ ░ ▒     ░   ░ ░ ░ ░   ░ ");
            Console.WriteLine(@"    ░       ░         ░ ░           ░       ░ ");

            Thread.Sleep(2000);


        }
        public static void Copy(string[] show, string[] showBase)
        {

            for (int i = 0; i < showBase.Length; i++)
            {
                show[i] = showBase[i];
            }
            
        }
        public static int Score(int pos,int score)
        {
            switch (pos)
            {
                case 0:
                    score = score + 40;
                    break;
                case 1:
                    score = score + 35;
                    break;
                case 2:
                    score = score + 30;
                    break;
                case 3:
                    score = score + 25;
                    break;
                case 4:
                    score = score + 20;
                    break;
                case 5:
                    score = score + 15;
                    break;
                case 6:
                    score = score + 10;
                    break;
                default:
                    Console.WriteLine("not an option");
                    break;
            }
            return score;
        }
        public static Name People(Name[] names)
        {
            Console.Clear();
            Random rand = new Random();

            Name[] thing = new Name[10];
            int[] people = new int[10];
            int temp;
            for (int i = 0; i < people.Length; i++)
            {
                temp = rand.Next(0, 42);
                for (int t = 0; t < people.Length; t++)
                {
                    while (people[t] == temp)
                    {
                        temp = rand.Next(0, 42);
                    }
                }
                people[i] = temp;

            }

            Console.WriteLine("Here are your 10 Finilests");
            Console.WriteLine($"{ "".PadRight(68, '-')}");
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"| {names[people[i]].firstName.PadRight(20)} | {names[people[i]].lastName.PadRight(20)} | {names[people[i]].intrest.PadRight(20)}|");
                Console.WriteLine($"{ "".PadRight(68, '-')}");

                thing[i].firstName=names[people[i]].firstName;
                thing[i].lastName=names[people[i]].lastName;
                thing[i].intrest = names[people[i]].intrest;
            }
            Console.WriteLine("Press enter to get your winner");
            Console.ReadLine();
            Console.WriteLine("Your Winner is.... ");
            Thread.Sleep(1000);
            Name person = thing[rand.Next(0, 10)];
            Console.WriteLine($"{ "".PadRight(68, '-')}");
            Console.WriteLine($"| {person.firstName.PadRight(20)} | {person.lastName.PadRight(20)} | {person.intrest.PadRight(20)}|");
            Console.WriteLine($"{ "".PadRight(68, '-')}");
            Thread.Sleep(2000);
            return person;
        }










    }
}