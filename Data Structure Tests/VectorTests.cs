using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures;

namespace Data_Structure_Tests
{
    [TestClass]
    class VectorTests
    {

        [TestMethod]
        public void EmptyVector()
        {
            // Arrange
            var vec = new Vector<int>(1);

            // Assert
            Assert.AreEqual(0, vec.Length);
        }
    }
}
