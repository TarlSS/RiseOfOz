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
    public class CommanderTests
    {
        Army army;
        [SetUp]
        public void CommanderSetup()
        {
            int size = 7;
            string[] composition = new string[] { "Monkey", "Balloon", "Wizard" };

            army = new Army();
            army.Composition = composition;
            army.Name = "Test Army";
            army.Size = size;

            TroopFactory factory = MockTroopFactory.Create();

            ArmyComposer composer = new ArmyComposer(factory);
            army.Troops = composer.Compose(army);

        }

        /// <summary>
        /// Ensure the next troop is being called correctly
        /// </summary>
        [Test]
        public void NextTest()
        {
            Commander commander = new Commander(army);
            Troop result = commander.Next();
            Assert.AreEqual("Monkey", result.Info.Name);
            result = commander.Next();
            Assert.AreEqual("Balloon", result.Info.Name);
            result = commander.Next();
            Assert.AreEqual("Wizard", result.Info.Name);
        }
        
        /// <summary>
        /// Ensure casualties are counted correctly in the enqueue function
        /// </summary>
        [Test]
        public void CasualtyEnqueueTest()
        {
            Commander commander = new Commander(army);
            Troop result = commander.Next();
            result.CurrentHealth = 0;
            commander.Enqueue(result);
            Assert.AreEqual(1, commander.Casualities);
            Assert.AreEqual(6, commander.Count());
        }
    }
}
