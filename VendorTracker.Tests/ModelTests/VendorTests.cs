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

        }
        [TestMethod]
        public void Constructor_ConstructorBuildsClass_Vendor()
        {
            Assert.AreEqual(newVendor.GetType(),typeof(Vendor));
        }
    }
}