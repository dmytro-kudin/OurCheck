using Microsoft.EntityFrameworkCore;
using OurCheck.Domain;

namespace OurCheck.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments => Set<Appointment>();

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
                    await context.Set<Appointment>().AddRangeAsync(appointments, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
            })
            .UseSeeding((context, _) =>
            {
                if (!context.Set<Appointment>().Any())
                {
                    var appointments = GetSeedAppointments();
                    context.Set<Appointment>().AddRange(appointments);
                    context.SaveChanges();
                }
            });
    }

    private static List<Appointment> GetSeedAppointments() =>
    [
        new Appointment("Logoped", new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero)),
    ];
}