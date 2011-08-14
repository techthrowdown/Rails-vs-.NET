using System.Linq;
using System.Web.Mvc;
using ProductDevelopment.Models;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Infrastructure.Security;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Controllers
{
    public class DefectsController : Controller
    {
        private readonly IRepository<Defect> _defectRepo;
        private readonly IRepository<Project> _projectRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IAuthentication _authentication;

        public DefectsController(IRepository<Defect> defectRepo, IRepository<Project> projectRepo, IRepository<User> userRepo, IAuthentication authentication)
        {
            _defectRepo = defectRepo;
            _authentication = authentication;
            _projectRepo = projectRepo;
            _userRepo = userRepo;
        }

        public ViewResult Index()
        {
            var viewModels = _defectRepo.All()
                .Select(x => new DefectSearchResultsViewModel
                                 {
                                     Project = x.Project.Name,
                                     Summary = x.Summary,
                                     Severity = x.Severity.SeverityDescription,
                                     CreatedBy = x.CreatorUserId.Username,
                                     AssignedTo = x.AssignedToUserId.Username,
                                     CreateDate = x.CreateDate,
                                     ModifyDate = x.ModifyDate
                                 });
            return View(viewModels);
        }

        public ViewResult Create()
        {
            var currentUser = _authentication.CurrentUser();
            var inputModel = new DefectInputModel
                                 {
                                     CreatorUserId = currentUser,
                                     AssignedToUserId = currentUser,
                                     ProjectSelectList = new SelectList(_projectRepo.All(), "ProjectId", "Name"),
                                     UserSelectList = new SelectList(_userRepo.All(), "UserId", "Username", currentUser != null ? currentUser.UserId.ToString() : null)
                                 };
            return View(inputModel);
        }

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