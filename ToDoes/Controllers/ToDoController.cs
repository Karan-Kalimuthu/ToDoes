using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoes.Models;

namespace ToDoes.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<ToDo> toDos = db.ToDoes.ToList<ToDo>();
                return Json(new { data = toDos }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(ToDo toDo)
        {
            using (DBModel db = new DBModel())
            {
                db.ToDoes.Add(toDo);
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}