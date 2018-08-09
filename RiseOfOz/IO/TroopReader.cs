using Newtonsoft.Json;
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
    public class TroopReader
    {

        const string JSON_PATTERN = "*.json";
        const string TROOP_PATH = "Resources/Troops";
        const string TEMPLATE_PATH = "Resources/Templates";

        string basePath;

        public Dictionary<string, TroopType> TroopTypes = new Dictionary<string, TroopType>();

        public TroopReader()
        {
            basePath = "";
        }

        public TroopReader(string path)
        {
            basePath = path+"/";
        }

        public Dictionary<string, TroopType> Read()
        {
            ReadTroops();
            ReadTemplates();

            return TroopTypes;
        }

        /// <summary>
        /// Read a JSON and add it to troop types
        /// </summary>
        /// <param name="contents"></param>
        public void AddJson(string contents)
        {
            TroopType t = ReadJson(contents);
            TroopTypes.Add(t.Name, t);
        }

        /// <summary>
        /// Get a Trooptype from a JSON
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public static TroopType ReadJson(string contents)
        {
            TroopType t = JsonConvert.DeserializeObject<TroopType>(contents);
            t.Metadata = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);
            return t;
        }

        private void ReadTroops()
        {
            string[] files = Directory.GetFiles(basePath + TROOP_PATH, JSON_PATTERN);

            foreach (string file in files)
            {
                try
                {
                    string contents = File.ReadAllText(file);
                    AddJson(contents);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: Unable to serialize troop file:" + file);
                    /* Best Practices: Since this is a simple console program, a simple error message
                     * will suffice, but normally we'd call some kind of debug logger here.
                     */
                }
            }
        }

        private void ReadTemplates()
        {
            string[] files = Directory.GetFiles(basePath + TEMPLATE_PATH, JSON_PATTERN);

            foreach (string file in files)
            {
                try
                {
                    string contents = File.ReadAllText(file);
                    TemplateReader reader = new TemplateReader(contents, TroopTypes);
                    TroopType t = reader.Read();
                    TroopTypes.Add(t.Name, t);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);   //Show this for debugging purposes
                    Console.WriteLine("ERROR: Unable to serialize troop template file:" + file);
                }
            }
        }

    }
}

