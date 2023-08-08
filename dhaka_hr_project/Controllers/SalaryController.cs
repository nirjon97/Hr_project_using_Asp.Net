using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace dhaka_hr_project.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _db;


        public SalaryController(ApplicationDbContext db)
        {
            _db = db;

        }

        //get all company list
        public IActionResult Index()
        {
            IEnumerable<Salary> obj_Salary_list = _db.Salarys.Include(a =>a.Emp);
            return View(obj_Salary_list);
        }



        //create post 
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Employees = new SelectList(_db.Employees, "EmpId", "EmpName");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Salary obj)
        {
            if (ModelState.IsValid)
            {
                var employee = _db.Employees.Find(obj.EmpId);
                obj.Gross = employee.Gross;
                obj.Basic = employee.Basic;
                obj.HRent =employee.HRent;
                obj.Medical= employee.Medical;

                var ab = _db.AttendanceSummarys
                .FirstOrDefault(a => a.CompanyId == obj.CompanyId && a.EmpId == obj.EmpId && a.dtYear == obj.dtYear && a.dtMonth == obj.dtMonth);
                var absent = ab.Absent;
                obj.AbsentAmount = (obj.Basic / 30) * absent;
                
            

                obj.PayableAmount = obj.Gross - obj.AbsentAmount;

               
                if (obj.IsPaid == true)
                {
                    obj.PaidAmount = obj.PayableAmount;
                }
                else
                {
                    obj.PaidAmount = 0;
                }
                


                _db.Salarys.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Salary Created successfully.";
                return RedirectToAction("Index");
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Employees = new SelectList(_db.Employees, "EmpId", "EmpName");


            return View(obj);
        }



        //Edit/Update post 
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var SalaryfromDb = _db.Salarys.Find(id);

            if (SalaryfromDb == null)
            {
                return NotFound();
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Employees = new SelectList(_db.Employees, "EmpId", "EmpName");


            return View(SalaryfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Salary obj)
        {
            if (ModelState.IsValid)
            {
                _db.Salarys.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Salary updated successfully.";
                return RedirectToAction("Index");
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Employees = new SelectList(_db.Employees, "EmpId", "EmpName");


            return View(obj);
        }


        //Delete post 
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var SalaryfromDb = _db.Salarys.Find(id);

            if (SalaryfromDb == null)
            {
                return NotFound();
            }

            return View(SalaryfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(string? id)
        {
            var objj = _db.Salarys.Find(id);

            if (objj == null)
            {
                return NotFound();
            }

            _db.Salarys.Remove(objj);
            _db.SaveChanges();
            TempData["success"] = "Salary Deleted successfully.";
            return RedirectToAction("Index");


        }
    }
}
