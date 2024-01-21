using GGameShop.Repository.IRepository;
using Models.Models;

namespace GameShop.Repository.IRepository
{
    public interface IGameRepository : IRepository<Game>
    {
        void Update(Game game);
    }
}
