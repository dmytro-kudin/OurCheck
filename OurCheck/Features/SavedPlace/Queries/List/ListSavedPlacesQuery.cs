using MediatR;
using OurCheck.Features.SavedPlace.Dtos;

namespace OurCheck.Features.SavedPlace.Queries.List;

public record ListSavedPlacesQuery : IRequest<List<SavedPlaceDto>>;