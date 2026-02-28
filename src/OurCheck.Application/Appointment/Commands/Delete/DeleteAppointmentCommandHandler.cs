using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Application.Services.Repositories;

namespace OurCheck.Application.Appointment.Commands.Delete;

public class DeleteAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    ICache cache) : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        await appointmentRepository.DeleteAsync(request.Id);
        await cache.RemoveAsync(CacheKeys.Appointments);
        await cache.RemoveAsync(string.Format(CacheKeys.AppointmentId, request.Id));
    }
}