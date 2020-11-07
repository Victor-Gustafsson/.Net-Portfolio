using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Harbour.Model
{
    static class HarbourCalculations
    {


        public static int CountSpecificBoatType(Berth[] first, Berth[] second, string typ)
        {
            return first
                .Concat(second)
                .ToList()
                .SelectMany(b => b.ParkedBoats)
                .Where(b => b.Typ == typ)
                .GroupBy(b => b.ToString())
                .Count();
        }

        public static int CountTotalNumberOfBoats(Berth[] first, Berth[] second)
        {

            return first.Concat(second)
                    .SelectMany(b => b.ParkedBoats)
                    .GroupBy(b => b.ToString()).Count();
        }

        public static double CountEmptyBerths(Berth[] first, Berth[] second)
        {
            var CompletelyBerthAvailable = first
                .Concat(second)
                .Where(b => b.ParkedBoats
                .Any() == false && b.ContainsRowboat == false)
                .Count();

            var HalfBerthAvailable = first
                .Concat(second)
                .Where(b => b.ContainsRowboat && b.ParkedBoats.Count == 1)
                .Select(b => b.ParkedBoats)
                .ToList()
                .Count();

            double AvailableForRowBoats = 0;

            for (int i = 0; i < HalfBerthAvailable; i++)
            {
                AvailableForRowBoats += 0.5;
            }
            return CompletelyBerthAvailable + AvailableForRowBoats;
        }

        public static int CountBoatTotalWeight(Berth[] first, Berth[] second)
        {
            return first
                .Concat(second)
                .SelectMany(b => b.ParkedBoats)
                .GroupBy(b => b.Weight)
                .Sum(b => b.Key);
        }

        public static double AverageOfAllBoatsMaximumSpeeds(Berth[] first, Berth[] second)
        {
            // Returns in Km/h, remove * 1.852 for change to knop
            List<Boat> Boats = new List<Boat>();

            var CountAverageSpeed = first
                .Concat(second)
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
