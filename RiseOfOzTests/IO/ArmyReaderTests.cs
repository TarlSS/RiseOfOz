﻿using NUnit.Framework;
using RiseOfOz;
using RiseOfOz.IO;
using RiseOfOz.Logic;
using RiseOfOz.Models;
using RiseOfOzTests.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfOzTests
{
    [TestFixture]
    public class ArmyReaderTests
    {
        /// <summary>
        /// Read all troops from JSON and ensure we have the correct troop types
        /// </summary>
        [Test]
        public void ReadArmiesTest()
        {
            string path = TestContext.CurrentContext.TestDirectory;
            TroopFactory factory = MockTroopFactory.Create();
            ArmyReader reader = new ArmyReader(path, factory);
            Dictionary<string, Army> armies = reader.Read();
            Assert.AreEqual(armies.Count, 2);
        }

        /*
         * Best Practices: Write more tests regarding
         * 1) Possible JSON Errors
         * 2) Corrupt files
         * 3) Attempts to cheat
         * 
         * Settings these tests and edge cases up takes a lot of time and is a little bit above and beyond
         * the scope of an interview project.
         */
    }
}
