using The_Harbour.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_Harbour.Model.Classes
{
    class Catamaran: Boat
    {
        Random random = new Random();
        //Unique property
        public int SleepingPlaces { get; set; }

        public Catamaran(string id, string typ, int weight, int maxSpeed, int berthTime, double berthSize, int currentBerth, int unique) : base(id, typ, weight, maxSpeed, berthTime, berthSize, currentBerth)
        {
            SleepingPlaces = unique;
        }

        public Catamaran()
        {
            Id = GenerateId("K");
            Typ = "Catamaran";
            Weight = random.Next(1200, 8000 + 1);
            MaxSpeed = random.Next(1, 12 + 1);
            BerthTime = 3;
            BerthSize = 3;
            SleepingPlaces = random.Next(1, 4 + 1);
        }

        public override string ToString()
        {
            return $"Plats: {CurrentBerth}-{CurrentBerth + (BerthSize - 1)} {base.ToString()} Sleeping places: {SleepingPlaces}";
        }

    }
}
