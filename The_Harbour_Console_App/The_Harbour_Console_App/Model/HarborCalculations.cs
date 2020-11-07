using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Harbour_Console_App.Model
{
     static class HarborCalculations
    {
        
        public static int CountRowboats(Berth[] Berths)
        {
            return Berths
                    .SelectMany(b => b.ParkedBoats)
                    .Where(b => b.Typ == "Roddbåt")
                    .GroupBy(b => b.ToString()).Count();
        }
        public static int CountMotorBoats(Berth[] Berths)
        {
            return Berths
                    .SelectMany(b => b.ParkedBoats)
                    .Where(b => b.Typ == "Motorbåt")
                    .GroupBy(b => b.ToString()).Count();
        }
        public static int CountSailboats(Berth[] Berths)
        {
            return Berths
                    .SelectMany(b => b.ParkedBoats)
                    .Where(b => b.Typ == "Segelbåt")
                    .GroupBy(b => b.ToString()).Count();
        }
        public static int CountCargoShips(Berth[] Berths)
        {
            return Berths
                    .SelectMany(b => b.ParkedBoats)
                    .Where(b => b.Typ == "Lastfartyg")
                    .GroupBy(b => b.ToString()).Count();
        }
        public static int CountTotalNumberOfBoats(Berth[] Berths)
        {
            return Berths
                    .SelectMany(b => b.ParkedBoats)
                    .GroupBy(b => b.ToString()).Count();
        }

        public static double CountEmptyBerths(Berth[] Berths)
        {
            var EntireBerthsAvailable = Berths
                    .Where(b => b.ParkedBoats.Any() == false && b.ContainsRowboat == false)
                    .Count();

            var HalfBerths = Berths
                    .Where(b => b.ContainsRowboat && b.ParkedBoats.Count == 1)
                    .Select(b => b.ParkedBoats).ToList().Count;

            double HalfBerthsAvailable = 0;
            for (int i = 0; i < HalfBerths; i++)
            {
                HalfBerthsAvailable += 0.5;
            }
            return EntireBerthsAvailable + HalfBerthsAvailable;
        }

        public static int CountBoatTotalWeight(Berth[] Berths)
        {
            int TotalWeight = 0;
            var CountBoatWeight = Berths
                    .SelectMany(b => b.ParkedBoats)
                    .GroupBy(b => b.ToString());

            foreach (var Berth in CountBoatWeight)
            {
                foreach (var boat in Berth)
                {
                    TotalWeight += boat.Weight;
                    break;
                }
            }
            return TotalWeight;
        }

        public static double AverageOfAllBoatsMaximumSpeeds(Berth[] Berths)
        {
            // Returns in Km/h, remove * 1.852 for change to knop
            List<Boat> Boats = new List<Boat>();
            var CountAverageSpeed = Berths
                    .SelectMany(b => b.ParkedBoats)
                    .GroupBy(b => b.ToString());
            foreach (var Berth in CountAverageSpeed)
            {
                foreach (var boat in Berth)
                {
                    Boats.Add(boat);
                    break;
                }
            }
            if (Boats.Count != 0) 
            return Math.Round(Boats.Select(b => b.MaxSpeed).Average() * 1.852, 2);
            else
                return 0;
        }
        public static double ConvertKnopToKMh(int MaxSpeed)
        {
            return Math.Round(MaxSpeed * 1.852, 0);
        }
    }
}
