using MediatR;
using OurCheck.Dto.Appointment;

namespace OurCheck.Client.Application.Features.Appointment.Queries.List;

public record ListAppointmentsQuery : IRequest<IEnumerable<AppointmentDto>>;