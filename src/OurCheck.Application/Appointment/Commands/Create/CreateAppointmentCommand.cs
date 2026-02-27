using MediatR;

namespace OurCheck.Application.Appointment.Commands.Create;

public record CreateAppointmentCommand(string? Note, DateTimeOffset AppointmentTime, Guid? SavedPlaceId) : IRequest<Guid>;