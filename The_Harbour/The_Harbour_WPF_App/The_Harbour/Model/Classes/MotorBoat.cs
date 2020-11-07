using System;
using System.Collections.Generic;
using System.Text;

namespace The_Harbour.Model.Classes
{
    class MotorBoat : Boat
    {
        Random random = new Random();
        //Unique property
        public int NumberOfHorsepower { get; set; }

        public MotorBoat(string id, string typ, int weight, int maxSpeed, int berthTime, double berthSize, int currentBerth, int unique) : base(id, typ, weight, maxSpeed, berthTime, berthSize, currentBerth)
        {
            NumberOfHorsepower = unique;
        }

        public MotorBoat()
        {
            Id = GenerateId("M");
            Typ = "PowerBoat";
            Weight = random.Next(200, 3000 + 1);
            MaxSpeed = random.Next(1, 60 + 1);
            BerthTime = 3;
            BerthSize = 1;
            NumberOfHorsepower = random.Next(10, 1000 + 1);
        }
        public override string ToString()
        {
            return $"Plats: {CurrentBerth}  {base.ToString()}  Horsepower: {NumberOfHorsepower}";
         
        }
    }
}
