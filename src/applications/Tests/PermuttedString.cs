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

        [Test]
        public void PermuttedString_NullString()
        {
            Assert.IsFalse(Permutation.IsPermutedString(null, "abc"));
        }

        [Test]
        public void PermuttedString_EmptyString()
        {
            Assert.IsFalse(Permutation.IsPermutedString(String.Empty, "abc"));
        }

        [Test]
        public void PermuttedString_UnequalStringLengths()
        {
            Assert.IsFalse(Permutation.IsPermutedString("abcd", "abc"));
        }
    }
}
