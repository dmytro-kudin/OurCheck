using MediatR;
using OurCheck.Application.Features.Appointment.Notifications;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Features.Appointment.Commands.Delete;

public class DeleteAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IMediator mediatr) : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand command, CancellationToken cancellationToken)
    {
        await appointmentRepository.DeleteAsync(command.Id);
        await mediatr.Publish(new AppointmentUpdatedNotification(command.Id), cancellationToken);
    }
}