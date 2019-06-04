using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public string answer5;
        public string answer6;
        public string answer7;
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

                Console.WriteLine(menu);
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
                        Play();
                        break;
                }
            }
            Console.ReadLine();
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
            int pos=0;

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


            Console.WriteLine("Family Fued");
            Console.WriteLine("===========");
            Console.WriteLine("Menu:" +
                              "\n===========" +
                              "\n 1:List Database of players" +
                              "\n 2:Update an entrey" +
                              "\n 3:Play" +
                              "\n===========");
            string menu = Console.ReadLine();

            while ((menu != "1") && (menu != "2") && (menu != "3"))
            {
                Console.WriteLine("Option not included, please try again.");
                Console.WriteLine("Menu:" +
                                  "\n===========" +
                                  "\n 1:List Database of players" +
                                  "\n 2:Update an entrey" +
                                  "\n 3:Play" +
                                  "\n===========");
                menu = Console.ReadLine();
            }
            return menu;
        }
        public static void Play()
        {
            Console.Clear();
            Question questions;

            StreamReader quest = new StreamReader("Questions.txt");
            questions.question = quest.ReadLine();
            questions.answer1 = quest.ReadLine();
            questions.answer2 = quest.ReadLine();
            questions.answer3 = quest.ReadLine();
            questions.answer4 = quest.ReadLine();
            questions.answer5 = quest.ReadLine();
            questions.answer6 = quest.ReadLine();
            questions.answer7 = quest.ReadLine();
            


            
            
           

        }










    }
}