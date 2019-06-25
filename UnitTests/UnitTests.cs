using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using ClassLibrary;

namespace UnitTests

{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void OrderingTest1()
        {
            List<Decimal> inList = new List<Decimal> { 17.13m, 3.09m, 9.42m, 34.5m, 22.32m, 18.22m, 5.05m, 10.0m };

            DataProvider dataProvider = new DataProvider();

            List<Decimal> orderedList = dataProvider.GetOrderedList(inList);

            List<Decimal> expectedList = new List<Decimal> {  3.09m, 9.42m, 17.13m, 22.32m, 34.5m,  18.22m, 10.0m, 5.05m };

            CollectionAssert.AreEqual(expectedList, orderedList);

        }
    }
}
