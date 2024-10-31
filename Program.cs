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

            int jailHeight = 5; // Dimension
            int jailWidth = 5;  
            char[,] jailGrid = new char[jailWidth, jailHeight]; // Grid

            Jail jailSimulation  = new Jail();
            jailSimulation.DisplayJail(jailGrid,jailHeight,jailWidth);

         
        }
    }
}
