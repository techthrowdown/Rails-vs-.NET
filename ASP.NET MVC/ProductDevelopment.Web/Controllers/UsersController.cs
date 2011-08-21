using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Controllers
{
    [Authorize(Users = "admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var users = _userRepository.All();
            return View(users);
        }

        public ActionResult Create()
        {
            var userInputModel = new UserInputModel();
            return View(userInputModel);
        }

        [HttpPost]
        public ActionResult Create(UserInputModel userInputModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userInputModel);
            }

            try
            {
                var user = new User()
                               {
                                   Admin = userInputModel.Admin,
                                   Password = userInputModel.Password,
                                   Username = userInputModel.Username
                               };
                _userRepository.Add(user);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userInputModel);
            }
        }

        public ActionResult ValidateUser(string username)
        {
            bool validUsername = _userRepository.FindByUsername(username) == null;
            return Json(validUsername, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Json()
        {
            var users = _userRepository.All();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
       
    }
}
