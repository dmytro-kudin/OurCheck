using MediatR;

namespace OurCheck.Features.SavedPlace.Commands.Create;

public record CreateSavedPlaceCommand(string Name, string? Url) : IRequest<Guid>;