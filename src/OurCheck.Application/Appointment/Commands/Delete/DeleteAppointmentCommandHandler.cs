using MediatR;
using OurCheck.Application.Common.Interfaces;

namespace OurCheck.Application.Appointment.Commands.Delete;

public class DeleteAppointmentCommandHandler(IAppDbContext context) : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments.FindAsync(request.Id);
        if (appointment is null) return;
        context.Appointments.Remove(appointment);
        await context.SaveChangesAsync(cancellationToken);
    }
}