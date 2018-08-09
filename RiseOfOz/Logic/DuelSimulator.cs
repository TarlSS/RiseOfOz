using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Logic
{
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
