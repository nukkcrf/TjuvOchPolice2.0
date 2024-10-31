using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    internal class Jail
    {
        private List<Thief>jailedthief =new List<Thief>();

        public void AddThiefToJail(Thief thief)
        {
            jailedthief.Add(thief);
            Console.WriteLine($" Tjuven in fengelse  {thief.X}{thief.Y}. Staffad for 5 secunder!! ");
            

            for (int i = 0; i < 5;i++)
            {
                thief.Move();
               
                Thread.Sleep(1000);
            }
            ReleaseThief(thief);
        }
        private void ReleaseThief(Thief thief)
        {
            jailedthief.Remove(thief);
            Console.WriteLine($"Tjuven blev utslapt fran fengelse. ");
           
        }
        public void DisplayJail(char[,] jailGrid,int jailHeigth,int jailWidth)
        {
            for (int y = 0; y < jailHeigth; y++)
            {
                for (int x = 0; x < jailWidth; x++)
                {
                    char symbol = jailGrid[x, y];
                    Console.Write(symbol + " ");


                    Console.WriteLine();
                }
            }
         }
    }
} 
