
using GGameShop.Repository.IRepository;
using Models;
using Models.Models;

namespace GameShop.Repository.IRepository
{
    public interface ICartRepository : IRepository<Models.Cart>
    {
        void Update(Cart cart);
    }
}
