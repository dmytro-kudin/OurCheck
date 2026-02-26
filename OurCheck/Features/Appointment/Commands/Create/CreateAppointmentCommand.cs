using MediatR;

namespace OurCheck.Features.Appointment.Commands.Create;

public record CreateAppointmentCommand(string? Note, DateTimeOffset AppointmentTime, Guid? SavedPlaceId) : IRequest<Guid>;