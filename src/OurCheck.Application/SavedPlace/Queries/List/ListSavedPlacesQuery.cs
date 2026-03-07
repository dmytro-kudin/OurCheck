using MediatR;
using OurCheck.Dto.SavedPlace;

namespace OurCheck.Application.SavedPlace.Queries.List;

public record ListSavedPlacesQuery : IRequest<List<SavedPlaceDto>>;