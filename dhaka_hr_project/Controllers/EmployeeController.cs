using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dhaka_hr_project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;



        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;

        }

        //get all company list
        public IActionResult Index()
        {
            IEnumerable<Employee> obj_Employee_list = _db.Employees.Include(a => a.Company);
            return View(obj_Employee_list);
        }



        //create post 
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Shifts = new SelectList(_db.Shifts, "ShiftId", "ShiftName");
            ViewBag.Departments = new SelectList(_db.Departments, "DeptId", "DeptName");
            ViewBag.Designations = new SelectList(_db.Designations, "DesigId", "DesigName");
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                // Calculate Basic, HRent, Medical, and Others based on Gross
                var company = _db.Companies.Find(obj.CompanyId);

                obj.Basic = (company.Basic / 100) * obj.Gross;
                obj.HRent = (company.HRent / 100) * obj.Gross;
                obj.Medical = (company.Medical / 100) * obj.Gross;
                obj.Others =  obj.Gross-(obj.Basic+obj.HRent+obj.Medical);


                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee Created successfully.";
                return RedirectToAction("Index");
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Shifts = new SelectList(_db.Shifts, "ShiftId", "ShiftName");
            ViewBag.Departments = new SelectList(_db.Departments, "DeptId", "DeptName");
            ViewBag.Designations = new SelectList(_db.Designations, "DesigId", "DesigName");

            return View(obj);
        }



        //Edit/Update post 
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var EmployeefromDb = _db.Employees.Find(id);

            if (EmployeefromDb == null)
            {
                return NotFound();
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Shifts = new SelectList(_db.Shifts, "ShiftId", "ShiftName");
            ViewBag.Departments = new SelectList(_db.Departments, "DeptId", "DeptName");
            ViewBag.Designations = new SelectList(_db.Designations, "DesigId", "DesigName");

            return View(EmployeefromDb);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                // Calculate Basic, HRent, Medical, and Others based on Gross

                obj.Basic = 0.5 * obj.Gross;
                obj.HRent = 0.3 * obj.Gross;
                obj.Medical = 0.15 * obj.Gross;
                obj.Others = obj.Gross - (obj.Basic + obj.HRent + obj.Medical);



                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee updated successfully.";
                return RedirectToAction("Index");
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            ViewBag.Shifts = new SelectList(_db.Shifts, "ShiftId", "ShiftName");
            ViewBag.Departments = new SelectList(_db.Departments, "DeptId", "DeptName");
            ViewBag.Designations = new SelectList(_db.Designations, "DesigId", "DesigName");

            return View(obj);
        }


        //Delete post 
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var EmployeefromDb = _db.Employees.Find(id);

            if (EmployeefromDb == null)
            {
                return NotFound();
            }

            return View(EmployeefromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(string? id)
        {
            var objj = _db.Employees.Find(id);

            if (objj == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(objj);
            _db.SaveChanges();
            TempData["success"] = "Employee Deleted successfully.";
            return RedirectToAction("Index");


        }
    }
}
