using MediatR;
using OurCheck.Application.Appointment.Dtos;

namespace OurCheck.Application.Appointment.Queries.List;

public record ListAppointmentsQuery : IRequest<List<AppointmentDto>>;