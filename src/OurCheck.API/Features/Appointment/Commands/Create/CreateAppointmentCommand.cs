using MediatR;

namespace OurCheck.API.Features.Appointment.Commands.Create;

public record CreateAppointmentCommand(string? Note, DateTimeOffset AppointmentTime, Guid? SavedPlaceId) : IRequest<Guid>;