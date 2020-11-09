using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thief_And_Police
{
    class RandomCitizens
    {
        private static Random random = new Random();
        public static List<Person> CreateInhabitants(int citizens, int polices, int thiefs, int citySizeY, int citySizeX)
        {
            List<Person> Inhabitants = new List<Person>();

            // Create citizens
            for (int i = 0; i < citizens; i++)
            {
                Inhabitants.Add(new Citizen(random.Next(citySizeY), random.Next(citySizeX), random.Next(-1, 2), random.Next(-1, 2), i, "C"));
            }

            // Create polices
            for (int i = 0; i < polices; i++)
            {
                Inhabitants.Add(new Police(random.Next(citySizeY), random.Next(citySizeX), random.Next(-1, 2), random.Next(-1, 2), i, "P"));
            }

            // Create thiefs
            for (int i = 0; i < thiefs; i++)
            {
                 Inhabitants.Add(new Thief(random.Next(citySizeY), random.Next(citySizeX), random.Next(-1, 2), random.Next(-1, 2), i, "T"));
            }
            Shuffle(Inhabitants);
            return Inhabitants;
        }

        /*A method for mix the inhabitants in the list*/
        private static void Shuffle<Person>(List<Person> inhabitants)
        {
            int n = inhabitants.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Person value = inhabitants[k];
                inhabitants[k] = inhabitants[n];
                inhabitants[n] = value;
            }
        }
    }
}
