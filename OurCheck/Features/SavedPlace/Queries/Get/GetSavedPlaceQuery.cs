using MediatR;
using OurCheck.Features.SavedPlace.Dtos;

namespace OurCheck.Features.SavedPlace.Queries.Get;

public record GetSavedPlaceQuery(Guid Id) : IRequest<SavedPlaceDto?>;