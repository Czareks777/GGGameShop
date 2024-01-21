
using GameShop.Repository.IRepository;
using GGameShop.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;
using System.Diagnostics;

namespace GGameShop.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Buy(int gameId)
        {
            Game gameBuy = _unitOfWork.GameRepository.Get(u => u.Id == gameId);
            return View(gameBuy);
        }
        public IActionResult FPS()
        {
            IEnumerable<Game> gameList = _unitOfWork.GameRepository.GetAll();
            return View(gameList);
        }
        public IActionResult RPG()
        {
            IEnumerable<Game> gameList = _unitOfWork.GameRepository.GetAll();
            return View(gameList);
        }
        public IActionResult Strategy()
        {
            IEnumerable<Game> gameList = _unitOfWork.GameRepository.GetAll();
            return View(gameList);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
