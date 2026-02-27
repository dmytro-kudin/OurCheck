using MediatR;
using OurCheck.Application.Repositories;
using OurCheck.Application.SavedPlace.Dtos;

namespace OurCheck.Application.SavedPlace.Queries.List;

public class ListSavedPlacesQueryHandler(ISavedPlaceRepository savedPlaceRepository) : IRequestHandler<ListSavedPlacesQuery, List<SavedPlaceDto>>
{
    public async Task<List<SavedPlaceDto>> Handle(ListSavedPlacesQuery request, CancellationToken cancellationToken)
    {
        return (await savedPlaceRepository.GetAllAsync())
            .Select(savedPlace => new SavedPlaceDto(savedPlace.Id, savedPlace.Name, savedPlace.Url))
            .ToList();
    }
}