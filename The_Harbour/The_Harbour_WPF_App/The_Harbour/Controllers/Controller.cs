using The_Harbour.Model.Classes;
using The_Harbour.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace The_Harbour.Controllers
{
    class Controller
    {
        public Harbour Harbor { get; set; }
        public Controller(Harbour model)
        {
            Harbor = model;
        }

        public void Run(int newIncomingBoats, bool[] Filter)
        {
            Controller_Make_One_Day_Passes();
            Harbor.Boats_Check_Outs();
            Harbor.Boats_Check_Ins(Controller_Sends_New_Boats_To_Check_In(newIncomingBoats, Filter));
        }


        private void Controller_Make_One_Day_Passes()
        {
            var Berths = Harbor.BerthsFirst
                .Concat(Harbor.BerthsSecond)
                .SelectMany(b => b.ParkedBoats)
                .GroupBy(b => b.ToString())
                .ToList();

            foreach (var Berth in Berths)
            {
                foreach (var boat in Berth)
                {
                    boat.BerthTime--;
                    break;
                }
            }

        }

        private List<Boat> Controller_Sends_New_Boats_To_Check_In(int number, bool[] Filter)
        {
            var NewBoats = new List<Boat>();
            var random = new Random();
            for (int i = 0; i < number; i++)
            {
                if (Filter.Contains(true))
                {
                    do
                    {
                        int type = random.Next(0, 4 + 1);
                        if (type == (int)BoatTypes.Rowboat && Filter[0])
                        {
                            NewBoats.Add(new Rowboat());
                            break;
                        }
                        if (type == (int)BoatTypes.MotorBoat && Filter[1])
                        {
                            NewBoats.Add(new MotorBoat());
                            break;
                        }
                        if (type == (int)BoatTypes.Sailboat && Filter[2])
                        {
                            NewBoats.Add(new Sailboat());
                            break;
                        }
                        if (type == (int)BoatTypes.CargoShip && Filter[3])
                        {
                            NewBoats.Add(new CargoShip());
                            break;
                        }
                        if (type == (int)BoatTypes.Catamaran && Filter[4])
                        {
                            NewBoats.Add(new Catamaran());
                            break;
                        }
                    } while (true);
                }
            }
            return NewBoats;
        }

        enum BoatTypes
        {
            Rowboat,
            MotorBoat,
            Sailboat,
            CargoShip,
            Catamaran
        }
    }
}
