using MediatR;
using OurCheck.Persistence;

namespace OurCheck.Features.Appointment.Commands.Create;

public class CreateAppointmentCommandHandler(AppDbContext context) : IRequestHandler<CreateAppointmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = new Persistence.Domain.Appointment(command.Note, command.AppointmentTime);
        await context.Appointments.AddAsync(appointment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return appointment.Id;
    }
}