using The_Harbour_Console_App.Model;
using The_Harbour_Console_App.Model.Classes;
using System;
using System.IO;
using System.Linq;

namespace The_Harbour_Console_App.Data
{
    static class FileManagement
    {
        public static string source = Path.GetFullPath(Environment.CurrentDirectory + "/../../../Data/HarborData.csv");
        public static string sourceSettings = Path.GetFullPath(Environment.CurrentDirectory + "/../../../Data/HarborHistory.csv");
        public static Berth[] OpenFromFile(int size)
        {
            Berth[] berths = new Berth[size];
            for (int i = 0; i < berths.Length; i++)
            {
                berths[i] = new Berth();
                berths[i].Id = i;
            }

            foreach (string line in File.ReadAllLines(source))
            {
                try
                {
                    Boat RecreatedBoat = null;
                    string[] file = line.Split(' ', '-');
                    int currentBerth = int.Parse(file[1]);
                    string id = $"{file[6]}-{file[7]}";
                    string type = file[4];
                    int weight = int.Parse(file[9]);
                    int maxSpeed = int.Parse(file[11]);
                    double berthSize = double.Parse(file[13]);
                    int berthTime = int.Parse(file[15]);
                    int uniqe = int.Parse(file[18]);
                    if (type == "Roddbåt")
                        RecreatedBoat = new Rowboat(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                    if (type == "Motorbåt")
                        RecreatedBoat = new MotorBoat(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                    if (type == "Segelbåt")
                        RecreatedBoat = new Sailboat(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);
                    if (type == "Lastfartyg")
                        RecreatedBoat = new CargoShip(id, type, weight, maxSpeed, berthTime, berthSize, currentBerth, uniqe);

                    for (int i = (int)RecreatedBoat.CurrentBerth; i < RecreatedBoat.CurrentBerth + RecreatedBoat.BerthSize; i++)
                    {
                        berths[i].ParkedBoats.Add(RecreatedBoat);
                        if (RecreatedBoat is Rowboat)
                            berths[i].ContainsRowboat = true;
                    }
                }
                catch
                {
                }
            }
            return berths.ToArray();
        }


        public static void SaveToFile(Berth[] Berths)
        {
            var SaveBerthsInfoToFile = Berths
             .GroupBy(b => b.ToString())
             .Select(b => b.First());

            File.WriteAllLines(source, SaveBerthsInfoToFile
                .Select(b => b.ToString())
                .ToArray());
        }


        public static void SaveToHistoryFile(int RejectedBoats, int Days)
        {
            string[] settings = new string[] { RejectedBoats.ToString(), Days.ToString() };
            File.WriteAllLines(sourceSettings, settings);
        }
        public static int LoadRejectedBoatsFromHistoryFile()
        {
            return int.Parse(File.ReadAllLines(sourceSettings).First());
        }
        public static int LoadDaysBoatsFromHistoryFile()
        {
            return int.Parse(File.ReadAllLines(sourceSettings).Last());
        }
    }
}
