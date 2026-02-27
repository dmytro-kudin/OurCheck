using MediatR;
using OurCheck.Application.Appointment.Dtos;
using OurCheck.Application.Repositories;

namespace OurCheck.Application.Appointment.Queries.Get;

public class GetAppointmentQueryHandler(IAppointmentRepository appointmentRepository)
    : IRequestHandler<GetAppointmentQuery, AppointmentDto?>
{
    public async Task<AppointmentDto?> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointment = await appointmentRepository.GetByIdAsync(request.Id);
        if (appointment is null) return null;
        return new AppointmentDto(
            appointment.Id,
            appointment.Note,
            appointment.AppointmentTime,
            appointment.SavedPlace?.Name,
            appointment.SavedPlace?.Url);
    }
}