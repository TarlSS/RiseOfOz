using RiseOfOz.Models;
using System.Collections.Generic;

namespace RiseOfOz.Logic
{
    /// <summary>
    /// Picks troops and tracks data over the course of a battle
    /// </summary>
    public class Commander
    {
        
        public int Casualities;
        public Army Army;
        Queue<Troop> troopQ;

        public Commander(Army army)
        {
            this.Army = army;
            this.troopQ = new Queue<Troop>();
            foreach(Troop t in army.Troops)
            {
                troopQ.Enqueue(t);
            }
        }

        public int Count()
        {
            return troopQ.Count;
        }

        public bool isDefeated()
        {
            return Casualities >= Army.Size;
        }

        public Troop Next()
        {
            return troopQ.Dequeue();
        }

        public void Enqueue(Troop t)
        {
            if (t.CurrentHealth > 0)
            {
                troopQ.Enqueue(t);
            }
            else
            {
                Casualities++;
            }
        }

        public List<Troop> Remaining()
        {
            List<Troop> remaining = new List<Troop>();
            foreach(Troop t in Army.Troops)
            {
                if (t.CurrentHealth > 0)
                {
                    remaining.Add(t);
                }
            }
            return remaining;
        }

        public Troop CalcMVP()
        {
            
            int maxOnes = 0;
            List<Troop> remaining = Remaining();
            Troop mvp = remaining[0];
            foreach(Troop t in remaining)
            {
                int ones = BinaryCounter.ConsecutiveOnes(t.InflictedDamage);
                if (ones > maxOnes)
                {
                    mvp = t;
                    maxOnes = ones;
                }
            }
            return mvp;
        }

    }
}
