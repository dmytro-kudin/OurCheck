using MediatR;
using OurCheck.Client.Repository.Abstract.Repositories;
using OurCheck.Dto.Appointment;

namespace OurCheck.Client.Application.Features.Appointment.Queries.List;

public class ListAppointmentsQueryHandler(
    IAppointmentRepository appointmentRepository) : IRequestHandler<ListAppointmentsQuery, IEnumerable<AppointmentDto>>
{
    public Task<IEnumerable<AppointmentDto>> Handle(ListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return appointmentRepository.GetAllAsync();
    }
}