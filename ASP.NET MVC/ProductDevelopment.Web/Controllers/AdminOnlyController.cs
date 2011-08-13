using System.Web.Mvc;

namespace ProductDevelopment.Web.Controllers
{
    public class AdminOnlyController : Controller
    {
        [Authorize(Users = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}