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
    public class ArmyComposerTests
    {
        [Test]
        public void ComposeTest()
        {

            int size = 7;
            string[] composition = new string[] { "Monkey", "Balloon", "Wizard" };

            Army army = new Army();
            army.Composition = composition;
            army.Name = "Test Army";
            army.Size = size;
            string[] expected = new string[] { "Monkey", "Balloon", "Wizard", "Monkey", "Balloon", "Wizard", "Monkey" };

            TroopFactory factory = MockTroopFactory.Create();

            ArmyComposer composer = new ArmyComposer(factory);
            List<Troop> troops = composer.Compose(army);

            List<string> troopNames = troops.Select(x => x.Info.Name).ToList();
            Assert.AreEqual(expected, troopNames.ToArray());
        }
    }
}
