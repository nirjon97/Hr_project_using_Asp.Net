using dhaka_hr_project.Data;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dhaka_hr_project.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ApplicationDbContext _db;



        public ShiftController(ApplicationDbContext db)
        {
            _db = db;

        }

        //get all company list
        public IActionResult Index()
        {
            IEnumerable<Shift> obj_Shift_list = _db.Shifts;
            return View(obj_Shift_list);
        }



        //create post 
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shift obj)
        {
            if (ModelState.IsValid)
            {
                _db.Shifts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Shift Created successfully.";
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
            var ShiftfromDb = _db.Shifts.Find(id);

            if (ShiftfromDb == null)
            {
                return NotFound();
            }
            ViewBag.Companies = new SelectList(_db.Companies, "ComId", "ComName");
            return View(ShiftfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Shift obj)
        {
            if (ModelState.IsValid)
            {
                _db.Shifts.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Shift updated successfully.";
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
            var ShiftfromDb = _db.Shifts.Find(id);

            if (ShiftfromDb == null)
            {
                return NotFound();
            }

            return View(ShiftfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(string? id)
        {
            var objj = _db.Shifts.Find(id);

            if (objj == null)
            {
                return NotFound();
            }

            _db.Shifts.Remove(objj);
            _db.SaveChanges();
            TempData["success"] = "Shift Deleted successfully.";
            return RedirectToAction("Index");


        }
    }
}
