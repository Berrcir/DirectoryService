using DirectoryService.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrustructure.PostgreSql.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(e => e.Id).HasName("pk_department_id");

        builder.Property(e => e.Id)
            .HasConversion(eId => eId.Value, id => new DepartmentId(id))
            .HasColumnName("department_id");

        builder.OwnsOne(e => e.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.ManagementUnit)
                .HasColumnName("management_unit")
                .IsRequired();

            nameBuilder.Property(n => n.Direction)
                .HasColumnName("direction")
                .IsRequired();
        });

        builder.Property(e => e.ParentId)
            .HasConversion(eId => eId!.Value, id => new DepartmentId(id))
            .HasColumnName("parent_id");

        builder.Property(e => e.Identifier)
            .HasColumnName("identifier")
            .IsRequired();

        builder.Property(e => e.Path)
            .HasColumnName("path")
            .IsRequired();

        builder.Property(e => e.Depth)
            .HasColumnName("depth")
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.HasOne(e => e.Parent)
            .WithMany(e => e.ChildDeparments)
            .HasForeignKey(p => p.ParentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}