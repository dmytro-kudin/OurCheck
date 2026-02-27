using MediatR;
using OurCheck.API.Features.SavedPlace.Dtos;

namespace OurCheck.API.Features.SavedPlace.Queries.List;

public record ListSavedPlacesQuery : IRequest<List<SavedPlaceDto>>;