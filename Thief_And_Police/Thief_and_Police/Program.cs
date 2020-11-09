using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thief_And_Police
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Choice = View.Menu();
            City City = new City(Choice[0], Choice[1], Choice[2], Choice[3], Choice[4]);
            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                City.MoveCitizens();
            }
        }
    }
}
