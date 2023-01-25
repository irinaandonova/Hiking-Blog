using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.User;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Users.Queries
{
    internal class GetUserHandler : IRequestHandler<GetUserQuery, UserGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UserGetDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            try
            {
                User? user = _unitOfWork.UserRepository.GetUser(query.Email);
                var mappedResult = _mapper.Map<UserGetDto>(user);

                return Task.FromResult(mappedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }
    }
}
