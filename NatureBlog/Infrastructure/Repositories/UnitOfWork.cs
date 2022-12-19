using NatureBlog.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _appDBContext;

        public UnitOfWork(AppDBContext appDBContext, ICommentRepository commentRepository, IDestinationRepository destinationRepository, IRegionRepository regionRepository, IUserRepository userRepository)
        {
            _appDBContext = appDBContext;
            CommentRepository = commentRepository;
            DestinationRepository = destinationRepository;
            RegionRepository = regionRepository;
            UserRepository = userRepository;
        }

        public ICommentRepository CommentRepository { get; private set; }

        public IDestinationRepository DestinationRepository { get; private set; }

        public IRegionRepository RegionRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public async Task Save()
        {
            await _appDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDBContext.Dispose();
        }
    }
}
