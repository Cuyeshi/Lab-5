using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IPAddressSorterLibrary;

namespace ParsingTests
{
    [TestClass]
    public class ParsingTests
    {
        [TestMethod]
        public void EmptyInput()
        {
            // Arrange
            string inputText = "";

            // Act
            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void NoIPAddressesInInput()
        {
            string inputText = "There are no IP addresses here.";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.AreEqual(0, result.Count);
        }
    }
}
