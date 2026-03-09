using MediatR;
using OurCheck.Dto.Common;

namespace OurCheck.Application.Features.Appointment.Commands.Create;

public record CreateAppointmentCommand(string? Note, DateTimeOffset AppointmentTime, Guid? SavedPlaceId) : IRequest<CreatedDto>;