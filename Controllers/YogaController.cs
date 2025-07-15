using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogaSix.Models;

namespace YogaSix.Controllers
{
    public class YogaController : Controller
    {
        private readonly YogaSixContext _context;

        public YogaController(YogaSixContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var classes = _context.YogaClasses.Include(c => c.ChallengeLevel).ToList();
            return View("Index", classes);
        }

        public IActionResult Add()
        {
            ViewBag.Levels = GetLevels();
            return View("Edit", new YogaClass());
        }
        [HttpPost]
        public IActionResult Add(YogaClass model)
        {
            if (ModelState.IsValid)
            {
                _context.YogaClasses.Add(model);_context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Levels = GetLevels();
            return View("Edit", model);
        }
        public IActionResult Edit(int id)
        {
            var yoga = _context.YogaClasses.Include(y => y.ChallengeLevel).FirstOrDefault(y => y.ClassId == id);
            if (yoga == null)
                return NotFound();

            ViewBag.Levels = GetLevels();
            return View("Edit", yoga);  // uses Edit.cshtml
        }
        [HttpPost]
        public IActionResult Edit(YogaClass model)
        {
            if (ModelState.IsValid)
            {
                _context.YogaClasses.Update(model);_context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Levels = GetLevels();
            return View("Edit", model);
        }
        public IActionResult Delete(int id)
        {
            var yoga = _context.YogaClasses.Include(c => c.ChallengeLevel).FirstOrDefault(c => c.ClassId == id);
            if (yoga == null)
                return NotFound();

            return View(yoga);
        }
        [HttpPost]
       public IActionResult Delete(YogaClass model)
        {
            var toDelete = _context.YogaClasses.Find(model.ClassId);
            if (toDelete == null)
                return NotFound();
            _context.YogaClasses.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        private SelectList GetLevels()
        {
            return new SelectList(_context.ChallengeLevels.OrderBy(l => l.Name),"ChallengeLevelId", "Name");
        }
    }
}
