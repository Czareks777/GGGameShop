using DataAccess;
using GameShop.Repository.IRepository;
using GGameShop.Repository.IRepository;
using Models;
using Models.Models;

namespace GameShop.Repository
{
    public class OrderheaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderheaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderDb.PaymentIntentId = paymentIntentId;
                orderDb.PaymentDate = DateTime.Now;
            }
        }
    }
}