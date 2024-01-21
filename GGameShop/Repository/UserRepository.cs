using DataAccess;
using GameShop.Repository.IRepository;
using GGameShop.Repository.IRepository;
using Models;
using Models.Models;

namespace GameShop.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
