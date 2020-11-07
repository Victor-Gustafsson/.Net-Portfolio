using The_Harbour_Console_App.Model.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static The_Harbour_Console_App.Data.FileManagement;
using static The_Harbour_Console_App.Model.HarborCalculations;

namespace The_Harbour_Console_App.Model
{
    class Harbor
    {
        public Berth[] Berths;
        public List<Boat> TodaysCheckOuts = new List<Boat>();
        public List<Boat> TodaysCheckIns = new List<Boat>();
        public List<Boat> TodaysRejected = new List<Boat>();
        public int RejectedBoats;
        public int Days;
        public double TotalBoatWeight;
        public double AverageOfAllBoatsMaximumSpeed;
        public double NumberOfAvailableBerths;
        public Harbor(int Size)
        {
            Berths = new Berth[Size];
            for (int i = 0; i < Size; i++)
            {
                Berths[i] = new Berth();
                Berths[i].Id = i;
            }


            if (File.Exists(source))
            {
                Berths = OpenFromFile(Size);
                UpdateHarbourStatistics(Berths);
                RejectedBoats = LoadRejectedBoatsFromHistoryFile();
                Days = LoadDaysBoatsFromHistoryFile();
            }
            else
                File.Create(source).Close();
        }



        public void BoatsCheckIns(List<Boat> ArrivingBoats)
        {
            TodaysCheckIns.Clear();
            TodaysRejected.Clear();
            foreach (var boat in ArrivingBoats)
            {
                if (!DockToBerth(boat))
                {
                    RejectedBoats++;
                    TodaysRejected.Add(boat);
                }
                else
                {
                    TodaysCheckIns.Add(boat);
                }
            }
            Days++;
            UpdateHarbourStatistics(Berths);
            SaveToFile(Berths);
            SaveToHistoryFile(RejectedBoats,Days);
        }

        public void BoatsCheckOuts()
        {
            TodaysCheckOuts.Clear();
            foreach (var Berth in Berths)
            {
                foreach (var boat in Berth.ParkedBoats.ToList())
                {
                    if (boat.BerthTime == 0)
                    {
                        TodaysCheckOuts.Add(boat);
                        Berth.ParkedBoats.Remove(boat);
                    }
                }
                if (!Berth.ParkedBoats.Any())
                {
                    Berth.ContainsRowboat = false;
                }
            }
            UpdateHarbourStatistics(Berths);
            SaveToFile(Berths);
            SaveToHistoryFile(RejectedBoats, Days);
        }

        public bool DockToBerth(Boat boat)
        {
            bool IsAnRowboat = boat is Rowboat;
            int spaceNeeded = IsAnRowboat ? 1 : (int)boat.BerthSize;

            //If it is an Rowboat, First Check if the Rowboat can be added to a Berth with an existing rowboat
            if (IsAnRowboat)
                for (int i = 0; i < Berths.Length; i++)
                {
                    if (Berths[i].ParkedBoats.Count < 2 && Berths[i].ContainsRowboat)
                    {
                        Berths[i].ParkedBoats.Add(boat);
                        boat.CurrentBerth = i;
                        return true;
                    }
                }

            //Else check if the boat can dock to another free berth in the harbor
            for (int i = 0; i < Berths.Length; i++)
            {
                if (CheckIfBerthIsAvailableAt(i, spaceNeeded))
                {
                    for (int j = i; j < (i + spaceNeeded); j++)
                    {
                        if (boat.CurrentBerth == null)
                            boat.CurrentBerth = j;
                        Berths[j].ParkedBoats.Add(boat);
                        if (IsAnRowboat)
                            Berths[j].ContainsRowboat = true;
                    }
                    return true;
                }
            }
            return false;
        }
        private bool CheckIfBerthIsAvailableAt(int min, int max)
        {
            if (max + min <= Berths.Length)
                return Berths
                    .Skip(min)
                    .Take(max)
                    .All(x => x.ParkedBoats.Any() == false && x.ContainsRowboat == false);
            else
                return false;
        }

        public void UpdateHarbourStatistics(Berth[] Berths)
        {
            TotalBoatWeight = CountBoatTotalWeight(Berths);
            AverageOfAllBoatsMaximumSpeed = AverageOfAllBoatsMaximumSpeeds(Berths);
            NumberOfAvailableBerths = CountEmptyBerths(Berths);
        }
    }
}
