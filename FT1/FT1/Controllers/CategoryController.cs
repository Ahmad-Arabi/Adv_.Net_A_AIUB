using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FT1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            var data = CategoryService.Get();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            CategoryService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = CategoryService.Get(id);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = CategoryService.Get(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(CategoryDTO cd)
        {
            CategoryService.Update(cd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryDTO cd)
        {
            CategoryService.Add(cd);
            return RedirectToAction("Index");
        }
    }
}