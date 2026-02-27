namespace OurCheck.Application.Appointment.Dtos;

public record AppointmentDto(
    Guid Id,
    string? Note,
    DateTimeOffset AppointmentTime,
    string? PlaceName,
    string? PlaceUrl);