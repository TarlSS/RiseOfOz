using Newtonsoft.Json;
using RiseOfOz;
using RiseOfOz.Models;
using System;
using System.Collections.Generic;

namespace RiseOfOz.IO
{
    public class TemplateReader
    {
        string contents;
        Dictionary<string, string> metadata;
        Dictionary<string, TroopType> troopTypes;

        public TemplateReader(string contents, Dictionary<string, TroopType> troopTypes)
        {
            this.contents = contents;
            this.troopTypes = troopTypes;
            this.metadata = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);
        }

        public TroopType Read()
        {
            TroopType t = new TroopType();

            t.Id = Int32.Parse(metadata["Id"]);
            t.Name = metadata["Name"];
            t.Type = GetStringProperty("Type");
            t.Damage = Int32.Parse(GetStringProperty("Damage"));
            t.Health = Int32.Parse(GetStringProperty("Health"));
            t.PreferredTarget = GetStringProperty("PreferredTarget");
            t.Template = metadata["Template"];

            return t;
        }

        public string GetStringProperty(string key)
        {
            string value = metadata[key];
            if (value[0] != '*')
            {
                return value;
            }
            string baseName = value.Substring(1);
            if (!troopTypes.ContainsKey(baseName))
            {
                throw new InvalidOperationException($"ERROR: Could not find troop type of {baseName} for template:{metadata["Name"]}");
            }
            return troopTypes[baseName].Metadata[key];
        }

        public int GetIntProperty(string key)
        {
            return Int32.Parse(GetStringProperty(key));
        }
    }
}
