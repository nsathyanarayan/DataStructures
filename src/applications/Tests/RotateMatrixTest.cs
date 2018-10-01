using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application;
using NUnit.Framework;

namespace applicationTest
{
    [TestFixture]
    public class RotateMatrixTest
    {
        [Test]
        public void Rotate_Success()
        {
            int[,] data = new int[4,4] {{3, 6, 9, 10}, {4, 5, 6, 8}, {1,2,3, 6 }, {4, 7, 8, 9}};
            var result = RotateMatrix.Rotate(data, 4);
            Assert.AreEqual(result[0, 0], 10, "(0,0) is not equal to 10.");
            Assert.AreEqual(result[1, 0], 9, "(1,0) number is not equal to 9.");
            Assert.AreEqual(result[2, 0], 6, "(2,0) number is not equal to 6.");
            Assert.AreEqual(result[3, 0], 3, "(3,0) number is not equal to 3.");
        }
    }
}
