using NUnit.Framework;
using RiseOfOz.IO;
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
    public class TroopFactoryTests
    {
        Dictionary<string, TroopType> troopTypes;

        [SetUp]
        public void TroopFactorySetup()
        {
            troopTypes = new Dictionary<string, TroopType>();
            string json = "{ 'Id':1,'Name':'Monkey','Type':'Ground','Damage':'6','Health':'50','PreferredTarget':'Ground','Template':'Basic'}";
            TroopType monkey = TroopReader.ReadJson(json);
            troopTypes.Add(monkey.Name, monkey);
        }

        [Test]
        public void CreateTroop_Valid()
        {
            Dictionary<string, TroopType> troopTypes = new Dictionary<string, TroopType>();
            string json = "{ 'Id':1,'Name':'Monkey','Type':'Ground','Damage':'6','Health':'50','PreferredTarget':'Ground','Template':'Basic'}";
            TroopType monkey = TroopReader.ReadJson(json);
            troopTypes.Add(monkey.Name, monkey);

            TroopFactory factory = new TroopFactory(troopTypes);
            Troop t = factory.Create("Monkey");
            Assert.AreEqual(t.Info, monkey);
            Assert.AreEqual(t.CurrentHealth, monkey.Health);
        }

        [Test]
        public void CreateTroop_NotExist()
        {
            Dictionary<string, TroopType> troopTypes = new Dictionary<string, TroopType>();
            TroopFactory factory = new TroopFactory(troopTypes);
            Assert.Throws<InvalidOperationException>(() =>
            {
                Troop t = factory.Create("Monkey");
            });
        }
    }
}
