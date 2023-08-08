using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dhaka_hr_project.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly ApplicationDbContext _db;
		
		public DepartmentController(ApplicationDbContext db)
		{
			_db = db;

		}

		//get all company list
		public IActionResult Index()
		{
			IEnumerable<Department> obj_department_list = _db.Departments;
			return View(obj_department_list);
		}



        //create post 
        public IActionResult Create()
		{
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Department obj)
		{
			if (ModelState.IsValid)
			{
				_db.Departments.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Department Created successfully.";
				return RedirectToAction("Index");
			}
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View(obj);
		}



		//Edit/Update post 
		public IActionResult Edit(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var DepartmentfromDb = _db.Departments.Find(id);

			if (DepartmentfromDb == null)
			{
				return NotFound();
			}
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View(DepartmentfromDb);
		}

		[HttpPost]
		public IActionResult Edit(Department obj)
		{
			if (ModelState.IsValid)
			{
				_db.Departments.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Department updated successfully.";
				return RedirectToAction("Index");
			}
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View(obj);
		}


		//Delete post 
		public IActionResult Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var DepartmentfromDb = _db.Departments.Find(id);

			if (DepartmentfromDb == null)
			{
				return NotFound();
			}

			return View(DepartmentfromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult Deletepost(string? id)
		{
			var objj = _db.Departments.Find(id);

			if (objj == null)
			{
				return NotFound();
			}

			_db.Departments.Remove(objj);
			_db.SaveChanges();
			TempData["success"] = "Department Deleted successfully.";
			return RedirectToAction("Index");


		}
	}
}
