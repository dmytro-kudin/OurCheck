using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.SavedPlace.Dtos;
using OurCheck.Application.Services.Cache;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.SavedPlace.Queries.Get;

public class GetSavedPlaceQueryHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache)
    : IRequestHandler<GetSavedPlaceQuery, SavedPlaceDto?>
{
    public async Task<SavedPlaceDto?> Handle(GetSavedPlaceQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(CacheKeys.SavedPlaceId, request.Id);
        if (!await cache.TryGetValueAsync(cacheKey, out SavedPlaceDto? savedPlaceDto))
        {
            var savedPlace = await savedPlaceRepository
                .GetByIdAsync(request.Id);
            if (savedPlace is null) return null;

            savedPlaceDto = new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url);
            
            await cache.SetSingleAsync(cacheKey, savedPlaceDto);
        }
        
        return savedPlaceDto;
    }
}