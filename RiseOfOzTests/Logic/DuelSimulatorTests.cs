using NUnit.Framework;
using RiseOfOz.Logic;
using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOzTests.Logic
{
    [TestFixture]
    public class DuelSimulatorTests
    {
        /// <summary>
        /// Ensure the damage dealt is as expected against a troop's preferred target
        /// </summary>
        [Test]
        public void DuelTest_Preferred()
        {
            TroopFactory factory= MockTroopFactory.Create();
            Troop a= factory.Create("Monkey");
            Troop b= factory.Create("Balloon");

            int expectedA = a.Info.Health - b.Info.Damage;
            int expectedB = b.Info.Health - a.Info.Damage / 2;

            string result = DuelSimulator.Duel(a, b);

            Assert.AreEqual(expectedA, a.CurrentHealth);

            Console.WriteLine(result);

        }

        [Test]
        public void DuelTest_NotPreferred()
        {
            TroopFactory factory = MockTroopFactory.Create();
            Troop a = factory.Create("Monkey");
            Troop b = factory.Create("Balloon");
            
            int expectedB = b.Info.Health - a.Info.Damage / 2;

            string result = DuelSimulator.Duel(a, b);

            Assert.AreEqual(expectedB, b.CurrentHealth);

            Console.WriteLine(result);

        }

        /// <summary>
        /// Check that "All" target preference is properly accounted for
        /// </summary>
        [Test]
        public void DuelTest_All()
        {
            TroopFactory factory = MockTroopFactory.Create();
            Troop a = factory.Create("Wizard");
            Troop b = factory.Create("Balloon");
            Troop c = factory.Create("Monkey");

            int expectedB = b.Info.Health - a.Info.Damage;
            int expectedC = c.Info.Health - a.Info.Damage;

            string result = DuelSimulator.Duel(a, b);
            DuelSimulator.Duel(a, c);

            Assert.AreEqual(expectedB, b.CurrentHealth);
            Assert.AreEqual(expectedC, c.CurrentHealth);

            Console.WriteLine(result);

        }

        /// <summary>
        /// When killing a troop, ensure inflicted damage doesn't count overkill damage. 
        /// (Record damage above the amount the dying troop had remaining)
        /// </summary>
        [Test]
        public void DuelTest_Overkill()
        {
            TroopFactory factory = MockTroopFactory.Create();
            Troop a = factory.Create("Wizard");
            Troop b = factory.Create("Balloon");
            a.CurrentHealth = 1;

            int expectedB = b.Info.Health - a.Info.Damage;

            string result = DuelSimulator.Duel(a, b);

            Assert.IsTrue(result.Contains("Wizard was killed"));
            Assert.AreEqual(1, b.InflictedDamage);  //Ensure we don't 'overkill' on calculating inflicted damage
            Console.WriteLine(result);

        }
    }
}
