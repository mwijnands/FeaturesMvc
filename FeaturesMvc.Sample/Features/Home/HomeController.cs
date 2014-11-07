using System;
using System.Linq;
using System.Web.Mvc;
using XperiCode.FeaturesMvc.Sample.Features.Home.Models;

namespace XperiCode.FeaturesMvc.Sample.Features.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var viewModel = new ContactViewModel
            {
                AddressLine1 = "One Microsoft Way",
                AddressLine2 = "Redmond, WA 98052-6399",
                PhoneNumber = "425.555.0100"
            };

            return View(viewModel);
        }
    }
}