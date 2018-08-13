using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Models
{
    /// <summary>
    /// Represents an Army
    /// Populated by an ArmyReader which reads an army JSON dataset.
    /// The List of troops and order of them is determined by the composition
    /// </summary>
    public class Army
    {
        public string Name { get; set; }
        public List<Troop> Troops { get; set; }
        public string[] Composition { get; set; }
        public int Size { get; set; }
    }
}
