using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IPAddressSorterLibrary;

namespace ParsingTests
{
    /// <summary>
    /// Класс для тестирования программы по парсингу текста.
    /// </summary>
    [TestClass]
    public class ParsingTests
    {
        /// <summary>
        /// Тест на проверку пустого ввода.
        /// </summary>
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

        /// <summary>
        /// Тест на проверку отсутствия адресов
        /// </summary>
        [TestMethod]
        public void NoIPAddressesInInput()
        {
            string inputText = "There are no IP addresses here.";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.AreEqual(0, result.Count);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SingleClassAIP()
        {
            string inputText = "192.168.0.1";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.IsTrue(result.ContainsKey("C"));
            CollectionAssert.AreEqual(new List<string> { "192.168.0.1" }, result["C"]);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SingleClassEIP()
        {
            string inputText = "255.255.255.255";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.IsTrue(result.ContainsKey("E"));
            CollectionAssert.AreEqual(new List<string> { "255.255.255.255" }, result["E"]);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void MultipleIPInSingleClass()
        {
            string inputText = "192.168.0.1, 192.168.0.2, 192.168.0.3";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.IsTrue(result.ContainsKey("C"));
            CollectionAssert.AreEqual(new List<string> { "192.168.0.1", "192.168.0.2", "192.168.0.3" }, result["C"]);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IPsInAllClasses()
        {
            string inputText = "1.1.1.1, 150.0.0.1, 200.200.200.200, 224.0.0.1, 255.255.255.255";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.IsTrue(result.ContainsKey("A"));
            Assert.IsTrue(result.ContainsKey("B"));
            Assert.IsTrue(result.ContainsKey("C"));
            Assert.IsTrue(result.ContainsKey("D"));
            Assert.IsTrue(result.ContainsKey("E"));
            CollectionAssert.AreEqual(new List<string> { "1.1.1.1" }, result["A"]);
            CollectionAssert.AreEqual(new List<string> { "150.0.0.1" }, result["B"]);
            CollectionAssert.AreEqual(new List<string> { "200.200.200.200" }, result["C"]);
            CollectionAssert.AreEqual(new List<string> { "224.0.0.1" }, result["D"]);
            CollectionAssert.AreEqual(new List<string> { "255.255.255.255" }, result["E"]);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void InvalidIPsInInput()
        {
            string inputText = "Not an IP: 192.168.0.1, 999.999.999.999, Another string, 255.255.255.255";

            Dictionary<string, List<string>> result = IPAddressSorter.SortIPAddressesByClass(inputText);

            Assert.IsTrue(result.ContainsKey("C"));
            Assert.IsTrue(result.ContainsKey("E"));
            CollectionAssert.AreEqual(new List<string> { "192.168.0.1" }, result["C"]);
            CollectionAssert.AreEqual(new List<string> { "255.255.255.255" }, result["E"]);
        }



    }
}
