using MediatR;
using OurCheck.Application.Appointment.Notifications;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    IMediator mediatr) : IRequestHandler<CreateSavedPlaceCommand, Guid>
{
    public async Task<Guid> Handle(CreateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = new Domain.Entities.SavedPlace(command.Name, command.Url);
        await savedPlaceRepository.AddAsync(savedPlace);
        await mediatr.Publish(new AppointmentUpdatedNotification(), cancellationToken);
        
        return savedPlace.Id;
    }
}