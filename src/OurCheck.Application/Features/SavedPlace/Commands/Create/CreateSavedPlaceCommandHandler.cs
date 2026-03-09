using MediatR;
using OurCheck.Application.Features.Appointment.Notifications;
using OurCheck.Dto.Common;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Features.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandHandler(
    ISavedPlaceRepository savedPlaceRepository,
    IMediator mediatr) : IRequestHandler<CreateSavedPlaceCommand, CreatedDto>
{
    public async Task<CreatedDto> Handle(CreateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = new Domain.Entities.SavedPlace(command.Name, command.Url);
        await savedPlaceRepository.AddAsync(savedPlace);
        await mediatr.Publish(new AppointmentUpdatedNotification(), cancellationToken);
        
        return new CreatedDto(savedPlace.Id);
    }
}