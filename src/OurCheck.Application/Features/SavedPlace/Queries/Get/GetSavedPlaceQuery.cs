using MediatR;
using OurCheck.Dto.SavedPlace;

namespace OurCheck.Application.Features.SavedPlace.Queries.Get;

public record GetSavedPlaceQuery(Guid Id) : IRequest<SavedPlaceDto?>;