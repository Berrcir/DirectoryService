using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrustructure.PostgreSql.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");

        builder.HasKey(e => new { e.DepartmentId, e.PositionId });

        builder.Property(e => e.DepartmentId)
            .HasConversion(eId => eId.Value, id => new DepartmentId(id))
            .HasColumnName("department_id");

        builder.Property(e => e.PositionId)
            .HasConversion(eId => eId.Value, id => new PositionId(id))
            .HasColumnName("position_id");

        builder.HasOne<Department>()
            .WithMany(e => e.Positions)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(e => e.PositionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
