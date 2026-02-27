using MediatR;

namespace OurCheck.Application.SavedPlace.Commands.Create;

public record CreateSavedPlaceCommand(string Name, string? Url) : IRequest<Guid>;