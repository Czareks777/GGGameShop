using DataAccess;
using GameShop.Repository.IRepository;
using GGameShop.Repository.IRepository;
using Models;
using Models.Models;
using System.Linq.Expressions;

namespace GameShop.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private ApplicationDbContext _db;
        public CartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cart cart)
        {
            _db.Carts.Update(cart);
        }

       
    }
}
