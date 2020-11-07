using System;
using System.Collections.Generic;
using System.Text;

namespace The_Harbour.Model.Classes
{
    class Rowboat : Boat
    {
        Random random = new Random();
        //Unique property
        public int MaxNumberOfPassengers { get; set; }


        public Rowboat(string id, string typ, int weight, int maxSpeed, int berthTime, double berthSize, int currentBerth, int unique) : base(id, typ, weight, maxSpeed, berthTime, berthSize, currentBerth)
        {
            MaxNumberOfPassengers = unique;
        }

        public Rowboat()
        {
            Id = GenerateId("R");
            Typ = "Rowboat";
            Weight = random.Next(100, 300 + 1);
            MaxSpeed = random.Next(1, 3 + 1);
            BerthTime = 1;
            BerthSize = 0.5;
            MaxNumberOfPassengers = random.Next(1, 6 + 1);
        }
        public override string ToString()
        {
            return $"Plats: {CurrentBerth}  {base.ToString()} Max Passengers: {MaxNumberOfPassengers}";
        }
    }
}