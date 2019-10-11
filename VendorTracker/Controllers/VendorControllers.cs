using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index(){
        List<Vendor> vendorList = Vendor.GetAll();
        return View(vendorList);
        }
        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName, string vendorDescription)
        {
            Vendor newVendor = new Vendor(vendorName,vendorDescription);
            return RedirectToAction("Index");
        }
        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string,object> model = new Dictionary<string,object>{};
            Vendor foundVendor = Vendor.Find(id);
            List<Order> orders = foundVendor.Orders;
            model.Add("vendor",foundVendor);
            model.Add("order",orders);
            return View(model);
        }
    }
}