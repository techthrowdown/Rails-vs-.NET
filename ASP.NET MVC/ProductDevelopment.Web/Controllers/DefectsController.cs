using System.Linq;
using System.Web.Mvc;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Models;

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
            var defects = _repository.All()
                .Select(x => new DefectSearchResultsViewModel
                                 {
                                     Id = x.DefectId,
                                     Project = x.Project.Name,
                                     Summary = x.Summary,
                                     Severity = x.Severity.SeverityDescription,
                                     CreatedBy = x.CreatorUserId.Username,
                                     AssignedTo = x.AssignedToUserId.Username,
                                     CreateDate = x.CreateDate,
                                     ModifyDate = x.ModifyDate
                                 });
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