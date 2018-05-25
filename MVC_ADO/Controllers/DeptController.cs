using MVC_ADO.Models;
using MVC_ADO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ADO.Controllers
{
    public class DeptController : Controller
    {
        
        public ActionResult Index()
        {
            DeptRepo repo = new DeptRepo();
            ModelState.Clear();

            return View(repo.GetDept());
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }
        

        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Create(Dept dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DeptRepo repo = new DeptRepo();

                    repo.AddDept(dept);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        

        public ActionResult Edit(int id)
        {
            DeptRepo repo = new DeptRepo();

            return View(repo.GetDept().Find(d => d.DeptId == id));
        }
        

        [HttpPost]
        public ActionResult Edit(int id, Dept dept)
        {
            try
            {
                DeptRepo repo = new DeptRepo();
                repo.EditDept(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
      
       
        public ActionResult Delete(int id )
        {
            try
            {
                DeptRepo repo = new DeptRepo();
                repo.DeleteDept(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
