using MediatR;
using OurCheck.API.Persistence;

namespace OurCheck.API.Features.Appointment.Commands.Create;

public class CreateAppointmentCommandHandler(AppDbContext context) : IRequestHandler<CreateAppointmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        if (command.SavedPlaceId != null)
        {
            var savedPlace = await context.SavedPlaces.FindAsync(command.SavedPlaceId);
            if (savedPlace is null)
                throw new ArgumentNullException($"Invalid SavedPlace Id.");
        }
        
        var appointment = new Persistence.Domain.Appointment(command.Note, command.AppointmentTime, command.SavedPlaceId);
        await context.Appointments.AddAsync(appointment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return appointment.Id;
    }
}