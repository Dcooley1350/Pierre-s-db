using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
    public class Order
    {
        public int Bread { get; set; }
        public int Pastry { get; set; }
        public int Id { get; }
        private List<Order> _orders; 
        public Order(int bread, int pastry)
        {
            Bread = bread;
            Pastry = pastry;
            _orders.Add(this);
            Id = _orders.Count;
        }
    }
}