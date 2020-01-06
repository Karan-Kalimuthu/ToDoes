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
    }
}