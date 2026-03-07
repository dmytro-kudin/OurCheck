using MediatR;
using OurCheck.Dto.Appointment;

namespace OurCheck.Application.Appointment.Queries.Get;

public record GetAppointmentQuery(Guid Id) : IRequest<AppointmentDto?>;