using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class Person
        {
            public int X { get; set; }
            public int Y { get; set; }
            public List<string> Inventory { get; set; } = new List<string>();

            // Move method
            public void Move()
            {
                Random random = new Random();
                int direction = random.Next(6);

                // Direction
                switch (direction)
                {
                    case 0: X++; break; // vanster
                    case 1: X--; break; // hoger
                    case 2: Y++; break; // upp
                    case 3: Y--; break; // ner
                    case 4: X++; Y--; break;//diagonal
                    case 5: X--; Y++; break;//diagonal

                }
            }
        }

        // Subclass citizen
        public class Citizen : Person
        {
            public Citizen()
            {
                Inventory.AddRange(new List<string> { "Nycklar ", "Telefon ", "Pengar ", "Klocka " });
            }
        }

        // Subclass Tjuv
        public class Thief : Person
        {
            // Tjuven stal method
            public void Rob(Citizen citizen)
            {
                if (citizen.Inventory.Count > 0)
                {
                    Random random = new Random();
                    int itemIndex = random.Next(citizen.Inventory.Count);
                    string stolenItem = citizen.Inventory[itemIndex];// val en random  item
                    citizen.Inventory.RemoveAt(itemIndex);// ta fron medborjare
                    Inventory.Add(stolenItem); // add till tjuv inventory
                    Console.WriteLine($"Tjuven stal {stolenItem} from Medborgare.");
                }
            }
        }

        // Subclass for Polis
        public class Police : Person
        {
            // Arrest method
            public void Arrest(Thief thief)
            {
                if (thief.Inventory.Count > 0)
                {
                    Inventory.AddRange(thief.Inventory);
                    thief.Inventory.Clear();
                    Console.WriteLine($"Polisen belagtog: {string.Join(", ", Inventory)}.");
                }
            }
        }
    
}
