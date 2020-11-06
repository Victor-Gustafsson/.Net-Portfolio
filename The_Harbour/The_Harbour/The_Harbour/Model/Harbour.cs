using The_Harbour.Model.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static The_Harbour.Data.FileManagement;
using static The_Harbour.Model.HarbourCalculations;

namespace The_Harbour.Model
{
    class Harbour
    {
        public Berth[] BerthsFirst;
        public Berth[] BerthsSecond;
        public List<Boat> TodaysCheckOuts = new List<Boat>();
        public List<Boat> TodaysCheckIns = new List<Boat>();
        public List<Boat> TodaysRejected = new List<Boat>();
        public int RejectedBoats;
        public int HarborTotalDays;
        public double TotalBoatWeight;
        public double AverageOfAllBoatsMaximumSpeed;
        public double NumberOfAvailableBerths;
        public Harbour(int SizeFirst, int SizeSecond)
        {
            Create_Berths(SizeFirst, SizeSecond);

            if (File.Exists(BerthOne))
                BerthsFirst = Berth_From_File(SizeFirst, BerthOne);
            else
                File.Create(BerthOne).Close();

            if (File.Exists(BerthTwo))
                BerthsSecond = Berth_From_File(SizeSecond, BerthTwo);
            else
                File.Create(BerthTwo).Close();

            RejectedBoats = Load_Rejected_Boats_From_History_File();
            HarborTotalDays = Load_Total_Number_Of_Days__From_History_File();
            Update_Harbour_Statistics(BerthsFirst, BerthsSecond);
        }


        private void Create_Berths(int first, int second)
        {
            BerthsFirst = new Berth[first];
            for (int i = 0; i < first; i++)
            {
                BerthsFirst[i] = new Berth();
                BerthsFirst[i].Id = i;
            }
            BerthsSecond = new Berth[second];
            for (int i = 0; i < second; i++)
            {
                BerthsSecond[i] = new Berth();
                BerthsSecond[i].Id = i;
            }
        }

        public void Boats_Check_Ins(List<Boat> ArrivingBoats)
        {
            TodaysCheckIns.Clear();
            TodaysRejected.Clear();

            foreach (var boat in ArrivingBoats)
            {
                // Här finns möjligheten att ändra hamnbeteende och hur båtarna ska komma in
                if (Dock_To_First_Berth(boat))
                    TodaysCheckIns.Add(boat);
                else if (Dock_To_Second_Berth(boat))
                    TodaysCheckIns.Add(boat);
                else
                {
                    RejectedBoats++;
                    TodaysRejected.Add(boat);
                }

            }
            HarborTotalDays++;
            Update_Harbour();
        }

        public void Boats_Check_Outs()
        {
            TodaysCheckOuts.Clear();
            
            foreach (var Berth in BerthsFirst.Concat(BerthsSecond).ToList())
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
            Update_Harbour();
        }

        public bool Dock_To_First_Berth(Boat boat)
        {
            bool IsRowboat = boat is Rowboat;
            int spaceNeeded = IsRowboat ? 1 : (int)boat.BerthSize;

            //If it is an Rowboat, First Check if the Rowboat can be added to a Berth with an existing rowboat
            if (IsRowboat)
                for (int i = 0; i < BerthsFirst.Length; i++)
                {
                    if (BerthsFirst[i].ParkedBoats.Count < 2 && BerthsFirst[i].ContainsRowboat)
                    {
                        BerthsFirst[i].ParkedBoats.Add(boat);
                        boat.CurrentBerth = i;
                        return true;
                    }
                }

            //Else check if the boat can dock to another free berth in the harbor
            for (int i = 0; i < BerthsFirst.Length; i++)
            {
                if (CheckIfBerthIsAvailableAt(i, spaceNeeded, BerthsFirst))
                {
                    for (int j = i; j < (i + spaceNeeded); j++)
                    {
                        if (boat.CurrentBerth == null)
                            boat.CurrentBerth = j;
                        BerthsFirst[j].ParkedBoats.Add(boat);
                        if (IsRowboat)
                            BerthsFirst[j].ContainsRowboat = true;
                    }
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfBerthIsAvailableAt(int min, int max, Berth[] Berth)
        {
            if (max + min <= Berth.Length)
                return Berth
                    .Skip(min)
                    .Take(max)
                    .All(x => x.ParkedBoats.Any() == false && x.ContainsRowboat == false);
            else
                return false;
        }

        public bool Dock_To_Second_Berth(Boat boat)
        {
            bool IsRowboat = boat is Rowboat;
            int spaceNeeded = IsRowboat ? 1 : (int)boat.BerthSize;

            //If it is an Rowboat, First Check if the Rowboat can be added to a Berth with an existing rowboat
            if (IsRowboat)
                for (int i = 0; i < BerthsSecond.Length; i++)
                {
                    if (BerthsSecond[i].ParkedBoats.Count < 2 && BerthsSecond[i].ContainsRowboat)
                    {
                        BerthsSecond[i].ParkedBoats.Add(boat);
                        boat.CurrentBerth = i;
                        return true;
                    }
                }

            //Else check if the boat can dock to another free berth in the harbor
            for (int i = 0; i < BerthsSecond.Length; i++)
            {
                if (CheckIfBerthIsAvailableAt(i, spaceNeeded, BerthsSecond))
                {
                    for (int j = i; j < (i + spaceNeeded); j++)
                    {
                        if (boat.CurrentBerth == null)
                            boat.CurrentBerth = j;
                        BerthsSecond[j].ParkedBoats.Add(boat);
                        if (IsRowboat)
                            BerthsSecond[j].ContainsRowboat = true;
                    }
                    return true;
                }
            }
            return false;
        }

        private void Update_Harbour()
        {
            Update_Harbour_Statistics(BerthsFirst, BerthsSecond);
            SaveToFile(BerthsFirst, BerthsSecond);
            Save_Rejected_Boats_And_Total_Days_To_History_File(RejectedBoats, HarborTotalDays);
        }

        public void Update_Harbour_Statistics(Berth[] First, Berth[] Second)
        {
            TotalBoatWeight = CountBoatTotalWeight(First, Second);
            AverageOfAllBoatsMaximumSpeed = AverageOfAllBoatsMaximumSpeeds(First, Second);
            NumberOfAvailableBerths = CountEmptyBerths(First, Second);
        }
    }
}
