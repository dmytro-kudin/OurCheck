using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.SavedPlace.Dtos;
using OurCheck.Application.Services.Cache;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.SavedPlace.Queries.List;

public class ListSavedPlacesQueryHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache) : IRequestHandler<ListSavedPlacesQuery, List<SavedPlaceDto>>
{
    public async Task<List<SavedPlaceDto>> Handle(ListSavedPlacesQuery request, CancellationToken cancellationToken)
    {
        return await cache.GetOrCreateAsync(
                   CacheKeys.SavedPlaces,
                   async cancel =>
                   {
                       return (await savedPlaceRepository.GetAllAsync())
                           .Select(savedPlace => new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url))
                           .ToList();
                   },
                   tags: [CacheKeys.SavedPlaces],
                   cancellationToken)
               ?? [];
    }
}