using GGameShop.Repository.IRepository;

namespace GameShop.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGameCategoryRepository GameCategoryRepository { get; }
        IGameRepository GameRepository { get; }
        void Save();
    }
}
