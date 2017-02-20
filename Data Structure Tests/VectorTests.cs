using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures;

namespace Data_Structures.Tests
{
    [TestClass()]
    public class VectorTests
    {
        [TestMethod()]
        public void VectorTest()
        {
            var vec = new Vector<int>(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void VectorBadCapacityTest()
        {
            var vec = new Vector<int>(-1);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            var size = 5;
            var vec = new Vector<int>(size);
            var array = new int[size];

            for (var ii = 0; ii < size; ii++)
            {
                vec.Add(ii);
                array[ii] = ii;
            }

            Assert.AreEqual(size, vec.Length);

            for (var ii = 0; ii < vec.Length; ii++)
            {
                Assert.AreEqual(array[ii], vec.Get(ii));
            }
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void EmptyVector()
        {
            // Arrange
            var vec = new Vector<int>(1);

            // Assert
            Assert.AreEqual(0, vec.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void BadGet()
        {
            // Arrange
            var vec = new Vector<int>(1);

            vec.Get(1);
        }
    }
}
