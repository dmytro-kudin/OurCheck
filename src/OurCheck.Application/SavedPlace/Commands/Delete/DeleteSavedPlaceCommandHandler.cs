using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Application.Services.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Delete;

public class DeleteSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache) : IRequestHandler<DeleteSavedPlaceCommand>
{
    public async Task Handle(DeleteSavedPlaceCommand request, CancellationToken cancellationToken)
    {
        await savedPlaceRepository.DeleteAsync(request.Id);
        await cache.RemoveAsync(CacheKeys.SavedPlaces);
        await cache.RemoveAsync(string.Format(CacheKeys.SavedPlaceId, request.Id));
    }
}