using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;

namespace OurCheck.Application.Appointment.Notifications;

public class AppointmentRemoveCacheHandler(ICache cache) : INotificationHandler<AppointmentUpdatedNotification>
{
    public async Task Handle(AppointmentUpdatedNotification notification, CancellationToken cancellationToken)
    {
        await cache.RemoveAsync(CacheKeys.Appointments);
        
        if (notification.Id.HasValue)
            await cache.RemoveAsync(string.Format(CacheKeys.AppointmentId, notification.Id));
    }
}