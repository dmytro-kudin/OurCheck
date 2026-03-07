namespace OurCheck.Dto.Appointment;

public record AppointmentDto(
    Guid Id,
    string? Note,
    DateTimeOffset AppointmentTime,
    string? PlaceName,
    string? PlaceUrl);