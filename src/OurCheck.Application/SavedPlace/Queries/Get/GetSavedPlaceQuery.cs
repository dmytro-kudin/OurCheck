using MediatR;
using OurCheck.Dto.SavedPlace;

namespace OurCheck.Application.SavedPlace.Queries.Get;

public record GetSavedPlaceQuery(Guid Id) : IRequest<SavedPlaceDto?>;