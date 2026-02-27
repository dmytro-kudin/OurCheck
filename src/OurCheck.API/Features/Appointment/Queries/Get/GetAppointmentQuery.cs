using MediatR;
using OurCheck.API.Features.Appointment.Dtos;

namespace OurCheck.API.Features.Appointment.Queries.Get;

public record GetAppointmentQuery(Guid Id) : IRequest<AppointmentDto?>;