using MediatR;

namespace OurCheck.Application.Features.Appointment.Notifications;

public record AppointmentUpdatedNotification(Guid? Id = null) : INotification;