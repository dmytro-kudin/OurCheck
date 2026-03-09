using MediatR;

namespace OurCheck.Application.Features.SavedPlace.Commands.Delete;

public record DeleteSavedPlaceCommand(Guid Id) : IRequest;