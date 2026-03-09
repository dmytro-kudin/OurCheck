using MediatR;
using OurCheck.Application.Features.SavedPlace.Notifications;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Features.SavedPlace.Commands.Update;

public class UpdateSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    IMediator mediatr) : IRequestHandler<UpdateSavedPlaceCommand>
{
    public async Task Handle(UpdateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = await savedPlaceRepository.GetByIdAsync(command.Id);
        if (savedPlace is null)
            throw new ArgumentNullException($"Invalid SavedPlace Id.");
        savedPlace.Name = command.Name;
        savedPlace.Url = command.Url;
        await savedPlaceRepository.UpdateAsync(savedPlace);
        await mediatr.Publish(new SavedPlaceUpdatedNotification(command.Id), cancellationToken);
    }
}