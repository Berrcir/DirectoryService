using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrustructure.PostgreSql.Configurations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");

        builder.HasKey(e => new { e.DepartmentId, e.LocationId } );

        builder.Property(e => e.DepartmentId)
            .HasConversion(eId => eId.Value, id => new DepartmentId(id))
            .HasColumnName("department_id");

        builder.Property(e => e.LocationId)
            .HasConversion(eId => eId.Value, id => new LocationId(id))
            .HasColumnName("location_id");

        builder.HasOne<Department>()
            .WithMany(e => e.Locations)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(e => e.LocationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
