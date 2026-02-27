using MediatR;
using OurCheck.Application.SavedPlace.Dtos;

namespace OurCheck.Application.SavedPlace.Queries.Get;

public record GetSavedPlaceQuery(Guid Id) : IRequest<SavedPlaceDto?>;