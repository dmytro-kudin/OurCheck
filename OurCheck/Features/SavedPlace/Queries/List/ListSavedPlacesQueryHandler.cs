using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.Features.SavedPlace.Dtos;
using OurCheck.Persistence;

namespace OurCheck.Features.SavedPlace.Queries.List;

public class ListSavedPlacesQueryHandler(AppDbContext context) : IRequestHandler<ListSavedPlacesQuery, List<SavedPlaceDto>>
{
    public async Task<List<SavedPlaceDto>> Handle(ListSavedPlacesQuery request, CancellationToken cancellationToken)
    {
        return await context.SavedPlaces
            .AsNoTracking()
            .OrderByDescending(x => x.Created)
            .Select(savedPlace => new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url))
            .ToListAsync(cancellationToken);
    }
}