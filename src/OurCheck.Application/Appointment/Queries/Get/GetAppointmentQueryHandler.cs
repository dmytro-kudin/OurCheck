using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Dto.Appointment;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Appointment.Queries.Get;

public class GetAppointmentQueryHandler(
    IAppointmentRepository appointmentRepository,
    ICache cache)
    : IRequestHandler<GetAppointmentQuery, AppointmentDto?>
{
    public async Task<AppointmentDto?> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        return await cache.GetOrCreateAsync(
            string.Format(CacheKeys.AppointmentId, request.Id),
            async cancel =>
            {
                var appointment = await appointmentRepository.GetByIdAsync(request.Id);
                if (appointment is null) return null;

                return new AppointmentDto(
                    appointment.Id,
                    appointment.Note,
                    appointment.AppointmentTime,
                    appointment.SavedPlace?.Name,
                    appointment.SavedPlace?.Url);
            },
            tags: [CacheKeys.Appointments],
            cancellationToken);
    }
}