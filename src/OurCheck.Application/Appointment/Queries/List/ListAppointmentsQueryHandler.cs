using MediatR;
using OurCheck.Application.Appointment.Dtos;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Application.Services.Repositories;

namespace OurCheck.Application.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(
    IAppointmentRepository appointmentRepository,
    ICache cache) : IRequestHandler<ListAppointmentsQuery, List<AppointmentDto>>
{
    public async Task<List<AppointmentDto>> Handle(ListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = CacheKeys.Appointments;
        if (!await cache.TryGetValueAsync(cacheKey, out List<AppointmentDto>? appointmentDtos))
        {
            appointmentDtos = (await appointmentRepository.GetAllAsync())
                .Select(appointment => new AppointmentDto(
                    appointment.Id,
                    appointment.Note,
                    appointment.AppointmentTime,
                    appointment.SavedPlace?.Name,
                    appointment.SavedPlace?.Url))
                .ToList();
            
            await cache.SetListAsync(cacheKey, appointmentDtos);
        }

        return appointmentDtos!;
    }
}