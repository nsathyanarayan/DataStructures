using application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationTest
{
    [TestFixture]
    public class UniqueCharacterTest
    {
        [Test]
        public void UniqueCharacter_NullString()
        {
            Assert.IsNull(UniqueCharacter.GetUniqueCharacters(null));
        }

        [Test]
        public void UniqueCharacter_Emptytring()
        {
            Assert.IsEmpty(UniqueCharacter.GetUniqueCharacters(String.Empty));
        }

        [Test]
        public void UniqueCharacter_Success()
        {
            Assert.AreEqual("compresd", UniqueCharacter.GetUniqueCharacters("compressed"));
            Assert.AreEqual("implent", UniqueCharacter.GetUniqueCharacters("implement"));
        }
    }
}
