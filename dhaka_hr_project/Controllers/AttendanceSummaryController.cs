using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dhaka_hr_project.Controllers
{
    public class AttendanceSummaryController : Controller
    {
        private readonly ApplicationDbContext _db;


        public AttendanceSummaryController(ApplicationDbContext db)
        {
            _db = db;

        }

        //get all company list
        public IActionResult Index()
        {
            IEnumerable<AttendanceSummary> obj_AttendanceSummary_list = _db.AttendanceSummarys.Include(a => a.Emp);
            return View(obj_AttendanceSummary_list);
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
        public IActionResult Create(AttendanceSummary obj)
        {
            if (ModelState.IsValid)
            {
                _db.AttendanceSummarys.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "AttendanceSummary Created successfully.";
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
            var AttendanceSummaryfromDb = _db.AttendanceSummarys.Find(id);

            if (AttendanceSummaryfromDb == null)
            {
                return NotFound();
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Employees = new SelectList(_db.Employees, "EmpId", "EmpName");


            return View(AttendanceSummaryfromDb);
        }

        [HttpPost]
        public IActionResult Edit(AttendanceSummary obj)
        {
            if (ModelState.IsValid)
            {
                _db.AttendanceSummarys.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "AttendanceSummary updated successfully.";
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
            var AttendanceSummaryfromDb = _db.AttendanceSummarys.Find(id);

            if (AttendanceSummaryfromDb == null)
            {
                return NotFound();
            }

            return View(AttendanceSummaryfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(string? id)
        {
            var objj = _db.AttendanceSummarys.Find(id);

            if (objj == null)
            {
                return NotFound();
            }

            _db.AttendanceSummarys.Remove(objj);
            _db.SaveChanges();
            TempData["success"] = "AttendanceSummary Deleted successfully.";
            return RedirectToAction("Index");


        }
    }
}
