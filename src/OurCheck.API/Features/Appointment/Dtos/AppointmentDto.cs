namespace OurCheck.API.Features.Appointment.Dtos;

public record AppointmentDto(
    Guid Id,
    string? Note,
    DateTimeOffset AppointmentTime,
    string? PlaceName,
    string? PlaceUrl);