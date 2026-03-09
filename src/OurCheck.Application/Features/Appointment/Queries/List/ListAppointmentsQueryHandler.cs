using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;
using OurCheck.Dto.Appointment;
using OurCheck.Persistence.Abstract.Repositories;

namespace OurCheck.Application.Features.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(
    IAppointmentRepository appointmentRepository,
    ICache cache) : IRequestHandler<ListAppointmentsQuery, List<AppointmentDto>>
{
    public async Task<List<AppointmentDto>> Handle(ListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return await cache.GetOrCreateAsync(
            CacheKeys.Appointments,
            async cancel =>
            {
                return (await appointmentRepository.GetAllAsync())
                    .Select(appointment => new AppointmentDto(
                        appointment.Id,
                        appointment.Note,
                        appointment.AppointmentTime,
                        appointment.SavedPlace?.Name,
                        appointment.SavedPlace?.Url))
                    .ToList();
            },
            tags: [CacheKeys.Appointments],
            cancellationToken)
            ?? [];
    }
}