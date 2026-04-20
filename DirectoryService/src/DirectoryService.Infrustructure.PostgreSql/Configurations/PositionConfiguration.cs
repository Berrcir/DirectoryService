using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrustructure.PostgreSql.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(e => e.Id).HasName("pk_position_id");

        builder.Property(e => e.Id)
            .HasConversion(eId => eId.Value, id => new PositionId(id))
            .HasColumnName("position_id");

        builder.OwnsOne(e => e.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Speciality)
                .HasColumnName("speciality")
                .IsRequired();

            nameBuilder.Property(n => n.Direction)
                .HasColumnName("direction")
                .IsRequired();
        });

        builder.Property(e => e.Description)
            .HasColumnName("description");

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