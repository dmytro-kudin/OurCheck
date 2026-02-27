using MediatR;
using OurCheck.Application.Appointment.Dtos;

namespace OurCheck.Application.Appointment.Queries.Get;

public record GetAppointmentQuery(Guid Id) : IRequest<AppointmentDto?>;