using MediatR;
using OurCheck.Features.Appointment.Dtos;

namespace OurCheck.Features.Appointment.Queries.Get;

public record GetAppointmentQuery(Guid Id) : IRequest<AppointmentDto?>;