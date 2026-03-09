using MediatR;
using OurCheck.Application.Features.Appointment.Notifications;
using OurCheck.Dto.Common;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Features.Appointment.Commands.Create;

public class CreateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    ISavedPlaceRepository savedPlaceRepository,
    IMediator mediatr) : IRequestHandler<CreateAppointmentCommand, CreatedDto>
{
    public async Task<CreatedDto> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        if (command.SavedPlaceId != null)
        {
            var savedPlace = await savedPlaceRepository.GetByIdAsync(command.SavedPlaceId.Value);
            if (savedPlace is null)
                throw new ArgumentNullException($"Invalid SavedPlace Id.");
        }
        
        var appointment = new Domain.Entities.Appointment(command.Note, command.AppointmentTime, command.SavedPlaceId);
        await appointmentRepository.AddAsync(appointment);
        await mediatr.Publish(new AppointmentUpdatedNotification(), cancellationToken);

        return new CreatedDto (appointment.Id);
    }
}