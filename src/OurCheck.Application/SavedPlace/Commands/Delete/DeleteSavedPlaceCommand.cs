using MediatR;

namespace OurCheck.Application.SavedPlace.Commands.Delete;

public record DeleteSavedPlaceCommand(Guid Id) : IRequest;