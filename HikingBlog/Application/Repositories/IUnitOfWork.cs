namespace NatureBlog.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public ICommentRepository CommentRepository { get; }

        public IDestinationRepository DestinationRepository { get; }

        public IRegionRepository RegionRepository { get; }

        public IUserRepository UserRepository { get; }

        Task Save();
    }
}
