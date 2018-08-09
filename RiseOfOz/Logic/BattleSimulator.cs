using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Logic
{
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

    public class BattleSimulator
    {
        Commander commanderA;
        Commander commanderB;

        public BattleResult Result { get; set; }

        public BattleSimulator(Army a, Army b)
        {
            this.commanderA = new Commander(a);
            this.commanderB = new Commander(b);

        }

        public void Battle()
        {
            //select next troops
            Troop a = commanderA.Next();
            Troop b = commanderB.Next();
            string result = DuelSimulator.Duel(a, b);
            Console.WriteLine(result);
            commanderA.Enqueue(a);
            commanderB.Enqueue(b);

            if(commanderA.isDefeated() || commanderB.isDefeated())
            {
                PostBattleReport();
                return;
            }
            else
            {
                Battle();
            }
        }

        public void PostBattleReport()
        {
            Commander winner = commanderA.isDefeated() ? commanderB : commanderA;
            this.Result = new BattleResult
            {
                Winner = winner.Army,
                Remaining = winner.Remaining(),
                Mvp = winner.CalcMVP()
            };
        }

    }
}
