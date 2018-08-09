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
    /// <summary>
    /// A mock troop factory. This factory generates arbitrary troop types as it is 
    /// for unit tests and we don't want to call any unneccessary IO.
    /// </summary>
    public class MockTroopFactory
    {
        public static TroopFactory Create()
        {
            Dictionary<string, TroopType> troopTypes = new Dictionary<string, TroopType>();
            string monkeyJ = "{ 'Id':1,'Name':'Monkey','Type':'Ground','Damage':'6','Health':'50','PreferredTarget':'Ground','Template':'Basic'}";
            string wizardJ = "{ 'Id':2,'Name':'Wizard','Type':'Ground','Damage':'6','Health':'60','PreferredTarget':'All','Template':'Basic'}";
            string balloonJ = "{ 'Id':3,'Name':'Balloon','Type':'Air','Damage':'8','Health':'55','PreferredTarget':'Ground','Template':'Basic'}";
            string fmonkeyJ = "{ 'Id':4,'Name':'Flying Monkey','Type':'Air','Damage':'6','Health':'50','PreferredTarget':'Air','Template':'Subtype'}";

            troopTypes.Add("Monkey", TroopReader.ReadJson(monkeyJ));
            troopTypes.Add("Wizard", TroopReader.ReadJson(wizardJ));
            troopTypes.Add("Flying Monkey", TroopReader.ReadJson(fmonkeyJ));
            troopTypes.Add("Balloon", TroopReader.ReadJson(balloonJ));

            TroopFactory factory = new TroopFactory(troopTypes);
            return factory;
        }

    }
}
