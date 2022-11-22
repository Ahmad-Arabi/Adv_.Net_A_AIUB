using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FT1.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Index()
        {
            var data = NewsService.Get();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            NewsService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = NewsService.Get(id);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = NewsService.Get(id);
            ViewBag.cs = CategoryService.Get();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(NewsDTO cd)
        {
            NewsService.Update(cd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var cs = CategoryService.Get();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Create(NewsDTO cd)
        {
            NewsService.Add(cd);
            return RedirectToAction("Index");
        }
    }
}