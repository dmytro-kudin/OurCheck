using MediatR;
using OurCheck.API.Persistence;

namespace OurCheck.API.Features.Appointment.Commands.Update;

public class UpdateAppointmentCommandHandler(AppDbContext context) : IRequestHandler<UpdateAppointmentCommand>
{
    public async Task Handle(UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments.FindAsync(command.Id);
        if (appointment is null)
            throw new ArgumentNullException($"Invalid Appointment Id.");
        appointment.Note = command.Note;
        appointment.AppointmentTime = command.AppointmentTime;

        if (command.SavedPlaceId != null)
        {
            var savedPlace = await context.SavedPlaces.FindAsync(command.SavedPlaceId);
            if (savedPlace is null)
                throw new ArgumentNullException($"Invalid SavedPlace Id.");
        }
        
        appointment.SavedPlaceId = command.SavedPlaceId;
        await context.SaveChangesAsync(cancellationToken);
    }
}