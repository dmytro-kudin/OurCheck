using MediatR;
using OurCheck.Persistence;

namespace OurCheck.Features.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandHandler(AppDbContext context) : IRequestHandler<CreateSavedPlaceCommand, Guid>
{
    public async Task<Guid> Handle(CreateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = new Persistence.Domain.SavedPlace(command.Name, command.Url);
        await context.SavedPlaces.AddAsync(savedPlace, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return savedPlace.Id;
    }
}