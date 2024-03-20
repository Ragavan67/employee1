using MVCCURD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCURD.Controllers
{
    public class HomeController : Controller
    {
        MVCCURDDBContex _context=new MVCCURDDBContex();
       

        public ActionResult Index()
        {
            var listofData=_context.Employees.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
           var data=_context.Employees.Where(x=>x.empid== id).FirstOrDefault(); 
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee Model)
        {
            var data=_context.Employees.Where(x=>x.empid== Model.empid).FirstOrDefault(); 
            if(data!=null)
            {
                data.empname = Model.empname;
               
                data.salaray= Model.salaray;    
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var data=_context.Employees.Where(x=>x.empid== id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int? id)
        {

            var data = _context.Employees.Where(x => x.empid == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete successfully";
            return View(data);
        
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Company company)
        {
            if (!ModelState.IsValid)
            {
                if (company.Id == "admin" && company.Name == "Ragavan")
                {
                    FormsAuthentication.SetAuthCookie(company.Id, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            ViewBag.Rv = "This Login Page";

            return View(company);
        }

    }
}