using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Harbour_Console_App.Model
{
    class Berth
    {
        public int Id { get; set; }
        public bool ContainsRowboat { get; set; } = false;
        public List<Boat> ParkedBoats { get; set; } = new List<Boat>();

        public override string ToString()
        {
            if (!ContainsRowboat && !ParkedBoats.Any())
                return $"Plats: {Id} Tomt";
            else if(ContainsRowboat && ParkedBoats.Count == 1)
                return $"{ParkedBoats.First()}";
            else if (ContainsRowboat && ParkedBoats.Count == 2)
                return $"{ParkedBoats.First()}{Environment.NewLine}{ParkedBoats.Last()}";
            return $"{ParkedBoats.First()}";
        }
    }
}
