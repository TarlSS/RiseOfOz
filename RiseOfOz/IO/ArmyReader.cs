using Newtonsoft.Json;
using RiseOfOz.Logic;
using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.IO
{
    /// <summary>
    /// Reads Troop and Template data from JSON resource files
    /// This class isn't really unit tested since it's heavily reliant on System.IO and 
    /// Newtonsoft.Json, which should be doing their own jobs.
    /// </summary>
    public class ArmyReader
    {

        const string JSON_PATTERN = "*.json";
        const string ARMY_PATH = "Resources/Armies";

        string basePath;
        ArmyComposer composer;

        public Dictionary<string, Army> Armies = new Dictionary<string, Army>();

        public ArmyReader(TroopFactory troopFactory)
        {
            basePath = "";
            this.composer = new ArmyComposer(troopFactory);
        }

        public ArmyReader(string path, TroopFactory troopFactory)
        {
            basePath = path + "/";
            this.composer = new ArmyComposer(troopFactory);
        }

        public Dictionary<string, Army> Read()
        {
            ReadArmies();

            return Armies;
        }

        /// <summary>
        /// Read a JSON and add it to troop types
        /// </summary>
        /// <param name="contents"></param>
        public void AddJson(string contents)
        {
            Army army = ReadJson(contents);
            Armies.Add(army.Name, army);
        }

        /// <summary>
        /// Get a Trooptype from a JSON
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public Army ReadJson(string contents)
        {
            Army army = new Army();
            Dictionary<string,string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);
            army.Name = dict["Name"];
            army.Size = Int32.Parse(dict["Size"]);
            army.Composition = dict["Composition"].Split(',');
            army.Troops = composer.Compose(army);
            return army;
        }

        private void ReadArmies()
        {
            string[] files = Directory.GetFiles(basePath + ARMY_PATH, JSON_PATTERN);

            foreach (string file in files)
            {
                try
                {
                    string contents = File.ReadAllText(file);
                    AddJson(contents);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);   //Show this for debugging purposes
                    Console.WriteLine("ERROR: Unable to serialize army file:" + file);
                    /* Best Practices: Since this is a simple console program, a simple error message
                     * will suffice, but normally we'd call some kind of debug logger here.
                     */
                }
            }
        }

    }
}

