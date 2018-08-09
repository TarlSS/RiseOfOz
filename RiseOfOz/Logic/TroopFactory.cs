using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Logic
{
    /// <summary>
    /// Creates an individual troop derived from a troop type
    /// </summary>
    public class TroopFactory
    {
        Dictionary<string, TroopType> troopTypes;
        public TroopFactory(Dictionary<string, TroopType> troopTypes)
        {
            this.troopTypes = troopTypes;
        }

        public Troop Create(string typeName)
        {
            if (!troopTypes.ContainsKey(typeName))
            {
                throw new InvalidOperationException($"ERROR: Attempting to create army with unavailable troop type:{typeName}");
            }
            Troop t = new Troop(troopTypes[typeName]);
            return t;
        }
    }
}
