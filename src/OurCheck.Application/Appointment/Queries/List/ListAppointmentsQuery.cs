using MediatR;
using OurCheck.Dto.Appointment;

namespace OurCheck.Application.Appointment.Queries.List;

public record ListAppointmentsQuery : IRequest<List<AppointmentDto>>;