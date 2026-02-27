using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.API.Features.Appointment.Dtos;
using OurCheck.API.Persistence;
using OurCheck.API.Persistence.Configurations;
using OurCheck.API.Persistence.Constants;

namespace OurCheck.API.Features.Appointment.Queries.Get;

public class GetAppointmentQueryHandler(AppDbContext context)
    : IRequestHandler<GetAppointmentQuery, AppointmentDto?>
{
    public async Task<AppointmentDto?> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments
            .IgnoreQueryFilters([AppointmentQueryFilters.FutureOnly])
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