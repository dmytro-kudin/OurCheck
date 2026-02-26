using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurCheck.Persistence.Domain;
using OurCheck.Persistence.QueryFilters;

namespace OurCheck.Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(appointment => appointment.Id);

        builder.Property(appointment => appointment.Note)
            .HasMaxLength(500);

        builder.Property(appointment => appointment.AppointmentTime)
            .IsRequired();

        builder.Property(appointment => appointment.Created)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(appointment => appointment.LastModified)
            .IsRequired()
            .ValueGeneratedOnUpdate();
        
        builder.HasOne(appointment => appointment.SavedPlace)
            .WithMany(savedPlace => savedPlace.Appointments)
            .HasForeignKey(appointment => appointment.SavedPlaceId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(appointment => appointment.Id);
        builder.HasIndex(appointment => appointment.AppointmentTime);
        
        builder.HasQueryFilter(nameof(AppointmentQueryFilter.FutureOnly), appointment => appointment.AppointmentTime > DateTimeOffset.UtcNow);
    }
}