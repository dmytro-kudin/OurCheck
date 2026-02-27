using MediatR;

namespace OurCheck.API.Features.Appointment.Commands.Delete;

public record DeleteAppointmentCommand(Guid Id) : IRequest;