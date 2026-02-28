using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache) : IRequestHandler<CreateSavedPlaceCommand, Guid>
{
    public async Task<Guid> Handle(CreateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = new Domain.Entities.SavedPlace(command.Name, command.Url);
        await savedPlaceRepository.AddAsync(savedPlace);
        await cache.RemoveAsync(CacheKeys.SavedPlaces);
        
        return savedPlace.Id;
    }
}