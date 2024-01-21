using DataAccess;
using GGameShop.Repository.IRepository;
using GGameShop.Repository;
using GameShop.Repository.IRepository;

namespace GameShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IGameCategoryRepository GameCategoryRepository { get; private set; }
        public IGameRepository GameRepository { get; private set; }



        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            GameCategoryRepository = new GameCategoryRepository(_db);
            GameRepository = new GameRepository(_db);

        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
