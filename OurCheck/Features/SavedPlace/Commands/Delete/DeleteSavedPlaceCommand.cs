using MediatR;

namespace OurCheck.Features.SavedPlace.Commands.Delete;

public record DeleteSavedPlaceCommand(Guid Id) : IRequest;