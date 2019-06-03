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

            string menu = Menu();

            Console.WriteLine(menu);
            switch (menu)
            {
                case "1":
                    Console.WriteLine("case 1");
                    Listing();
                    break;
                case "2":
                    Console.WriteLine("case 2");
                    Update();
                    break;
                case "3":
                    Console.WriteLine("case 3");
                    Play();
                    break;
            }
            Console.ReadLine();
        }

        public static void Listing()
        {

        }
        public static void Update()
        {

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
            StringReader sr = new StringReader(@"familyFeud.txt");
            for (int i = 0; i < 43; i++)
            {
                names(i).firstName = sr.ReadLine();
            }
        }

    }
}