
using DataAccess;
using GameShop.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Models.Models;
using Models.ViewModels;
using Utility;

namespace GGameShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly IUnitOfWork _unitOfWork;
        public GameController(ApplicationDbContext db, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _webHostEnviroment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Game> gamesList = _unitOfWork.GameRepository.GetAll(includeProperties: "GameCategory").ToList();

            return View(gamesList);
        }



        public IActionResult Create(int? id)
        {
            GameViewModel gameViewModel = new()
            {
                GameCategoryList = _unitOfWork.GameCategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Category,
                    Value = u.Id.ToString()
                }),
                Game = new Game()
            };

            return View(gameViewModel);

        }
        [HttpPost]
        public IActionResult Create(GameViewModel gameViewModel, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnviroment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string gamePath = Path.Combine(wwwRootPath, @"images\game");



                    using (var fileStream = new FileStream(Path.Combine(gamePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    gameViewModel.Game.ImageUrl = @"\images\game\" + fileName;
                }


                _unitOfWork.GameRepository.Add(gameViewModel.Game);


                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            else
            {
                gameViewModel.GameCategoryList = _unitOfWork.GameCategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Category,
                    Value = u.Id.ToString()
                });
                return View(gameViewModel);
            }
        }
        public IActionResult Edit(int gameId)
        {
            // Sprawdź czy id jest większe od zera
            if (gameId <= 0)
            {
                return NotFound();
            }

            // Pobierz grę z repozytorium
            Game gameFromDb = _unitOfWork.GameRepository.Get(u => u.Id == gameId);

            // Sprawdź czy gra istnieje
            if (gameFromDb == null)
            {
                return NotFound();
            }

            // Utwórz obiekt GameViewModel i ustaw Game oraz GameCategoryList
            GameViewModel gameViewModel = new GameViewModel
            {
                GameCategoryList = _unitOfWork.GameCategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Category,
                    Value = u.Id.ToString()
                }),
                Game = gameFromDb
            };

            // Zwróć widok z danymi do edycji
            return View(gameViewModel);
        }
        [HttpPost]
        public IActionResult Edit(GameViewModel gameViewModel, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnviroment.WebRootPath;

                // Sprawdź, czy został przekazany plik
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string gamePath = Path.Combine(wwwRootPath, @"images\game");

                    // Zapisz nową grafikę
                    using (var fileStream = new FileStream(Path.Combine(gamePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Zaktualizuj właściwość ImageUrl w obiekcie Game
                    gameViewModel.Game.ImageUrl = @"\images\game\" + fileName;
                }

                // Pobierz grę z repozytorium
                var gameFromDb = _unitOfWork.GameRepository.Get(u => u.Id == gameViewModel.Game.Id);

                // Sprawdź zmiany w poszczególnych polach i zaktualizuj tylko te, które uległy zmianie
                if (gameFromDb.Title != gameViewModel.Game.Title)
                {
                    gameFromDb.Title = gameViewModel.Game.Title;
                }

                if (gameFromDb.Description != gameViewModel.Game.Description)
                {
                    gameFromDb.Description = gameViewModel.Game.Description;
                }

                if (gameFromDb.DevStudio != gameViewModel.Game.DevStudio)
                {
                    gameFromDb.DevStudio = gameViewModel.Game.DevStudio;
                }

                if (gameFromDb.PriceSteam != gameViewModel.Game.PriceSteam)
                {
                    gameFromDb.PriceSteam = gameViewModel.Game.PriceSteam;
                }

                if (gameFromDb.PricePS != gameViewModel.Game.PricePS)
                {
                    gameFromDb.PricePS = gameViewModel.Game.PricePS;
                }

                if (gameFromDb.PriceXbox != gameViewModel.Game.PriceXbox)
                {
                    gameFromDb.PriceXbox = gameViewModel.Game.PriceXbox;
                }

                if (gameFromDb.ImageUrl != gameViewModel.Game.ImageUrl)
                {
                    gameFromDb.ImageUrl = gameViewModel.Game.ImageUrl;
                }

                if (gameFromDb.TrailerUrl != gameViewModel.Game.TrailerUrl)
                {
                    gameFromDb.TrailerUrl = gameViewModel.Game.TrailerUrl;
                }

                // Zaktualizuj dane gry
                _unitOfWork.GameRepository.Update(gameFromDb);

                // Zapisz zmiany
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            // W przypadku błędów w danych, pobierz ponownie listę kategorii i zwróć widok
            gameViewModel.GameCategoryList = _unitOfWork.GameCategoryRepository.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Category,
                    Value = u.Id.ToString()
                });

            return View(gameViewModel);
        }



        public IActionResult Delete(int? gameId)
        {
            if (gameId == null || gameId == 0)
            {
                return NotFound();
            }
            Game? gameFromDataBase = _db.Games.FirstOrDefault(u => u.Id == gameId);

            if (gameFromDataBase == null)
            {
                return NotFound();
            }
            return View(gameFromDataBase);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? gameId)
        {
            Game? gameFromDataBase = _db.Games.FirstOrDefault(u => u.Id == gameId);
            if (gameFromDataBase == null)
            {
                return NotFound();
            }
            _db.Games.Remove(gameFromDataBase);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
