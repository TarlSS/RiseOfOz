using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Logic
{
    /// <summary>
    /// Runs a simulation of two troops attacking each other at the same time.
    /// Also reports the result. If this were not a console program, we'd
    /// fire off an event that notifies a DuelReport/Observer.
    /// </summary>
    public class DuelSimulator
    {
        public DuelSimulator()
        {

        }

        public static string Duel(Troop a, Troop b)
        {
            a.Attack(b);
            b.Attack(a);
            return Report(a, b);

        }

        /// <summary>
        /// For the purpose of this program, it is sufficient to
        /// report the result of the duel in a string
        /// 
        /// In a more complex game, we'd refactor this functionality into a reporter
        /// class that displays the UI or powers some animations.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static string Report(Troop a, Troop b)
        {
            string report = a + " vs. " + b;
            report += GetDeath(a);
            report += GetDeath(b);
            return report;
        }

        static string GetDeath(Troop t)
        {
            if (t.CurrentHealth > 0)
            {
                return string.Empty;
            }

            return $"\n{t.ArmyName} {t.Info.Name} was killed";
        }
    }
}
