using GGameShop.Repository.IRepository;

namespace GameShop.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGameCategoryRepository GameCategoryRepository { get; }
        IGameRepository GameRepository { get; }
        ICartRepository CartRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderHeaderRepository  OrderHeaderRepository { get; }
        void Save();
    }
}
