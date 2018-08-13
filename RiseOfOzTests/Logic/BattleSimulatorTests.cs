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
    public class BattleSimulatorTests
    {
        Army monkeyArmy;
        Army wizardArmy;
        [SetUp]
        public void BattleSimulatorSetup()
        {
            int size = 3;
            string[] monkeyCompo = new string[] { "Flying Monkey", "Monkey"};
            string[] wizardCompo = new string[] { "Wizard" };


            this.monkeyArmy = new Army();
            monkeyArmy.Composition = monkeyCompo;
            monkeyArmy.Name = "Monkey Army";
            monkeyArmy.Size = size;

            this.wizardArmy = new Army();
            wizardArmy.Composition = wizardCompo;
            wizardArmy.Name = "Wizard Army";
            wizardArmy.Size = size;

            TroopFactory factory = MockTroopFactory.Create();

            ArmyComposer composer = new ArmyComposer(factory);
            monkeyArmy.Troops = composer.Compose(monkeyArmy);
            wizardArmy.Troops = composer.Compose(wizardArmy);

        }

        /// <summary>
        /// Ensure that monkeys lose to wizards.
        /// Best Practices: Create a test generator that runs through all possible army combos.
        /// </summary>
        [Test]
        public void BattleTest()
        {
            BattleSimulator sim = new BattleSimulator(monkeyArmy, wizardArmy);
            sim.Battle();
            Assert.AreEqual(wizardArmy.Name, sim.Result.Winner.Name);
            Console.WriteLine(sim.Result);

        }
       
    }
}
