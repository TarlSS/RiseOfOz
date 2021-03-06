﻿using RiseOfOz.IO;
using RiseOfOz.Logic;
using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RiseOfOz
{
    /// <summary>
    /// The main program to run this game.
    /// TroopTypes and Armies can be altered by changing values in the json files found in the Resources folder.
    /// Currently this is hard coded to fight between the Bad and Good armies, but match setup info could also
    /// be placed into an external data file.
    /// </summary>
    class Program
    {
        static Dictionary<string, TroopType> troopTypes;
        static Dictionary<string, Army> armies;

        static void Main(string[] args)
        {
            TroopReader troopReader = new TroopReader();
            troopTypes = troopReader.Read();

            TroopFactory troopFactory = new TroopFactory(troopTypes);
            ArmyReader armyReader = new ArmyReader(troopFactory);
            armies = armyReader.Read();

            PrintArmy("Good Army");
            Console.WriteLine();
            PrintArmy("Bad Army");

            Army a = armies["Good Army"];
            Army b = armies["Bad Army"];
            BattleSimulator sim = new BattleSimulator(a, b);
            sim.Battle();
            Console.WriteLine(sim.Result);
            Console.ReadLine();
        }

        static void PrintArmy(string name)
        {
            Console.WriteLine($"{name} - Initial Troops");
            Army army = armies[name];
            int i = 1;
            foreach (Troop t in army.Troops)
            {
                Console.WriteLine($"{i}.{t.Info.Name}");
                i++;
            }
        }
    }
}
