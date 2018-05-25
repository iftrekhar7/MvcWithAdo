using MVC_ADO.Models;
using MVC_ADO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ADO.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            StudentRepo repo = new StudentRepo();
            List<Student> students = repo.GetStudent().ToList();
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            DeptRepo repo = new DeptRepo();
            ViewBag.Dept = new SelectList(repo.GetDept(), "DeptId", "Name");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentRepo repo = new StudentRepo();

                    repo.AddStudent(std);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            StudentRepo repo = new StudentRepo();
            DeptRepo drepo = new DeptRepo();

            ViewBag.Dept = new SelectList(drepo.GetDept(), "DeptId", "Name");
            return View(repo.GetStudent().ToList().Find(d => d.StudentId == id));
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Student std )
        {
            try
            {
                StudentRepo repo = new StudentRepo();
               
                repo.EditStudent(std);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            StudentRepo repo = new StudentRepo();
            repo.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        // POST: Students/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
