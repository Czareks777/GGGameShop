using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace GGameShop.Controllers
{
    public class GameCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GameCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<GameCategory> gameCategoryList = _db.GameCategories.ToList();
            return View(gameCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GameCategory entity)
        {
            if (ModelState.IsValid)
            {
                _db.GameCategories.Add(entity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? gameCategoryId)
        {
            if (gameCategoryId == null || gameCategoryId == 0)
            {
                return NotFound();
            }
            GameCategory? gameCategoryFromDataBase = _db.GameCategories.FirstOrDefault(u => u.Id == gameCategoryId);


            if (gameCategoryFromDataBase == null)
            {
                return NotFound();
            }
            return View(gameCategoryFromDataBase);
        }
        [HttpPost]
        public IActionResult Edit(GameCategory entity)
        {
            if (ModelState.IsValid)
            {
                _db.GameCategories.Update(entity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? gameCategoryId)
        {
            if (gameCategoryId == null || gameCategoryId == 0)
            {
                return NotFound();
            }
            GameCategory? gameCategoryFromDataBase = _db.GameCategories.FirstOrDefault(u => u.Id == gameCategoryId);

            if (gameCategoryFromDataBase == null)
            {
                return NotFound();
            }
            return View(gameCategoryFromDataBase);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? gameCategoryId)
        {
            GameCategory? gameCategoryFromDataBase = _db.GameCategories.Find(gameCategoryId);
            if (gameCategoryFromDataBase == null)
            {
                return NotFound();
            }
            _db.GameCategories.Remove(gameCategoryFromDataBase);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}