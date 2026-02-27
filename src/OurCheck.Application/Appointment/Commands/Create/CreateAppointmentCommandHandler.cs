using MediatR;
using OurCheck.Application.Common.Interfaces;

namespace OurCheck.Application.Appointment.Commands.Create;

public class CreateAppointmentCommandHandler(IAppDbContext context) : IRequestHandler<CreateAppointmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        if (command.SavedPlaceId != null)
        {
            var savedPlace = await context.SavedPlaces.FindAsync(command.SavedPlaceId);
            if (savedPlace is null)
                throw new ArgumentNullException($"Invalid SavedPlace Id.");
        }
        
        var appointment = new Domain.Entities.Appointment(command.Note, command.AppointmentTime, command.SavedPlaceId);
        await context.Appointments.AddAsync(appointment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return appointment.Id;
    }
}