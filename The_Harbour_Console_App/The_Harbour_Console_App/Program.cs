using The_Harbour_Console_App.Controllers;
using The_Harbour_Console_App.Model;
using The_Harbour_Console_App.View;
using System.Collections.Generic;

namespace The_Harbour_Console_App
{
    class Program
    {
        public static List<Boat> Boats = new List<Boat>();
        static void Main(string[] args)
        {
            Harbor Harbor = new Harbor(64);
            ConsoleView View = new ConsoleView(Harbor);
            Controller controller = new Controller(Harbor, View);
            controller.Run(); 
        }
    }
}
