using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace application
{
    [TestFixture]
    public class PermuttedStringTest
    {
        [Test]
        public void PermuttedString_OK()
        {
            List<string> data = new List<string>();
            Assert.IsTrue(Permutation.IsPermutedString("abc", "cab"));
            Assert.IsTrue(Permutation.IsPermutedString("abc", "bca"));
            Assert.IsTrue(Permutation.IsPermutedString("abc", "acb"));
            Assert.IsTrue(Permutation.IsPermutedString("abc", "cba"));
        }
    }
}
