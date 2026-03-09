using MediatR;

namespace OurCheck.Application.Features.Appointment.Commands.Delete;

public record DeleteAppointmentCommand(Guid Id) : IRequest;