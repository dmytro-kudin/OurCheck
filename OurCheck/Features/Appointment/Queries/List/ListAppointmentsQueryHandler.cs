using MediatR;
using Microsoft.EntityFrameworkCore;
using OurCheck.Features.Appointment.Dtos;
using OurCheck.Persistence;

namespace OurCheck.Features.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(AppDbContext context) : IRequestHandler<ListAppointmentsQuery, List<AppointmentDto>>
{
    public async Task<List<AppointmentDto>> Handle(ListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return await context.Appointments
            .AsNoTracking()
            .OrderBy(x => x.AppointmentTime)
            .Select(p => new AppointmentDto(p.Id, p.Note, p.AppointmentTime))
            .ToListAsync(cancellationToken);
    }
}