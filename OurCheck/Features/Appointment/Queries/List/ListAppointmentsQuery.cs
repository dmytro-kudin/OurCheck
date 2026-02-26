using MediatR;
using OurCheck.Features.Appointment.Dtos;

namespace OurCheck.Features.Appointment.Queries.List;

public record ListAppointmentsQuery : IRequest<List<AppointmentDto>>;