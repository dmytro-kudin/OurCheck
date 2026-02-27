using MediatR;

namespace OurCheck.API.Features.SavedPlace.Commands.Create;

public record CreateSavedPlaceCommand(string Name, string? Url) : IRequest<Guid>;