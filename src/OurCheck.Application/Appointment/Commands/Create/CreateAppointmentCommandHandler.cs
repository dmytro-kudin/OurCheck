using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Appointment.Commands.Create;

public class CreateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    ISavedPlaceRepository savedPlaceRepository,
    ICache cache) : IRequestHandler<CreateAppointmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        if (command.SavedPlaceId != null)
        {
            var savedPlace = await savedPlaceRepository.GetByIdAsync(command.SavedPlaceId.Value);
            if (savedPlace is null)
                throw new ArgumentNullException($"Invalid SavedPlace Id.");
        }
        
        var appointment = new Domain.Entities.Appointment(command.Note, command.AppointmentTime, command.SavedPlaceId);
        await appointmentRepository.AddAsync(appointment);
        await cache.RemoveAsync(CacheKeys.Appointments);
        
        return appointment.Id;
    }
}