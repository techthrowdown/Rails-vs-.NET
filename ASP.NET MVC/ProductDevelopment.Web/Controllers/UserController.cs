using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductDevelopment.Web.Infrastructure.Data;

namespace ProductDevelopment.Web.Controllers
{
    [Authorize(Users = "admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepositoryr;

        public UserController(IUserRepository userRepositoryr)
        {
            _userRepositoryr = userRepositoryr;
        }

        public ActionResult Index()
        {
            var users = _userRepositoryr.All();
            return View(users);
        }

        public ActionResult Json()
        {
            var users = _userRepositoryr.All();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
