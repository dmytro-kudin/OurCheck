using MediatR;

namespace OurCheck.Application.SavedPlace.Commands.Update;

public record UpdateSavedPlaceCommand(Guid Id, string Name, string? Url) : IRequest;