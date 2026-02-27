using MediatR;

namespace OurCheck.Application.Appointment.Commands.Delete;

public record DeleteAppointmentCommand(Guid Id) : IRequest;