using MediatR;
using OurCheck.Application.Common.Constants;
using OurCheck.Application.Services.Cache;

namespace OurCheck.Application.SavedPlace.Notifications;

public class SavedPlaceRemoveCacheHandler(ICache cache) : INotificationHandler<SavedPlaceUpdatedNotification>
{
    public async Task Handle(SavedPlaceUpdatedNotification notification, CancellationToken cancellationToken)
    {
        await cache.RemoveByTagAsync(CacheKeys.SavedPlaces);
        await cache.RemoveByTagAsync(CacheKeys.Appointments);
    }
}