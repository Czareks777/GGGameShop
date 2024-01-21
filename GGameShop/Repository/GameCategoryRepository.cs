using DataAccess;
using GameShop.Repository.IRepository;
using GGameShop.Repository.IRepository;
using Models.Models;

namespace GameShop.Repository
{
    public class GameCategoryRepository : Repository<GameCategory>, IGameCategoryRepository
    {
        private ApplicationDbContext _db;
        public GameCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GameCategory gameCategory)
        {
            _db.GameCategories.Update(gameCategory);
        }
    }
}
