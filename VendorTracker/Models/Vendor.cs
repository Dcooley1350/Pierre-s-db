using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
    public class Vendor
    {
        public string VenName { get; set; }
        public string VenDescription { get; set; }
        private static List<Vendor> _allVendors = new List<Vendor> {};
        public List <Order> Orders { get; set; }

        public Vendor(string venName, string venDescription)
        {
            VenName = venName;
            VenDescription = venDescription;
            _allVendors.Add(this);
            Orders = new List<Order> {};
        }
        public static void ClearAll()
        {
            _allVendors.Clear();
        }
        public static List<Vendor> GetAll()
        {
            return _allVendors;
        }
    }
}