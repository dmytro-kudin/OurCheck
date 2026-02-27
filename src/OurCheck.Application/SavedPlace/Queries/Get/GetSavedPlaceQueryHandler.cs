using MediatR;
using OurCheck.Application.Common.Interfaces;
using OurCheck.Application.SavedPlace.Dtos;

namespace OurCheck.Application.SavedPlace.Queries.Get;

public class GetSavedPlaceQueryHandler(IAppDbContext context)
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