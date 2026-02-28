using MediatR;

namespace OurCheck.Application.SavedPlace.Notifications;

public record SavedPlaceUpdatedNotification(Guid? Id = null) : INotification;