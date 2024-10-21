using System;
using System.Collections.Generic;
using System.Threading;
using Tester;

namespace TjuvOchPolis
{

    public class Program
    {
        static void Main(string[] args)
        {
            CitySimulation simulation = new CitySimulation();
            simulation.RunSimulation();

         
        }
    }
}
