using MediatR;
using OurCheck.API.Features.SavedPlace.Dtos;
using OurCheck.API.Persistence;

namespace OurCheck.API.Features.SavedPlace.Queries.Get;

public class GetSavedPlaceQueryHandler(AppDbContext context)
    : IRequestHandler<GetSavedPlaceQuery, SavedPlaceDto?>
{
    public async Task<SavedPlaceDto?> Handle(GetSavedPlaceQuery request, CancellationToken cancellationToken)
    {
        var savedPlace = await context.SavedPlaces
            .FindAsync(request.Id);
        if (savedPlace is null) return null;
        return new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url);
    }
}