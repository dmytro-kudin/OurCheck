using MediatR;

namespace OurCheck.Application.Features.SavedPlace.Notifications;

public record SavedPlaceUpdatedNotification(Guid? Id = null) : INotification;