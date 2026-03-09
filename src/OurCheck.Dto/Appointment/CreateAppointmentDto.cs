namespace OurCheck.Dto.Appointment;

public record CreateAppointmentDto(string? Note, DateTimeOffset AppointmentTime, Guid? SavedPlaceId);