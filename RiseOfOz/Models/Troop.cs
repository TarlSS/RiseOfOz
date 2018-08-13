using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Models
{
    /// <summary>
    /// An individiual troop or soldier. Forms armies and
    /// has statistics derived from TroopType
    /// </summary>
    public class Troop
    {
        private static int nextId = 0;
        public string ArmyName { get; set; }
        public int Id { get; set; }
        public TroopType Info { get; set; }
        public int CurrentHealth { get; set; }
        public int InflictedDamage { get; set; }

        public Troop(TroopType troopType)
        {
            this.Id = nextId++;
            this.Info = troopType;
            this.CurrentHealth = troopType.Health;
            this.InflictedDamage = 0;
        }

        /// <summary>
        /// Applies damage to another troop
        /// </summary>
        /// <param name="defender"></param>
        public void Attack(Troop defender)
        {
            int damageDealt = Info.Damage;
            if (defender.Info.Type != Info.PreferredTarget && Info.PreferredTarget!="All")
            {
                damageDealt /= 2;
            }

            if (damageDealt > defender.CurrentHealth)
            {
                this.InflictedDamage += defender.CurrentHealth;
            }
            else
            {
                this.InflictedDamage += damageDealt;
            }

            defender.CurrentHealth -= damageDealt;
        }

        public override string ToString()
        {
            return $"{ArmyName} {Info.Name} (health={CurrentHealth}, totalDamage={InflictedDamage})";
        }
    }
}
