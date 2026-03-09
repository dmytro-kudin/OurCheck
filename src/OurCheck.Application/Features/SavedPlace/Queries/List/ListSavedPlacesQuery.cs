using MediatR;
using OurCheck.Dto.SavedPlace;

namespace OurCheck.Application.Features.SavedPlace.Queries.List;

public record ListSavedPlacesQuery : IRequest<List<SavedPlaceDto>>;