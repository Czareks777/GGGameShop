using GGameShop.Repository.IRepository;
using Models.Models;

namespace GameShop.Repository.IRepository
{
    public interface IGameCategoryRepository : IRepository<GameCategory>
    {
        void Update(GameCategory gameCategory);
    }
}
