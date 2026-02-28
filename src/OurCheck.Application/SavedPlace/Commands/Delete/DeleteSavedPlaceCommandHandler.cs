using MediatR;
using OurCheck.Application.SavedPlace.Notifications;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Delete;

public class DeleteSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    IMediator mediatr) : IRequestHandler<DeleteSavedPlaceCommand>
{
    public async Task Handle(DeleteSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        await savedPlaceRepository.DeleteAsync(command.Id);
        await mediatr.Publish(new SavedPlaceUpdatedNotification(command.Id), cancellationToken);
    }
}