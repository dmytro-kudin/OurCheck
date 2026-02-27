using MediatR;

namespace OurCheck.API.Features.SavedPlace.Commands.Update;

public record UpdateSavedPlaceCommand(Guid Id, string Name, string? Url) : IRequest;