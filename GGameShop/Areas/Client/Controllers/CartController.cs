using GameShop.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;
using Models.ViewModels;
using Stripe.Checkout;
using System.Numerics;
using System.Security.Claims;

namespace GGameShop.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize]
    public class CartController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public CartViewModel CartViewModel { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult BuyNow()
        {
            
            return View(CartViewModel);
        }


        [HttpPost]
        public IActionResult BuyNowPOST()
        {
            return View();
        }
    


    public IActionResult Confirmation()
    {
        return View();
    }


    public IActionResult Index()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        CartViewModel = new()
        {
            CartList = _unitOfWork.CartRepository.GetAll(u => u.UserId == userId,
            includeProperties: "Game"),
            OrderHeader = new()
        };



        return View(CartViewModel);

    }

    public IActionResult Delete(int cartId)
    {
        var cartDb = _unitOfWork.CartRepository.Get(x => x.Id == cartId);
        _unitOfWork.CartRepository.Remove(cartDb);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }

}
}

