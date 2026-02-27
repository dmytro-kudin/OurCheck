using MediatR;
using OurCheck.Application.Common.Interfaces;

namespace OurCheck.Application.SavedPlace.Commands.Delete;

public class DeleteSavedPlaceCommandHandler(IAppDbContext context) : IRequestHandler<DeleteSavedPlaceCommand>
{
    public async Task Handle(DeleteSavedPlaceCommand request, CancellationToken cancellationToken)
    {
        var savedPlace = await context.SavedPlaces.FindAsync(request.Id);
        if (savedPlace is null) return;
        context.SavedPlaces.Remove(savedPlace);
        await context.SaveChangesAsync(cancellationToken);
    }
}