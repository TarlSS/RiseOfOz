using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RiseOfOz.Models
{

    /// <summary>
    /// TroopTemplate is a DTO used to convert a JSON template into a troop type.
    /// </summary>
    public class TroopTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Damage { get; set; }
        public string Health { get; set; }
        public string PreferredTarget { get; set; }
        public string Template { get; set; }

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

    public class TemplateProperty
    {

    }
}
