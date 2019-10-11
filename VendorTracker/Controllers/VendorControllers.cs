using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/Vendors")]
        public ActionResult Index(){
        List<Vendor> vendorList = Vendor.GetAll();
        return View(vendorList);
        }
    }
}