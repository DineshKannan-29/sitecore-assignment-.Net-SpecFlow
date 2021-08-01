using NUnit.Framework;
using System;

namespace Assignment_SiteCore_Test.Utilities
{
    class Asserter
    {
        public static void AssertAmount(Decimal actualAmount, Decimal expectedAmount)
        {
            Assert.AreEqual(actualAmount, expectedAmount);
        }

        public static void AssertIfAmountIsGreater(Decimal actualAmount, Decimal compareAmount)
        {
            Assert.IsTrue(actualAmount>compareAmount);
        }
    }
}
