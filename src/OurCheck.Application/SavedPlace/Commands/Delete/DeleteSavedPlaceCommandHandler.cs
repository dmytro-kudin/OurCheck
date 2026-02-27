using MediatR;
using OurCheck.Application.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Delete;

public class DeleteSavedPlaceCommandHandler(ISavedPlaceRepository savedPlaceRepository) : IRequestHandler<DeleteSavedPlaceCommand>
{
    public async Task Handle(DeleteSavedPlaceCommand request, CancellationToken cancellationToken)
    {
        await savedPlaceRepository.DeleteAsync(request.Id);
    }
}