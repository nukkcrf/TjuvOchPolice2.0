using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class CitySimulation
    {
        private int totalRoberies = 0;
        private int totalArrest = 0;
        private List<Person> persons = new List<Person>();
        private Random random = new Random();
        private int cityWidth = 60;
        private int cityHeight = 20;

        public CitySimulation()
        {
            // add en antal personer( Polis,Tjuv,Medborgare
            for (int i = 0; i < 15; i++) persons.Add(new Police() { X = random.Next(cityWidth), Y = random.Next(cityHeight) });
            for (int i = 0; i < 20; i++) persons.Add(new Thief() { X = random.Next(cityWidth), Y = random.Next(cityHeight) });
            for (int i = 0; i < 35; i++) persons.Add(new Citizen() { X = random.Next(cityWidth), Y = random.Next(cityHeight) });
        }

        public void RunSimulation()
        {
            while (true)
            {
                // Reset
                Console.Clear();

                // Alla ror sig
                foreach (var person in persons)
                {
                    person.Move();

                    //Så fort en person försvinner utanför staden så kommer hen tillbaka I andra ändan
                    if (person.X < 0) person.X = cityWidth - 1;
                    if (person.X >= cityWidth) person.X = 0;
                    if (person.Y < 0) person.Y = cityHeight - 1;
                    if (person.Y >= cityHeight) person.Y = 0;
                }

                // staden
                char[,] cityGrid = new char[cityHeight, cityWidth];

                // stopa i personer i staden
                foreach (var person in persons)
                {
                    char symbol = '.';
                    if (person is Police) symbol = 'P';
                    else if (person is Thief) symbol = 'T';
                    else if (person is Citizen) symbol = 'M';

                    cityGrid[person.Y, person.X] = symbol;
                }
                Console.WriteLine($"Totala antalet ran : {totalRoberies}");
                Console.WriteLine($"Totala antalet gripanden : {totalArrest}");

                // grid display
                for (int y = 0; y < cityHeight; y++)
                {
                    for (int x = 0; x < cityWidth; x++)
                    {
                        char symbol = cityGrid[y, x];
                        Console.Write(symbol + " ");
                    }
                    Console.WriteLine();
                }

                // om personerna mots
                for (int i = 0; i < persons.Count; i++)
                {
                    for (int j = i + 1; j < persons.Count; j++)
                    {
                        if (persons[i].X == persons[j].X && persons[i].Y == persons[j].Y)
                        {
                            if (persons[i] is Thief thief && persons[j] is Citizen citizen)
                            {
                                thief.Rob(citizen);
                                totalRoberies++;
                            }
                            else if (persons[i] is Citizen citizen1 && persons[j] is Thief thief1)
                            {
                                thief1.Rob(citizen1);
                                totalRoberies++;
                            }
                            else if (persons[i] is Police police && persons[j] is Thief thief2)
                            {
                                police.Arrest(thief2);
                                totalArrest++;
                            }
                            else if (persons[i] is Thief thief3 && persons[j] is Police police1)
                            {
                                police1.Arrest(thief3);
                                totalArrest++;
                            }
                        }
                    }
                }

                Thread.Sleep(700);

            }
        }
    }
}
