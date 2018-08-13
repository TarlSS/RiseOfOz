using RiseOfOz.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOz.Logic
{

    /// <summary>
    /// Simulates a battle between two armies.
    /// Each army is assigned a commander that places all troops in a queue
    /// Commanders pick the next troop in the queue and they duel.
    /// Commanders continue dueling troops until one is defeated, in that
    /// they have no living troops left.
    /// 
    /// The simulator then places the data into a BattleResult, which reports
    /// to the console data on the winning army and the MVP
    /// </summary>
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
