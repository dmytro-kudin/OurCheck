using MediatR;
using OurCheck.Application.Common.Interfaces;

namespace OurCheck.Application.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandHandler(IAppDbContext context) : IRequestHandler<CreateSavedPlaceCommand, Guid>
{
    public async Task<Guid> Handle(CreateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = new Domain.Entities.SavedPlace(command.Name, command.Url);
        await context.SavedPlaces.AddAsync(savedPlace, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return savedPlace.Id;
    }
}