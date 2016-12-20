using System;
using SnelRekenen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnelRekenen.unittest
{
    [TestClass]
    public class SumUser
    {
        [TestMethod]
        public void SumSomeNumbers()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UnreliableOutcomes()
        {
            var seconds = DateTime.Now.Second;
            Assert.AreEqual(0, (seconds % 2));
        }

    }
}
