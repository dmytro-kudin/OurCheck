using MediatR;
using OurCheck.Application.SavedPlace.Dtos;

namespace OurCheck.Application.SavedPlace.Queries.List;

public record ListSavedPlacesQuery : IRequest<List<SavedPlaceDto>>;