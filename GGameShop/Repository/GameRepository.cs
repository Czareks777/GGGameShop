using DataAccess;
using GameShop.Repository.IRepository;
using GGameShop.Repository.IRepository;
using Models.Models;

namespace GameShop.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private ApplicationDbContext _db;
        public GameRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Game game)
        {
            var gameFromDb = _db.Games.FirstOrDefault(u => u.Id == game.Id);
            if (gameFromDb != null)
            {

                game.GameCategoryId = gameFromDb.GameCategoryId;
                game.DevStudio = gameFromDb.DevStudio;
                game.Title = gameFromDb.Title;
                game.Description = gameFromDb.Description;
                game.PricePS = gameFromDb.PricePS;
                game.PriceSteam = gameFromDb.PriceSteam;
                game.PriceXbox = gameFromDb.PriceXbox;
                if (game.ImageUrl != null)
                {
                    gameFromDb.ImageUrl = game.ImageUrl;
                }
            }
        }
    }
}
