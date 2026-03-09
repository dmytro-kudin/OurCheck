using MediatR;
using OurCheck.Dto.Common;

namespace OurCheck.Application.Features.SavedPlace.Commands.Create;

public record CreateSavedPlaceCommand(string Name, string? Url) : IRequest<CreatedDto>;