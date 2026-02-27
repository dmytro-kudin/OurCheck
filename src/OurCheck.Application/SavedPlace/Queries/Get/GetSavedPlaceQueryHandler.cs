using MediatR;
using OurCheck.Application.Repositories;
using OurCheck.Application.SavedPlace.Dtos;

namespace OurCheck.Application.SavedPlace.Queries.Get;

public class GetSavedPlaceQueryHandler(ISavedPlaceRepository savedPlaceRepository)
    : IRequestHandler<GetSavedPlaceQuery, SavedPlaceDto?>
{
    public async Task<SavedPlaceDto?> Handle(GetSavedPlaceQuery request, CancellationToken cancellationToken)
    {
        var savedPlace = await savedPlaceRepository
            .GetByIdAsync(request.Id);
        if (savedPlace is null) return null;
        return new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url);
    }
}