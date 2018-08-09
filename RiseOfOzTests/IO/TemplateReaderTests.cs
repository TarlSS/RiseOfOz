using Newtonsoft.Json;
using NUnit.Framework;
using RiseOfOz;
using RiseOfOz.IO;
using RiseOfOz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOzTests
{
    /// <summary>
    /// Integration Tests for Template Reader
    /// Install NUnit adapter for Visual Studio
    /// Tools -> Extensions and Updates > NUnit 3 Test Adapter
    /// </summary>
    [TestFixture]
    public class TemplateReaderTests
    {

        string path = TestContext.CurrentContext.TestDirectory;
        string templatePath;
        string troopPath;

        string monkeyJson;
        string flyingMonkeyJson;

        [SetUp]
        public void TemplateReaderSetup() {
            templatePath = path + "/Resources/Templates";
            troopPath = path + "/Resources/Troops";

            monkeyJson = troopPath + "/Monkey.json";
            flyingMonkeyJson = templatePath + "/FlyingMonkey.json";
        }

        [Test]
        public void ReadTemplateTest_Valid()
        {
            string monkeyData = File.ReadAllText(monkeyJson);
            string contents = File.ReadAllText(flyingMonkeyJson);

            //Setup base monkey troop
            TroopReader troopReader = new TroopReader();
            troopReader.AddJson(monkeyData);
            TroopType monkey = troopReader.TroopTypes["Monkey"];


            TemplateReader reader = new TemplateReader(contents, troopReader.TroopTypes);
            TroopType flyingMonkey = reader.Read();

            Assert.AreEqual(flyingMonkey.Damage, monkey.Damage);
            Assert.AreEqual(flyingMonkey.Health, monkey.Health);
            Assert.AreEqual(flyingMonkey.Type, "Air");
            Assert.AreEqual(flyingMonkey.PreferredTarget, "Air");
        }

        [Test]
        public void ReadTemplateTest_NoBaseTroopError()
        {
            string contents = File.ReadAllText(flyingMonkeyJson);

            //Setup base monkey troop
            TroopReader troopReader = new TroopReader();
            TemplateReader reader = new TemplateReader(contents, troopReader.TroopTypes);
            Assert.Throws<InvalidOperationException>(() =>
            {
                TroopType flyingMonkey = reader.Read();
            });
        }
    }
}
