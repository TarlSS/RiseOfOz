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
    /// <summary>
    /// Test different arrangements of binary numbers to ensure our consecutive one's counter is working
    /// properly
    /// </summary>
    [TestFixture]
    public class BinaryCounterTests
    {
        [Test]
        public void ConsecutiveOnesTest_Front()
        {
            string binary = "111100110111";
            int result = BinaryCounter.ConsecutiveOnes(binary);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void ConsecutiveOnesTest_Middle()
        {
            string binary = "111100111110111";
            int result = BinaryCounter.ConsecutiveOnes(binary);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void ConsecutiveOnesTest_End()
        {
            string binary = "10111";
            int result = BinaryCounter.ConsecutiveOnes(binary);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void ConsecutiveOnesTest_None()
        {
            string binary = "00";
            int result = BinaryCounter.ConsecutiveOnes(binary);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ConsecutiveOnesTest_FrontLoad()
        {
            string binary = "1100";
            int result = BinaryCounter.ConsecutiveOnes(binary);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ConsecutiveOnesTest_BackLoad()
        {
            string binary = "001";
            int result = BinaryCounter.ConsecutiveOnes(binary);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ConsecutiveOnesTest_IntConversion5()
        {
            int result = BinaryCounter.ConsecutiveOnes(5);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ConsecutiveOnesTest_IntConversion6()
        {
            int result = BinaryCounter.ConsecutiveOnes(6);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ConsecutiveOnesTest_IntConversion10()
        {
            int result = BinaryCounter.ConsecutiveOnes(10);
            Assert.AreEqual(1, result);
        }
    }
}
