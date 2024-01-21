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
        public ICartRepository CartRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IOrderHeaderRepository OrderHeaderRepository { get; private set; }
        public IOrderDetailRepository   OrderDetailRepository { get; private set; } 

        

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CartRepository = new CartRepository(_db);
            GameCategoryRepository = new GameCategoryRepository(_db);
            GameRepository = new GameRepository(_db);
            UserRepository = new UserRepository(_db);
            OrderDetailRepository = new OrderDetailRepository(_db);
            OrderHeaderRepository = new OrderheaderRepository(_db);

        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
