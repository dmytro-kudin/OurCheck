using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.Application.Common.Interfaces;
using OurCheck.Application.SavedPlace.Dtos;

namespace OurCheck.Application.SavedPlace.Queries.List;

public class ListSavedPlacesQueryHandler(IAppDbContext context) : IRequestHandler<ListSavedPlacesQuery, List<SavedPlaceDto>>
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