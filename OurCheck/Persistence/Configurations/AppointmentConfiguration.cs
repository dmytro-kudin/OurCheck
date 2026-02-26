using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurCheck.Domain;

namespace OurCheck.Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Note)
            .HasMaxLength(500);

        builder.Property(m => m.AppointmentTime)
            .IsRequired();

        builder.Property(m => m.Created)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(m => m.LastModified)
            .IsRequired()
            .ValueGeneratedOnUpdate();

        builder.HasIndex(m => m.Id);
        builder.HasIndex(m => m.AppointmentTime);
        
        builder.HasQueryFilter(nameof(AppointmentQueryFilter.FutureOnly), m => m.AppointmentTime > DateTimeOffset.UtcNow);
    }
}