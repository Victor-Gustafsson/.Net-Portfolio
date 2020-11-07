using static The_Harbour_Console_App.Model.HarborCalculations;
using static The_Harbour_Console_App.Data.FileManagement;
using The_Harbour_Console_App.Model;
using System.Linq;
using System.IO;
using System;


namespace The_Harbour_Console_App.View
{
    class ConsoleView
    {
        private readonly Harbor Harbor;
        public ConsoleView(Harbor model)
        {
            Harbor = model;
        }

        private void PrintHead()
        {
            Console.WriteLine("  _____________________________________________________________________________________________");
            Console.WriteLine(" |                                                                ------                       |");
            Console.WriteLine(" |  |     |       /\\          /\\        /\\          /\\        /  |           /\\        /       |");
            Console.WriteLine(" |  |     |      /  \\        /  \\      /  \\        /  \\      /   |          /  \\      /        |");
            Console.WriteLine(" |  |-----|     /- - \\      /    \\    /    \\      /    \\    /    |------   /    \\    /         |");
            Console.WriteLine(" |  |     |    /      \\    /      \\  /      \\    /      \\  /     |        /      \\  /          |");
            Console.WriteLine(" |  |     |   /        \\  /        \\/        \\  /        \\/       ------ /        \\/           |");
            Console.WriteLine(" |                                                                                             |");
            Console.WriteLine("  ---------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
        public void PrintBoatsInHabour()
        {
            PrintHead();
            Console.WriteLine("Plats\tBåttyp\t\tNr\t\tVikt\t\tMaxhast\t\tÖvrigt");
            Console.WriteLine("-------\t-------\t\t-------\t\t-------\t\t-------\t\t-------");
            foreach (string line in File.ReadAllLines(source))
            {
                try
                {
                    string[] file = line.Split(' ', '-');
                    int start = int.Parse(file[1]);
                    string id = $"{file[6]}-{file[7]}";
                    string type = file[4];
                    int weight = int.Parse(file[9]);
                    double maxSpeed = ConvertKnopToKMh(int.Parse(file[11]));
                    double berthSize = double.Parse(file[13]);
                    int berthTime = int.Parse(file[15]);
                    int uniqe = int.Parse(file[18]);


                    if (type == "Roddbåt")
                        Console.WriteLine($"{start}\t{type} \t{id}\t\t{weight}\t\t{maxSpeed} Kmh\t\tMax Antal pers:{uniqe} st");
                    else if (type == "Motorbåt")
                        Console.WriteLine($"{start}\t{type}\t{id}\t\t{weight}\t\t{maxSpeed} Kmh\t\tHärstkrafter:{uniqe} st");
                    else if (type == "Segelbåt")
                    {
                        int end = int.Parse(file[2]);
                        Console.WriteLine($"{start}-{end}\t{type}\t{id}\t\t{weight}\t\t{maxSpeed} Kmh\t\tBåtlängd:{uniqe} m");
                    }
                    else if (type == "Lastfartyg")
                    {
                        int end = int.Parse(file[2]);
                        Console.WriteLine($"{start}-{end}\t{type}\t{id}\t\t{weight}\t\t{maxSpeed} Kmh\t\tContainers:{uniqe} st");
                    }
                }
                catch
                {
                    string[] file = line.Split(' ', '-');
                    Console.WriteLine($"{file[1]}\t{file[2]}");
                }
            }
            PrintHabourFacts();
            PrintBoatsCheckOut();
            PrintBoatsCheckIn();
            PrintBoatsRejected();
        }

        private void PrintHabourFacts()
        {
            Console.WriteLine();
            Console.WriteLine($"Antal Båtar ({CountTotalNumberOfBoats(Harbor.Berths)})");
            Console.WriteLine("-----------");
            Console.WriteLine($"Roddbåtar: {CountRowboats(Harbor.Berths)} st");
            Console.WriteLine($"Motorbåtar: {CountMotorBoats(Harbor.Berths)} st");
            Console.WriteLine($"Segelbåtar: {CountSailboats(Harbor.Berths)} st");
            Console.WriteLine($"Lastfartyg: {CountCargoShips(Harbor.Berths)} st");
            Console.WriteLine();
            Console.WriteLine("Övrigt");
            Console.WriteLine("-----------");
            Console.WriteLine($"Antalet avisade båtar: {Harbor.RejectedBoats} st");
            Console.WriteLine($"Antal Dagar: {Harbor.Days} st");
            Console.WriteLine($"Antal lediga platser: {Harbor.NumberOfAvailableBerths} st");
            Console.WriteLine($"Total vikt I hamnen: {Harbor.TotalBoatWeight} kg");
            Console.WriteLine($"Medeltal av alla båtars maxhastighet: {Harbor.AverageOfAllBoatsMaximumSpeed} Km/h");
            Console.WriteLine();
        }

        private void PrintBoatsCheckOut()
        {
            var TodaysCheckOuts = Harbor.TodaysCheckOuts
           .GroupBy(b => b.ToString())
           .Select(b => b.First());
            Console.WriteLine($"Checkar ut ({TodaysCheckOuts.Count()})");
            Console.WriteLine("-----------");
            
            foreach (var boat in TodaysCheckOuts)
            {
                Console.WriteLine(boat.Typ +" "+ boat.Id);
            }
            Console.WriteLine();
        }

        private void PrintBoatsCheckIn()
        {
            var TodaysCheckIns = Harbor.TodaysCheckIns
           .GroupBy(b => b.ToString())
           .Select(b => b.First());
            Console.WriteLine($"Checkar in ({TodaysCheckIns.Count()})");
            Console.WriteLine("-----------");

            foreach (var boat in TodaysCheckIns)
            {
                Console.WriteLine(boat.Typ +" "+ boat.Id);
            }
            Console.WriteLine();
        }

        private void PrintBoatsRejected()
        {
            var TodaysRejected = Harbor.TodaysRejected
           .GroupBy(b => b.ToString())
           .Select(b => b.First());
            Console.WriteLine($"Avisade ({TodaysRejected.Count()})");
            Console.WriteLine("-----------");

            foreach (var boat in TodaysRejected)
            {
                Console.WriteLine(boat.Typ +" "+ boat.Id);
            }
        }

    }
}

