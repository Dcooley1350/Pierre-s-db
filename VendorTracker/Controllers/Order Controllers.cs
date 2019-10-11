using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/vendors/{vendorId}/order/new")]
        public ActionResult New(int vendorId)
        {
            Vendor newVendor = Vendor.Find(vendorId);
            return View(newVendor);
        }
        [HttpGet("/vendors/{vendorId}/order/{itemId}")]
        public ActionResult Show(int vendorId, int itemId)
        {
            Order order = Order.Find(itemId);
            Vendor vendor = Vendor.Find(vendorId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("order", order);
            model.Add("vendor", vendor);
            return View(model);

        }
    }
}