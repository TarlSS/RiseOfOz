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

        /// <summary>
        /// Enqueues a troop, or if it's dead, adds it to casualties
        /// </summary>
        /// <param name="t"></param>
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

        /// <summary>
        /// Gives a list of all living troops left
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Picks the troop that did an amount of damage that has the 
        /// most consecutives 1's in a binary representation.
        /// 
        /// </summary>
        /// <returns></returns>
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
