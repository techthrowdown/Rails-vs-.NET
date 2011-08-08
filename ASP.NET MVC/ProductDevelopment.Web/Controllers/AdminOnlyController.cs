using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductDevelopment.Web.Infrastructure.Filters;

namespace ProductDevelopment.Web.Controllers
{
    public class AdminOnlyController : Controller
    {
        
        [AdminOnly]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
