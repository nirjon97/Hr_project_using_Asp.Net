using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dhaka_hr_project.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _db;



        public DesignationController(ApplicationDbContext db)
        {
            _db = db;

        }

        //get all company list
        public IActionResult Index()
        {
            IEnumerable<Designation> obj_designation_list = _db.Designations;
            return View(obj_designation_list);
        }



        //create post 
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Designation obj)
        {
            if (ModelState.IsValid)
            {
                _db.Designations.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Designation Created successfully.";
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
            var DesignationfromDb = _db.Designations.Find(id);

            if (DesignationfromDb == null)
            {
                return NotFound();
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View(DesignationfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Designation obj)
        {
            if (ModelState.IsValid)
            {
                _db.Designations.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Designation updated successfully.";
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
            var DesignationfromDb = _db.Designations.Find(id);

            if (DesignationfromDb == null)
            {
                return NotFound();
            }

            return View(DesignationfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(string? id)
        {
            var objj = _db.Designations.Find(id);

            if (objj == null)
            {
                return NotFound();
            }

            _db.Designations.Remove(objj);
            _db.SaveChanges();
            TempData["success"] = "Designation Deleted successfully.";
            return RedirectToAction("Index");


        }
    }
}
