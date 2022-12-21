using MediatR;
using NatureBlog.Application.Repositories;

namespace NatureBlog.Application.App.Regions.DeleteRegion
{
    public class DeleteRegionHandler : IRequestHandler<DeleteRegionCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRegionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool?> Handle(DeleteRegionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                bool result = _unitOfWork.RegionRepository.Delete(command.Id);
                if (result == false)
                    return null;

                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteRegion method", ex.Message);
                return false;
            }
        }
    }
}
