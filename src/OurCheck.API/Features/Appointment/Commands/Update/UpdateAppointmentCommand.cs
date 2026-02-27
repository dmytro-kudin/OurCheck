using MediatR;

namespace OurCheck.API.Features.Appointment.Commands.Update;

public record UpdateAppointmentCommand(Guid Id, string? Note, DateTimeOffset AppointmentTime, Guid? SavedPlaceId) : IRequest;