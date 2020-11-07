using The_Harbour_Console_App.Model.Classes;
using The_Harbour_Console_App.Model;
using The_Harbour_Console_App.View;
using System.Collections.Generic;
using System.Linq;
using System;

namespace The_Harbour_Console_App.Controllers
{
    class Controller
    {
        private Harbor Harbor { get; set; }
        private ConsoleView View { get; set; }

        public Controller(Harbor model, ConsoleView view)
        {
            Harbor = model;
            View = view;
        }

        public void Run()
        {
            View.PrintBoatsInHabour();
            Console.ReadKey();
            do
            {
                Console.Clear();
                Controller_Make_One_Day_Passes();
                Harbor.BoatsCheckOuts();
                Harbor.BoatsCheckIns(Controller_Sends_New_Boats_To_Check_In(5));
                View.PrintBoatsInHabour();
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }


        private void Controller_Make_One_Day_Passes()
        {
            var GroupAllBoats = Harbor.Berths
                .SelectMany(b => b.ParkedBoats)
                .GroupBy(b => b.ToString())
                .ToList();

            foreach (var Berth in GroupAllBoats)
            {
                foreach (var boat in Berth)
                {
                    boat.BerthTime--;
                    break;
                }
            }

        }


        private List<Boat> Controller_Sends_New_Boats_To_Check_In(int number)
        {
            var NewBoats = new List<Boat>();
            var random = new Random();

            for (int i = 0; i < number; i++)
            {
                int type = random.Next(0, 3 + 1);
                if (type == (int)BoatTypes.Rowboat)
                    NewBoats.Add(new Rowboat());
                if (type == (int)BoatTypes.MotorBoat)
                    NewBoats.Add(new MotorBoat());
                if (type == (int)BoatTypes.Sailboat)
                    NewBoats.Add(new Sailboat());
                if (type == (int)BoatTypes.CargoShip)
                    NewBoats.Add(new CargoShip());
            }
            return NewBoats;
        }

        enum BoatTypes
        {
            Rowboat,
            MotorBoat,
            Sailboat,
            CargoShip
        }
    }
}
