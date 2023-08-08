using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace dhaka_hr_project.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _db;


        public AttendanceController(ApplicationDbContext db)
        {
            _db = db;

        }

        //get all company list
        public IActionResult Index()
        {
            IEnumerable<Attendance> obj_Attendance_list = _db.Attendances.Include(a=>a.Emp);
            return View(obj_Attendance_list);
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
        public IActionResult Create(Attendance obj)
        {
            if (ModelState.IsValid)
                {              
                
                    _db.Attendances.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Attendance Created successfully.";
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
            var AttendancefromDb = _db.Attendances.Find(id);

            if (AttendancefromDb == null)
            {
                return NotFound();
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Employees = new SelectList(_db.Employees, "EmpId", "EmpName");


            return View(AttendancefromDb);
        }

        [HttpPost]
        public IActionResult Edit(Attendance obj)
        {
            if (ModelState.IsValid)
            {
                _db.Attendances.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Attendance updated successfully.";
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
            var AttendancefromDb = _db.Attendances.Find(id);

            if (AttendancefromDb == null)
            {
                return NotFound();
            }

            return View(AttendancefromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(string? id)
        {
            var objj = _db.Attendances.Find(id);

            if (objj == null)
            {
                return NotFound();
            }

            _db.Attendances.Remove(objj);
            _db.SaveChanges();
            TempData["success"] = "Attendance Deleted successfully.";
            return RedirectToAction("Index");


        }
    }
}
