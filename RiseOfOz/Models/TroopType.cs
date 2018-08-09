using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RiseOfOz.Models
{

    /// <summary>
    /// TroopType is the base class for all troop definitions. TroopType data is set via JSON properties
    /// We use JSON for data to enable things to be easier when working with designers. Setting properties in JSON
    /// means we don't need to recompile every time.
    /// In Unity we would likely use Scriptable Objects instead.
    /// </summary>
    public class TroopType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public string PreferredTarget { get; set; }
        public string Template { get; set; }

        /// <summary>
        /// This troop represented as a Kvp of strings
        /// </summary>
        public Dictionary<string, string> Metadata;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id:{Id}");
            sb.AppendLine($"Name:{Name}");
            sb.AppendLine($"Type:{Type}");
            sb.AppendLine($"Damage:{Damage}");
            sb.AppendLine($"Health:{Health}");
            sb.AppendLine($"PreferredTarget:{PreferredTarget}");
            sb.AppendLine($"Template:{Template}");
            return sb.ToString();
        }
    }
}
