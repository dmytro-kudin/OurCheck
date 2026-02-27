using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.Application.Appointment.Dtos;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Common.Interfaces;

namespace OurCheck.Application.Appointment.Queries.Get;

public class GetAppointmentQueryHandler(IAppDbContext context)
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