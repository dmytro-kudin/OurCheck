using MediatR;
using OurCheck.Application.Appointment.Dtos;
using OurCheck.Application.Repositories;

namespace OurCheck.Application.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(IAppointmentRepository appointmentRepository) : IRequestHandler<ListAppointmentsQuery, List<AppointmentDto>>
{
    public async Task<List<AppointmentDto>> Handle(ListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return (await appointmentRepository.GetAllAsync())
            .Select(appointment => new AppointmentDto(
                appointment.Id,
                appointment.Note,
                appointment.AppointmentTime,
                appointment.SavedPlace?.Name,
                appointment.SavedPlace?.Url))
            .ToList();
    }
}