using MediatR;

namespace OurCheck.API.Features.SavedPlace.Commands.Delete;

public record DeleteSavedPlaceCommand(Guid Id) : IRequest;