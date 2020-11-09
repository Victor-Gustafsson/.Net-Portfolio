using System;
using System.Collections.Generic;
using static Thief_And_Police.View;
using static Thief_And_Police.Collision;
namespace Thief_And_Police
{
    class City
    {
        public int PoliceOfficers;
        public int Citizens;
        public int Thieves;
        public Person[,] city;
        public List<Person> Inhabitants;

        public int Robberies;
        public int Arrested;
        public List<string> Incidents;
        public List<Person> Prison;
        public City(int y, int x, int citizens, int policeOfficers, int thieves)
        {
            city = new Person[y, x];
            Citizens = citizens;
            PoliceOfficers = policeOfficers;
            Thieves = thieves;
            Inhabitants = RandomCitizens.CreateInhabitants(Citizens, PoliceOfficers, Thieves, city.GetLength(0), city.GetLength(1));
            Incidents = new List<string>();
            Prison = new List<Person>();
            RunCity();
        }

        public void RunCity()
        {
            for (int y = 0; y < city.GetLength(0); y++)
            {
                for (int x = 0; x < city.GetLength(1); x++)
                {
                    foreach (var person in Inhabitants)
                    {
                        if (person.Y == y && person.X == x)
                        {
                            if (ThievesIsRobbing(city[y, x], person, Incidents))
                            {
                                PrintCollision(ConsoleColor.Red);
                                Robberies++;
                                city[y, x] = null;
                            }
                            if (PoliceIsArresting(city[y, x], person, Incidents))
                            {
                                PrintCollision(ConsoleColor.Green);
                                Arrested++;
                                city[y, x] = null;
                            }
                            else
                                city[y, x] = person;
                        }
                    }
                    PrintCity(city[y, x]);
                }
                Console.WriteLine();
            }
            PrintCityStatistics(this);
            PrintPrisonInformation(Prison);
            PrintCityIncidents(Incidents);
        }
        public void MoveCitizens()
        {
            GoOrLeavePrison();

            foreach (var person in Inhabitants)
            {
                city[person.Y, person.X] = null;
                if (person.X == 0 && person.Xdirection == -1)
                {
                    person.X = (city.GetLength(1) - 1);
                }
                if (person.X == (city.GetLength(1) - 1) && person.Xdirection == 1)
                {
                    person.X = 0;
                }
                if (person.Y == 0 && person.Ydirection == -1)
                {
                    person.Y = city.GetLength(0) - 1;
                }
                if (person.Y == (city.GetLength(0) - 1) && person.Ydirection == 1)
                {
                    person.Y = 0;
                }
                person.Move();
            }
            RunCity();
        }

        private void GoOrLeavePrison()
        {
            // Add Theif to prison
            for (int i = Inhabitants.Count - 1; i >= 0; i--)
            {
                if (Inhabitants[i].InPrison && Inhabitants[i].TimeInPrison == 0)
                {
                    Prison.Add(Inhabitants[i]);
                    Inhabitants.RemoveAt(i);
                }
            }

            // Release Thief or increase time in prison
            for (int i = Prison.Count - 1; i >= 0; i--)
            {
                if (Prison[i].TimeInPrison >= 30)
                {
                    Prison[i].TimeInPrison = 0;
                    Prison[i].InPrison = false;
                    Inhabitants.Add(Prison[i]);
                    Incidents.Add($"Thief({Prison[i].ID}) released from prison");
                    Prison.RemoveAt(i);
                }
                else
                {
                    Prison[i].TimeInPrison++;
                }
            }
        }
    }
}



