using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.API.Features.Appointment.Dtos;
using OurCheck.API.Persistence;

namespace OurCheck.API.Features.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(AppDbContext context) : IRequestHandler<ListAppointmentsQuery, List<AppointmentDto>>
{
    public async Task<List<AppointmentDto>> Handle(ListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return await context.Appointments
            .AsNoTracking()
            .OrderBy(x => x.AppointmentTime)
            .Select(appointment => new AppointmentDto(
                appointment.Id,
                appointment.Note,
                appointment.AppointmentTime,
                appointment.SavedPlace != null ? appointment.SavedPlace.Name : null,
                appointment.SavedPlace != null ? appointment.SavedPlace.Url : null))
            .ToListAsync(cancellationToken);
    }
}