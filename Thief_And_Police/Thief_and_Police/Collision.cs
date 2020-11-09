using System.Collections.Generic;

namespace Thief_And_Police
{
    class Collision
    {
        public static bool ThievesIsRobbing(Person personStanding, Person personMoving, List<string> incidents)
        {
            // If the thief is running on a citizen which is already on the location or vice versa

            if (personStanding is Thief && personMoving is Citizen)
            {
                personStanding.TakeItemsFromInventory(personMoving.Inventory);
                incidents.Add($"Citizen({personMoving.ID}) run into the thief({personStanding.ID}) and gets robbed");
                return true;
            }
            else if (personStanding is Citizen && personMoving is Thief)
            {
                personMoving.TakeItemsFromInventory(personStanding.Inventory);
                incidents.Add($"Thief({personMoving.ID}) robs citizen({personStanding.ID})");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PoliceIsArresting(Person personStanding, Person personMoving, List<string> incidents)
        {
            // If the thief is running on a police which is already on the location or vice versa
            if (personStanding is Police && personMoving is Thief)
            {
                personStanding.TakeItemsFromInventory(personMoving.Inventory);
                personMoving.InPrison = true;
                incidents.Add($"Thief({personMoving.ID}) run into a police officer({personStanding.ID}) and is arrested");
                return true;
            }
            else if (personStanding is Thief && personMoving is Police)
            {
                personMoving.TakeItemsFromInventory(personStanding.Inventory);
                personStanding.InPrison = true;
                incidents.Add($"Police officer({personMoving.ID}) arrests thief({personStanding.ID})");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
