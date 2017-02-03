using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebListenerTest.Controllers
{
    public class StatusCodeController : Controller
    {
        [Route("/StatusCode/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            if (statusCode == (int)HttpStatusCode.Forbidden)
            {
                return View("Forbidden");
            }
            else
            {
                return View(statusCode);
            }
            
        }
    }
}
