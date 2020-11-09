using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thief_And_Police
{
    class View
    {
        /// <summary>
        /// A method that prints the menu
        /// </summary>
        /// <returns>Returns the user's choice in one array</returns>
        public static int[] Menu()
        {
            Console.WriteLine("Welcome to the Thief and Police Simulator");
            Console.WriteLine("Please enter the city size with y and X coordinates");

            Console.Write("Y: ");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("X: ");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Please provide information about the city's residents");

            Console.Write("Number of decent Citizens: ");
            int citizens = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Number of Police Officers: ");
            int policeOfficers = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Number of Thieves: ");
            int thieves = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Clear();
            Console.Write("Thanks, please wait, your simulator is generated");
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    Console.Clear();
                    Console.Write("Thanks, please wait, your simulator is generated");
                }
                Console.Write(".");
                Thread.Sleep(300);

            }
            return new int[] { y, x, citizens, policeOfficers, thieves };
        }

        /// <summary>
        /// A method that prints the city and its inhabitants
        /// </summary>
        /// <param name="person">the location of a person in the city</param>
        public static void PrintCity(Person person)
        {
            if (person == null)
            {
                Console.Write(" ");
            }
            else if (person.InPrison)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write(person.Name);
            }
        }

        /// <summary>
        /// A method that prints X in the event of a collision between thieves, police and citizens
        /// </summary>
        /// <param name="color"> The color on X</param>
        public static void PrintCollision(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write("X");
            Console.ResetColor();
        }

        /// <summary>
        /// A method that prints a city's incidents
        /// </summary>
        /// <param name="incidents"> The log of incidents from the city</param>
        public static void PrintCityIncidents(List<string> incidents)
        {
            Console.WriteLine();
            Console.WriteLine("__________________EVENTS_________________");
            if (incidents.Any())
            {
                foreach (var message in incidents)
                {
                    Console.WriteLine($"* {message}");
                }
                Thread.Sleep(2000);
                incidents.Clear();
            }
        }

        /// <summary>
        /// A method that prints a city's Statistics
        /// </summary>
        /// <param name="city">The city</param>
        public static void PrintCityStatistics(City city)
        {
            Console.WriteLine();
            Console.WriteLine("________________STATISTICS_______________");
            Console.WriteLine($"Number of inhabitants: {city.Inhabitants.Count + city.Prison.Count}");
            Console.WriteLine($"Robbed citizens: {city.Robberies}");
            Console.WriteLine($"Arrested thieves: {city.Arrested}");
            Console.WriteLine($"Thieves in prison: {city.Prison.Count}");
            /*Remove comments to see more information*/
            //PrintStolenItems(city.Inhabitants);
            //PrintConfiscateItems(city.Inhabitants);
        }

        /// <summary>
        /// A method that prints a city's PrisonInformation
        /// </summary>
        /// <param name="prison"> The city prison</param>
        public static void PrintPrisonInformation(List<Person> prison)
        {
            Console.WriteLine();
            Console.WriteLine("_______________ THE PRISON ______________");
            Console.WriteLine();
            foreach (var person in prison)
            {
                Console.WriteLine($"* Thief({person.ID}) {person.TimeInPrison} seconds");
            }
        }


        /// <summary>
        /// A method that prints Stolen Items from the city's citizens
        /// </summary>
        /// <param name="inhabitants"> The inhabitants from the city</param>
        private static void PrintStolenItems(List<Person> inhabitants)
        {
            int totalValue = 0;
            Console.WriteLine(); 
            Console.WriteLine("______________STOLE BELONGS _____________");
            Console.WriteLine();
            foreach (var thief in inhabitants)
            {
                if (thief is Thief)
                {
                    foreach (var item in thief.Inventory)
                    {
                        Console.WriteLine($"* {item.Name} Belong to citizen({item.ID})");
                        totalValue += item.Value;
                    }
                }
            }
            //Console.WriteLine($"Value of confiscate belongings: {totalValue}kr");
        }

        /// <summary>
        ///  A method that prints police Confiscated Items from the city's Thiefs
        /// </summary>
        /// <param name="inhabitants">The inhabitants from the city</param>
        private static void PrintConfiscateItems(List<Person> inhabitants)
        {
            int totalValue = 0;
            Console.WriteLine();
            Console.WriteLine("__________CONFISCATE BELONGINGS__________");
            Console.WriteLine();
            foreach (var police in inhabitants)
            {

                if (police is Police)
                {
                    foreach (var item in police.Inventory)
                    {
                        Console.WriteLine($"* {item.Name} Belong to citizen({item.ID})");
                        totalValue += item.Value;
                    }
                }
            }
            // Console.WriteLine($"Value of confiscate belongings: {totalValue}kr");
        }
    }
}
