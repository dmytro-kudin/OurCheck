using MediatR;
using OurCheck.API.Persistence;

namespace OurCheck.API.Features.Appointment.Commands.Delete;

public class DeleteAppointmentCommandHandler(AppDbContext context) : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments.FindAsync(request.Id);
        if (appointment is null) return;
        context.Appointments.Remove(appointment);
        await context.SaveChangesAsync(cancellationToken);
    }
}