using Microsoft.EntityFrameworkCore;
using OurCheck.Persistence.Domain;

namespace OurCheck.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<SavedPlace> SavedPlaces => Set<SavedPlace>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("app");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                if (!await context.Set<Appointment>().AnyAsync(cancellationToken))
                {
                    var appointments = GetSeedAppointments();
                    var savedPlaces = GetSeedSavedPlaces();
                    await context.Set<Appointment>().AddRangeAsync(appointments, cancellationToken);
                    await context.Set<SavedPlace>().AddRangeAsync(savedPlaces, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            })
            .UseSeeding((context, _) =>
            {
                if (!context.Set<Appointment>().Any())
                {
                    var appointments = GetSeedAppointments();
                    var savedPlaces = GetSeedSavedPlaces();
                    context.Set<Appointment>().AddRange(appointments);
                    context.Set<SavedPlace>().AddRange(savedPlaces);
                    context.SaveChanges();
                }
            });
    }

    private static List<Appointment> GetSeedAppointments() =>
    [
        new Appointment("Logoped", new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero)),
    ];

    private static List<SavedPlace> GetSeedSavedPlaces() =>
    [
        new SavedPlace("Logo place", "https://maps.app.goo.gl/GUivk7ducBocAuim6"),
    ];
}