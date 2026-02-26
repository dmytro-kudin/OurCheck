using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.Features.Appointment.Dtos;
using OurCheck.Persistence;
using OurCheck.Persistence.Configurations;
using OurCheck.Persistence.QueryFilters;

namespace OurCheck.Features.Appointment.Queries.Get;

public class GetAppointmentQueryHandler(AppDbContext context)
    : IRequestHandler<GetAppointmentQuery, AppointmentDto?>
{
    public async Task<AppointmentDto?> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments
            .IgnoreQueryFilters([nameof(AppointmentQueryFilter.FutureOnly)])
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (appointment is null) return null;
        return new AppointmentDto(
            appointment.Id,
            appointment.Note,
            appointment.AppointmentTime,
            appointment.SavedPlace?.Name,
            appointment.SavedPlace?.Url);
    }
}