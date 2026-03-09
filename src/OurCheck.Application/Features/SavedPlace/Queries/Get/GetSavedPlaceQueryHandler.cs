using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Dto.SavedPlace;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Features.SavedPlace.Queries.Get;

public class GetSavedPlaceQueryHandler(
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache)
    : IRequestHandler<GetSavedPlaceQuery, SavedPlaceDto?>
{
    public async Task<SavedPlaceDto?> Handle(GetSavedPlaceQuery request, CancellationToken cancellationToken)
    {
        return await cache.GetOrCreateAsync(
            string.Format(CacheKeys.SavedPlaceId, request.Id),
            async cancel =>
            {
                var savedPlace = await savedPlaceRepository
                    .GetByIdAsync(request.Id);
                if (savedPlace is null) return null;

                return new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url);
            },
            tags: [CacheKeys.SavedPlaces],
            cancellationToken);
    }
}