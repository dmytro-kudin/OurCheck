using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.SavedPlace.Dtos;
using OurCheck.Application.Services.Cache;
using OurCheck.Application.Services.Repositories;

namespace OurCheck.Application.SavedPlace.Queries.List;

public class ListSavedPlacesQueryHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache) : IRequestHandler<ListSavedPlacesQuery, List<SavedPlaceDto>>
{
    public async Task<List<SavedPlaceDto>> Handle(ListSavedPlacesQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = CacheKeys.Appointments;
        if (!await cache.TryGetValueAsync(cacheKey, out List<SavedPlaceDto>? savedPlaceDtos))
        {
            savedPlaceDtos = (await savedPlaceRepository.GetAllAsync())
            .Select(savedPlace => new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url))
            .ToList();
            
            await cache.SetListAsync(cacheKey, savedPlaceDtos);
        }

        return savedPlaceDtos!;
    }
}