using System.Web.Mvc;
using ProductDevelopment.Models;
using ProductDevelopment.Repository;

namespace ProductDevelopment.Web.Controllers
{
    public class DefectsController : Controller
    {
        private readonly IRepository<Defect> _repository;

        public DefectsController(IRepository<Defect> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var defects = _repository.All();
            return View(defects);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}