namespace OurCheck.Features.Appointment.Dtos;

public record AppointmentDto(Guid Id, string? Note, DateTimeOffset AppointmentTime);