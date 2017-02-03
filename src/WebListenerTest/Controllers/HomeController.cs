using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebListenerTest.Auth;

namespace WebListenerTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize(Policies.MarketingOnly)]
        public IActionResult Marketing()
        {
            return View();
        }

        [Authorize(Policies.FinanceOnly)]
        public IActionResult Finance()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
