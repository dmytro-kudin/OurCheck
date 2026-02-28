using MediatR;
using OurCheck.Application.Appointment.Dtos;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Application.Services.Repositories;

namespace OurCheck.Application.Appointment.Queries.Get;

public class GetAppointmentQueryHandler(
    IAppointmentRepository appointmentRepository,
    ICache cache)
    : IRequestHandler<GetAppointmentQuery, AppointmentDto?>
{
    public async Task<AppointmentDto?> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(CacheKeys.AppointmentId, request.Id);
        if (!await cache.TryGetValueAsync(cacheKey, out AppointmentDto? appointmentDto))
        {
            var appointment = await appointmentRepository.GetByIdAsync(request.Id);
            if (appointment is null) return null;
            
            appointmentDto = new AppointmentDto(
                appointment.Id,
                appointment.Note,
                appointment.AppointmentTime,
                appointment.SavedPlace?.Name,
                appointment.SavedPlace?.Url);
            
            await cache.SetSingleAsync(cacheKey, appointmentDto);
        }

        return appointmentDto;
    }
}