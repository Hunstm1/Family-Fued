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
    class Program
    {
       static void Main()
        {
            Name[] names = new Name[43];
            Read(names);
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
                        break;
                    case "3":
                        Console.WriteLine("case 3");
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
                        int pos = i;
                        
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
                        break;
                    case "First Name":
                        break;
                    case "Last Name":
                        break;
                    default:
                        Console.WriteLine("Please select one of the list");
                        break;

                }
                Console.WriteLine("Would you like to change anything else about this person? (Y/N)");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    again = false;
                }
            }


            Console.Clear();
        }
        public static void Play()
        {

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





        public static void Read(Name[] names)
        {
            StreamReader sr = new StreamReader(@"familyFeud.txt");
            for (int i = 0; i < 43; i++)
            {
                names[i].firstName = sr.ReadLine();
                names[i].lastName = sr.ReadLine();
                names[i].intrest = sr.ReadLine();
            }
            sr.Close();
        }

    }
}