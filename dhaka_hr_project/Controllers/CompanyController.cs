using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace dhaka_hr_project.Controllers
{
	public class CompanyController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CompanyController(ApplicationDbContext db)
		{
			_db = db;

		}

		//get all company list
		public IActionResult Index()
		{
			IEnumerable<Company> obj_company_list = _db.Companies;
			return View(obj_company_list);
		}



		//create post 
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Company obj)
		{
			if (ModelState.IsValid)
			{
				_db.Companies.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Company Created successfully.";
				return RedirectToAction("Index");
			}

			return View(obj);
		}



		//Edit/Update post 
		public IActionResult Edit(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var CompanyfromDb = _db.Companies.Find(id);

			if (CompanyfromDb == null)
			{
				return NotFound();
			}

			return View(CompanyfromDb);
		}

		[HttpPost]
		public IActionResult Edit(Company obj)
		{
			if (ModelState.IsValid)
			{
				_db.Companies.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Company updated successfully.";
				return RedirectToAction("Index");
			}

			return View(obj);
		}


		//Delete post 
		public IActionResult Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var CompanyfromDb = _db.Companies.Find(id);

			if (CompanyfromDb == null)
			{
				return NotFound();
			}

			return View(CompanyfromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult Deletepost(string? id)
		{
			var objj = _db.Companies.Find(id);

			if (objj == null)
			{
				return NotFound();
			}

			_db.Companies.Remove(objj);
			_db.SaveChanges();
			TempData["success"] = "Company Deleted successfully.";
			return RedirectToAction("Index");


		}
	}
}
