using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace The_Harbour_Console_App.Model
{
    class Boat
    {
        Random random = new Random();
        public string Id { get; set; }
        public string Typ { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }
        public int BerthTime { get; set; }
        public double BerthSize { get; set; }
        public int? CurrentBerth { get; set; } = null;
        public Boat() { }
        public Boat(string id, string typ, int weight, int maxSpeed, int berthTime, double berthSize,int currentBerth)
        {
            Id = id;
            Typ = typ;
            Weight = weight;
            MaxSpeed = maxSpeed;
            BerthTime = berthTime;
            BerthSize = berthSize;
            CurrentBerth = currentBerth;
        }

        /// <returns> Returns an Id string with a specified prefix </returns>
        protected string GenerateId(string prefix)
        {
            string id = $"{prefix}-";
            for (int i = 0; i < 3; i++)
                id += (char)random.Next('a', 'z');
            return id.ToUpper();
        }
        public override string ToString()
        {
            return $"Typ: {Typ} ID: {Id} Weight: {Weight} MaxSpeed: {MaxSpeed} BerthSize: {BerthSize} BerthTime: {BerthTime}";
        }
    }
}
