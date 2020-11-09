using System;
using System.Collections.Generic;
namespace Thief_And_Police
{
    public class Person
    {
        public int ID;
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Xdirection { get; set; }
        public int Ydirection { get; set; }
        public bool InPrison { get; set; }
        public int TimeInPrison { get; set; }
        public List<Item> Inventory;
        public Person(int y, int x, int ydirection, int xdirection, int Id, string name)
        {
            ID = Id;
            Name = name;
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
            Inventory = new List<Item>();
            InPrison = false;
            TimeInPrison = 0;
        }
        public void Move()
        {
            X += Xdirection;
            Y += Ydirection;
        }
        public virtual void TakeItemsFromInventory(List<Item> inventory) { }
    }

    class Citizen : Person
    {
        private Random random = new Random();
        public List<Item> Tillhörigheter;
        public Citizen(int y, int x, int ydirection, int xdirection, int id, string name) : base(y, x, ydirection, xdirection, id, name)
        {
            Tillhörigheter = new List<Item>();
            Tillhörigheter.Add(new Key(id, "Keys", 0));
            Tillhörigheter.Add(new Phone(id, "Phone", random.Next(1000, 14000 + 1)));
            Tillhörigheter.Add(new Money(id, "Money", random.Next(1, 4000 + 1)));
            Tillhörigheter.Add(new Watch(id, "Watch", random.Next(100, 100000 + 1)));
            Inventory = Tillhörigheter;
        }
    }

    class Thief : Person
    {
        public List<Item> Stöldgods;

        public Thief(int y, int x, int ydirection, int xdirection, int id, string name) : base(y, x, ydirection, xdirection, id, name)
        {
            Stöldgods = new List<Item>();
            Inventory = Stöldgods;
        }

        public override void TakeItemsFromInventory(List<Item> belongings)
        {
            Random random = new Random();
            int TakeRandomItem = random.Next(0, belongings.Count);
            if (belongings.Count != 0)
            {
                Inventory.Add(belongings[TakeRandomItem]);
                belongings.RemoveAt(TakeRandomItem);
            }
        }
    }

    class Police : Person
    {
        public List<Item> BeslagtagnaGods;
        public Police(int y, int x, int ydirection, int xdirection, int id, string name) : base(y, x, ydirection, xdirection, id, name) 
        {
            BeslagtagnaGods = new List<Item>();
            Inventory = BeslagtagnaGods;
        }
        public override void TakeItemsFromInventory(List<Item> inventory)
        {
            if (inventory.Count != 0)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Inventory.Add(inventory[i]);
                    inventory.RemoveAt(i);    
                }

            }
        }
    }
}
