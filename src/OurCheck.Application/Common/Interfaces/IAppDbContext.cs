using Microsoft.EntityFrameworkCore;

namespace OurCheck.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Domain.Entities.Appointment> Appointments { get; }

    DbSet<Domain.Entities.SavedPlace> SavedPlaces { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}