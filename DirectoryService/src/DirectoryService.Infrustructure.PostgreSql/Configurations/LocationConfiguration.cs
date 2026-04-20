using DirectoryService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrustructure.PostgreSql.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.HasKey(e => e.Id).HasName("pk_location_id");

        builder.Property(e => e.Id)
            .HasConversion(eId => eId.Value, id => new LocationId(id))
            .HasColumnName("location_id");

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.OwnsOne(e => e.Address, builder =>
        {
            builder.ToJson("address");
        });

        builder.OwnsOne(e => e.TimeZone, builder =>
        {
            builder.ToJson("time_zone");
        });

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}