using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.Application.Appointment.Dtos;
using OurCheck.Application.Common.Interfaces;

namespace OurCheck.Application.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(IAppDbContext context) : IRequestHandler<ListAppointmentsQuery, List<AppointmentDto>>
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