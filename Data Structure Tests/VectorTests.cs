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
            var size = 5;
            var vec = new Vector<int>(size);
            for (int ii = 0; ii < size; ii++)
            {
                vec.Add(ii + 1);
            }

            // Check for non-zero values
            foreach (var item in vec)
            {
                Assert.AreNotEqual(0, item);
            }
        }

        [TestMethod()]
        public void GetTest()
        {
            var vec = new Vector<int>(1);

            vec.Add(5);

            var result = vec.Get(0);

            Assert.AreEqual(5, result);
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
            var size = 5;
            var vec = new Vector<int>(size);

            for (int ii = 0; ii < size - 1; ii++)
            {
                vec.Add(ii);
            }

            vec.Insert(0, 10);

            for (int ii = 0; ii < vec.Length; ii++)
            {
                if (ii == 0)
                {
                    Assert.AreEqual(10, vec.Get(ii));
                }

                else
                {
                    var result = vec.Get(ii);
                    Assert.AreEqual(ii - 1, result);
                }
            }
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var size = 5;
            var vec = new Vector<int>(size);
            var array = new int[size];

            for (var ii = 0; ii < size; ii++)
            {
                vec.Add(ii);
                array[ii] = ii;
            }

            var index = 2;

            vec.Delete(index);

            Assert.AreEqual(size - 1, vec.Length);

            for (int ii = index; ii < array.Length - 1; ii++)
            {
                array[ii] = array[ii + 1];
            }

            for (int ii = 0; ii < vec.Length; ii++)
            {
                Assert.AreEqual(array[ii], vec.Get(ii));
            }
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
