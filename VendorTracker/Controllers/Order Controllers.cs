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

    }
}