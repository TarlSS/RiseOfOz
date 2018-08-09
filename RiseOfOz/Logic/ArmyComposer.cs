using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Logic
{
    /// <summary>
    /// Generates a list of troops of a given size based on an Army composition
    /// </summary>
    public class ArmyComposer
    {
        TroopFactory factory;

        public ArmyComposer(TroopFactory factory)
        {
            this.factory = factory;
        }

        public List<Troop> Compose(Army army)
        {
            List <Troop> troops = new List<Troop>();
            int compoIndex = 0;

            for(int i = 0; i < army.Size; i++)
            {
                Troop t = factory.Create(army.Composition[compoIndex]);
                t.ArmyName = army.Name;
                troops.Add(t);
                compoIndex++;
                if (compoIndex >= army.Composition.Length)
                {
                    compoIndex = 0;
                }
            }
            return troops;
        }
    }
}
