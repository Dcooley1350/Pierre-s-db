using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace VendorTracker.Tests
{
    [TestClass]
    public class VendorTest
    {
        string venName;
        string venDescription;
        Vendor newVendor;

        [TestInitialize]
        public void Setup()
        {
            venName = "John McClane";
            venDescription = "One bad muffugga.";
            newVendor = new Vendor(venName,venDescription);
        }
        [TestCleanup]
        public void TearDown()
        {
            Vendor.ClearAll();
        }
        [TestMethod]
        public void Constructor_ConstructorBuildsClass_Vendor()
        {
            Assert.AreEqual(newVendor.GetType(),typeof(Vendor));
        }
        [TestMethod]
        public void GetAll_ReturnsAllInstancesofVendor_List()
        {
            List<Vendor> expectedList = new List<Vendor>{newVendor};
            List<Vendor> actualList = Vendor.GetAll();
            CollectionAssert.AreEqual(expectedList,actualList);
        }
        [TestMethod]
        public void Find_FindVendorById_Vendor()
        {
            string name = "Jarf";
            int IdToFind = 2;
            Vendor testVendor = new Vendor(name,venDescription);
            Vendor foundVen = Vendor.Find(IdToFind);
            Assert.AreEqual(testVendor,foundVen);
        }
        [TestMethod]
        public void AddOrder_AssociatesOrderWitVendor_OrderList()
        {
            string nombre = "miguel";
            string descriptione = "seeName";
            string fecha = "10/10/2019";
            int price = 32;
            Order newOrder = new Order(nombre,descriptione,price,fecha);
            newVendor.AddOrder(newOrder);
            int expOrders = 1;
            int actOrders = newVendor.Orders.Count;
            Assert.AreEqual(expOrders,actOrders);
        }
    }
}