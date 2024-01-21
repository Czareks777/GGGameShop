
using GameShop.Repository.IRepository;
using GGameShop.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace GGameShop.Areas.Client.Controllers
{
    [Area("Client")]
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
            Models.Cart cart = new()
            {
                Game = _unitOfWork.GameRepository.Get(u => u.Id == gameId, includeProperties: "GameCategory"),
                Quantity = 1,
                GameId = gameId
            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Buy(Models.Cart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.UserId = userId;

            Models.Cart cartFromDb = _unitOfWork.CartRepository.Get(u => u.UserId == userId &&
            u.GameId == cart.GameId);

            if (cartFromDb != null)
            {
                //shopping cart exists
               
                cartFromDb.Quantity += cart.Quantity;
                _unitOfWork.CartRepository.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                //add cart record
                cart.Quantity = 1;
                _unitOfWork.CartRepository.Add(cart);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(Index));
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
