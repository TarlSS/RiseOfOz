using RiseOfOz.Models;
using System.Collections.Generic;

namespace RiseOfOz.Models
{
    /// <summary>
    /// Represents data gotten from the Battle simulator
    /// needed to report about the winning army in the console
    /// </summary>
    public class BattleResult
    {
        public Army Winner;
        public List<Troop> Remaining;
        public Troop Mvp;
        public string Text;

        public override string ToString()
        {

            string report = $"WINNER\n{Winner.Name} is the winner. Remaining Troops:";
            for (int i = 0; i < Remaining.Count; i++)
            {
                Troop t = Remaining[i];
                report += $"\n{i + 1}. {t.Info.Name}, health={t.CurrentHealth}, totalDamage={t.InflictedDamage}";
            }

            report += $"\nThe most outstanding troop is:{Mvp}";

            return report;
        }
    }
}
