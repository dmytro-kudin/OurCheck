using MediatR;
using OurCheck.Persistence;

namespace OurCheck.Features.Appointment.Commands.Create;

public class CreateAppointmentCommandHandler(AppDbContext context) : IRequestHandler<CreateAppointmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var product = new Domain.Appointment(command.Note, command.AppointmentTime);
        await context.Appointments.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}