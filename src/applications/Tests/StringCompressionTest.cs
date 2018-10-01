using application;
using NUnit.Framework;
using System;

namespace applicationTest
{
    [TestFixture]
    public class StringCompressionTest
    {
        [Test]
        public void GetCompressedString_Success()
        {
            var data = StringCompression.GetCompressedString("aabcccccaaa");
            Assert.AreEqual(data, "a2b1c5a3", "Strings are not compressed properly.");

            data = StringCompression.GetCompressedString("aaaabcdddeeeeee");
            Assert.AreEqual(data, "a4b1c1d3e6", "Strings are not compressed properly.");            
        }

        [Test]
        public void GetCompressedString_Null()
        {
            var data = StringCompression.GetCompressedString(null);
            Assert.IsNull(data);
        }

        [Test]
        public void GetCompressedString_IsEmpty()
        {
            var data = StringCompression.GetCompressedString(String.Empty);
            Assert.IsEmpty(data);
        }
    }
}
