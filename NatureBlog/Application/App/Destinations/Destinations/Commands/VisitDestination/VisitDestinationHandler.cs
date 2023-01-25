using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.User;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination
{
    public class VisitDestinationHandler : IRequestHandler<VisitDestinationCommand, List<UserGetDto>>
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public VisitDestinationHandler(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }

        public async Task<List<UserGetDto>> Handle(VisitDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _unitOfwork.DestinationRepository.GetDestination(command.DestinationId);
                User user = _unitOfwork.UserRepository.GetUser(command.UserId);

                _unitOfwork.DestinationRepository.VisitDestination(user, destination);
                await _unitOfwork.Save();
                var result = _unitOfwork.DestinationRepository.GetVisitorsCount(command.DestinationId);
                var mappedResult = _mapper.Map<List<UserGetDto>>(result);
                return mappedResult;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Visit Destination Method", ex);
                return null;
            }
        }
    }
}
