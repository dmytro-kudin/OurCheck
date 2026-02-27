using MediatR;
using OurCheck.API.Features.SavedPlace.Dtos;

namespace OurCheck.API.Features.SavedPlace.Queries.Get;

public record GetSavedPlaceQuery(Guid Id) : IRequest<SavedPlaceDto?>;