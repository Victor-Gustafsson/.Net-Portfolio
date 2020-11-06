using The_Harbour.Model;
using The_Harbour.Model.Classes;
using System;
using System.IO;
using System.Linq;

namespace The_Harbour.Data
{
    static class FileManagement
    {
        public static string BerthOne = Path.GetFullPath(Environment.CurrentDirectory + "/../../../Data/BerthOne.csv");
        public static string BerthTwo = Path.GetFullPath(Environment.CurrentDirectory + "/../../../Data/BerthTwo.csv");
        public static string sourceSettings = Path.GetFullPath(Environment.CurrentDirectory + "/../../../Data/HarbourHistory.csv");
        public static Berth[] Berth_From_File(int size, string source)
        {
            //Create a new empty berth
            Berth[] BerthFromFile = new Berth[size];
            for (int i = 0; i < BerthFromFile.Length; i++)
            {
                BerthFromFile[i] = new Berth();
                BerthFromFile[i].Id = i;
            }
            foreach (string line in File.ReadAllLines(source))
            {
                Boat RecreatedBoat = Recreate_Boat_From_File(line);
                if (RecreatedBoat != null)
                {
                    for (int i = (int)RecreatedBoat.CurrentBerth; i < RecreatedBoat.CurrentBerth + RecreatedBoat.BerthSize; i++)
                    {
                        BerthFromFile[i].ParkedBoats.Add(RecreatedBoat);
                        if (RecreatedBoat is Rowboat)
                            BerthFromFile[i].ContainsRowboat = true;
                    }
                }
            }
            return BerthFromFile.ToArray();
        }

        private static Boat Recreate_Boat_From_File(string line)
        {
            Boat RecreatedBoat = null;
            string[] file = line.Split(' ', '-');
            if (file.Count() > 3)
            {
                int currentBerth = int.Parse(file[1]);
                string id = $"{file[6]}-{file[7]}";
                string type = file[4];
                int weight = int.Parse(file[9]);
                int maxSpeed = int.Parse(file[11]);
                double berthSize = double.Parse(file[13]);
                int berthTime = int.Parse(file[15]);
                int uniqe = int.Parse(file[18]);
                if (type == "Rowboat")
                    RecreatedBoat = new Rowboat(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                if (type == "PowerBoat")
                    RecreatedBoat = new MotorBoat(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                if (type == "Sailboat")
                    RecreatedBoat = new Sailboat(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                if (type == "CargoShip")
                    RecreatedBoat = new CargoShip(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                if (type == "Catamaran")
                    RecreatedBoat = new Catamaran(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
            }
            return RecreatedBoat;
        }

        public static void SaveToFile(Berth[] first, Berth[] second)
        {
            //Save The first Berth to file "BerthOne"
            File.WriteAllLines(BerthOne, first
                    .GroupBy(b => b.ToString())
                     .Select(b => b.First())
                     .Select(b => b.ToString())
                     .ToArray());

            //Save The second Berth to file "BerthOne"
            File.WriteAllLines(BerthTwo, second
                    .GroupBy(b => b.ToString())
                     .Select(b => b.First())
                     .Select(b => b.ToString())
                     .ToArray());
        }


        public static void Save_Rejected_Boats_And_Total_Days_To_History_File(int RejectedBoats, int Days)
        {
            string[] settings = new string[] { RejectedBoats.ToString(), Days.ToString() };
            File.WriteAllLines(sourceSettings, settings);
        }

        public static int Load_Rejected_Boats_From_History_File()
        {
            return int.Parse(File.ReadAllLines(sourceSettings).First());
        }

        public static int Load_Total_Number_Of_Days__From_History_File()
        {
            return int.Parse(File.ReadAllLines(sourceSettings).Last());
        }
    }
}
