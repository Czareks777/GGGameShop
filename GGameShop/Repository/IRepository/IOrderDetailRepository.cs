using Models;

namespace GGameShop.Repository.IRepository
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
        void Update(OrderDetail orderDetail);
    }
}
