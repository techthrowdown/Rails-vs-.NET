using System;
using System.Linq;
using System.Web.Mvc;
using ProductDevelopment.Models;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Controllers
{
    public class DefectsController : Controller
    {
        private readonly IRepository<Defect> _defectRepo;
        private readonly IRepository<Project> _projectRepo;
        private readonly IUserRepository _userRepo;
        private readonly IRepository<Severity> _severityRepo;

        public DefectsController(IRepository<Defect> defectRepo,
                                 IRepository<Project> projectRepo,
                                 IUserRepository userRepo,
                                 IRepository<Severity> severityRepo)
        {
            _defectRepo = defectRepo;
            _projectRepo = projectRepo;
            _userRepo = userRepo;
            _severityRepo = severityRepo;
        }

        public ViewResult Index()
        {
            var viewModels = ViewModels();
            return View(viewModels);
        }

        public ViewResult Create()
        {
            var inputModel = InputModel();
            return View(inputModel);
        }

        [HttpPost]
        public ActionResult Create(Defect defect)
        {
            if (!ModelState.IsValid)
            {
                var inputModel = InputModel();
                return View(inputModel);
            }

            try
            {
                _defectRepo.Add(defect);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var inputModel = InputModel(); 
                return View(inputModel);
            }
        }

        private IQueryable<DefectSearchResultsViewModel> ViewModels()
        {
            var viewModels = _defectRepo.All()
                .Select(x => new DefectSearchResultsViewModel
                                 {
                                     Project = x.Project.Name,
                                     Summary = x.Summary,
                                     Severity = x.Severity.SeverityDescription,
                                     CreatedBy = x.CreatorUser.Username,
                                     AssignedTo = x.AssignedToUser.Username,
                                     CreateDate = x.CreateDate,
                                     ModifyDate = x.ModifyDate
                                 });
            return viewModels;
        }

        private DefectInputModel InputModel()
        {
            return new DefectInputModel
                       {
                           ProjectSelectList = ProjectSelectList(),
                           UserSelectList = UserSelectList(),
                           SeveritySelectList = SeveritySelectList()
                       };
        }

        private SelectList ProjectSelectList()
        {
            return new SelectList(_projectRepo.All(), "ProjectId", "Name");
        }

        private SelectList UserSelectList()
        {
            return new SelectList(_userRepo.All(), "UserId", "Username");
        }

        private SelectList SeveritySelectList()
        {
            return new SelectList(_severityRepo.All(), "SeverityId", "SeverityDescription");
        }
    }
}