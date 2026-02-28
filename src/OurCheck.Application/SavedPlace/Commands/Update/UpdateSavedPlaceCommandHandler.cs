using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Update;

public class UpdateSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache) : IRequestHandler<UpdateSavedPlaceCommand>
{
    public async Task Handle(UpdateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = await savedPlaceRepository.GetByIdAsync(command.Id);
        if (savedPlace is null)
            throw new ArgumentNullException($"Invalid SavedPlace Id.");
        savedPlace.Name = command.Name;
        savedPlace.Url = command.Url;
        await savedPlaceRepository.UpdateAsync(savedPlace);
        await cache.RemoveAsync(CacheKeys.SavedPlaces);
        await cache.RemoveAsync(string.Format(CacheKeys.SavedPlaceId, command.Id));
    }
}