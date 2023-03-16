using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Net.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Net.EF.Data;

namespace Lab.Net.EF.Logic.Tests
{
    [TestClass()]
    public class RegionLogicTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "Northwind")
                .Options;

            var context = new NorthwindContext(options);
            var _regionLogic = new RegionLogic(context);

            // Act
            _regionLogic.Add(new Region { RegionDescription = "Prueba" });

            // Assert
            Assert.AreEqual(1, context.Regions.Count());



        }
    }
}