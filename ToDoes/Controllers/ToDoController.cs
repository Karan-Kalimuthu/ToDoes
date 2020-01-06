using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (id == 0)
                return View(new ToDo());     
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.ToDoes.Where(x => x.Id == id).FirstOrDefault<ToDo>());
                }
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(ToDo toDo)
        {
            using (DBModel db = new DBModel())
            {
                if(toDo.Id==0)
                {
                    db.ToDoes.Add(toDo);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(toDo).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
                
            }
            
        }


        [HttpDelete,ActionName("Delete")]
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
                return View(new ToDo());
            else
            {
                using (DBModel db = new DBModel())
                {
                    ToDo toDo = db.ToDoes.Where(x => x.Id == id).FirstOrDefault<ToDo>();
                    db.ToDoes.Remove(toDo);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }

        }
    }
}