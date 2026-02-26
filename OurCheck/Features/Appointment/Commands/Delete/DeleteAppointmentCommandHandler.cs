using MediatR;
using OurCheck.Persistence;

namespace OurCheck.Features.Appointment.Commands.Delete;

public class DeleteAppointmentCommandHandler(AppDbContext context) : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Appointments.FindAsync(request.Id, cancellationToken);
        if (product is null) return;
        context.Appointments.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}