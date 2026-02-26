using MediatR;

namespace OurCheck.Features.Appointment.Commands.Delete;

public record DeleteAppointmentCommand(Guid Id) : IRequest;