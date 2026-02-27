using MediatR;
using OurCheck.API.Features.Appointment.Dtos;

namespace OurCheck.API.Features.Appointment.Queries.List;

public record ListAppointmentsQuery : IRequest<List<AppointmentDto>>;