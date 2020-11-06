using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace The_Harbour.Model.Classes
{
    class Sailboat : Boat
    {
        Random random = new Random();
        //Unique property
        public int Boatlength { get; set; }

        public Sailboat(string id, string typ, int weight, int maxSpeed, int berthTime, double berthSize, int currentBerth, int unique) : base(id, typ, weight, maxSpeed, berthTime, berthSize, currentBerth)
        {
            Boatlength = unique;
        }

        public Sailboat()
        {
            Id = GenerateId("S");
            Typ = "Sailboat"; 
            Weight = random.Next(800, 6000 + 1);
            MaxSpeed = random.Next(1, 12 + 1);
            BerthTime = 4;
            BerthSize = 2;
            Boatlength = random.Next(10, 60 + 1);
        }

        public override string ToString()
        {
            return $"Plats: {CurrentBerth}-{CurrentBerth + (BerthSize - 1)} {base.ToString()}  Length: {Boatlength}";
        }
    }
}
