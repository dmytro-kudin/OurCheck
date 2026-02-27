using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OurCheck.Domain.Entities;

namespace OurCheck.Infrastructure.Data.Configurations;

public class SavedPlaceConfiguration : IEntityTypeConfiguration<SavedPlace>
{
    public void Configure(EntityTypeBuilder<SavedPlace> builder)
    {
        builder.ToTable("SavedPlaces");

        builder.HasKey(savedPlace => savedPlace.Id);

        builder.Property(savedPlace => savedPlace.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(savedPlace => savedPlace.Url)
            .HasMaxLength(500);

        builder.Property(savedPlace => savedPlace.Created)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(savedPlace => savedPlace.LastModified)
            .IsRequired()
            .ValueGeneratedOnUpdate();

        builder.HasIndex(savedPlace => savedPlace.Id);
    }
}