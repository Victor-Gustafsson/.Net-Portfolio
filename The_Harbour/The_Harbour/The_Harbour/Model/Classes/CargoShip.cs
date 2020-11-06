using System;
using System.Collections.Generic;
using System.Text;

namespace The_Harbour.Model.Classes
{
    class CargoShip: Boat
    {
        Random random = new Random();
        //Unique property
        public int ContainersLoaded { get; set; }

        public CargoShip(string id, string typ, int weight, int maxSpeed, int berthTime, double berthSize, int currentBerth, int unique) : base(id, typ, weight, maxSpeed, berthTime, berthSize, currentBerth)
        {
            ContainersLoaded = unique;
        }
        public CargoShip()
        {
            Id = GenerateId("L");
            Typ = "CargoShip";
            Weight = random.Next(3000, 20000 + 1);
            MaxSpeed = random.Next(1, 20 + 1);
            BerthTime = 6;
            BerthSize = 4;
            ContainersLoaded = random.Next(0, 500 + 1);
        }

        public override string ToString()
        {
            return $"Plats: {CurrentBerth}-{CurrentBerth + (BerthSize-1)} {base.ToString()} Containers Loaded: {ContainersLoaded}";
        }
    }
}
