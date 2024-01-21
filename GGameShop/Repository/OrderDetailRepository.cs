using DataAccess;
using GameShop.Repository.IRepository;
using GGameShop.Repository.IRepository;
using Models;
using Models.Models;

namespace GameShop.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetail orderDetail)
        {
            _db.OrderDetails.Update(orderDetail);
        }
    }
}
