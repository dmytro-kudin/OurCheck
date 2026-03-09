using MediatR;
using OurCheck.Dto.Appointment;

namespace OurCheck.Application.Features.Appointment.Queries.List;

public record ListAppointmentsQuery : IRequest<List<AppointmentDto>>;