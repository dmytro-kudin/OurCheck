using MediatR;
using OurCheck.Application.Repositories;

namespace OurCheck.Application.Appointment.Commands.Update;

public class UpdateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    ISavedPlaceRepository savedPlaceRepository) : IRequestHandler<UpdateAppointmentCommand>
{
    public async Task Handle(UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await appointmentRepository.GetByIdAsync(command.Id);
        if (appointment is null)
            throw new ArgumentNullException($"Invalid Appointment Id.");
        appointment.Note = command.Note;
        appointment.AppointmentTime = command.AppointmentTime;

        if (command.SavedPlaceId != null)
        {
            var savedPlace = await savedPlaceRepository.GetByIdAsync(command.SavedPlaceId.Value);
            if (savedPlace is null)
                throw new ArgumentNullException($"Invalid SavedPlace Id.");
        }
        
        appointment.SavedPlaceId = command.SavedPlaceId;
        await appointmentRepository.UpdateAsync(appointment);
    }
}