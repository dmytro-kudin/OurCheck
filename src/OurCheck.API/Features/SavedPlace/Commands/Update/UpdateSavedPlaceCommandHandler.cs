using MediatR;
using OurCheck.API.Persistence;

namespace OurCheck.API.Features.SavedPlace.Commands.Update;

public class UpdateSavedPlaceCommandHandler(AppDbContext context) : IRequestHandler<UpdateSavedPlaceCommand>
{
    public async Task Handle(UpdateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = await context.SavedPlaces.FindAsync(command.Id);
        if (savedPlace is null)
            throw new ArgumentNullException($"Invalid SavedPlace Id.");
        savedPlace.Name = command.Name;
        savedPlace.Url = command.Url;
        await context.SaveChangesAsync(cancellationToken);
    }
}