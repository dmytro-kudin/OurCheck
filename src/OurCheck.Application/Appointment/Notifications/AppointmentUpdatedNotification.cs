using MediatR;

namespace OurCheck.Application.Appointment.Notifications;

public record AppointmentUpdatedNotification(Guid? Id = null) : INotification;