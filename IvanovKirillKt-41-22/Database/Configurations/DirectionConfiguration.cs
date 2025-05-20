using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IvanovKirillKt_41_22.Database.Helpers;
using IvanovKirillKt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IvanovKirillKt_41_22.Database.Configurations
{
    public class DirectionConfiguration : IEntityTypeConfiguration<Direction>
    {
        private const string TableName = "Napravlenie";

        public void Configure(EntityTypeBuilder<Direction> builder)
        {
            builder.HasKey(p => p.DirectionId)
                .HasName($"pk_{TableName}_direction_id");

            builder.Property(p => p.DirectionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("direction_id")
                .HasComment("Идентификатор направления");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_direction_name")
                .HasColumnType("varchar(100)")
                .HasComment("Название направления");

            builder.Property(p => p.hours)
                .IsRequired()
                .HasColumnName("n_hours")
                .HasComment("Количество часов");

            builder.HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineId)
                .HasConstraintName("fk_direction_discipline")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeacherId)
                .HasConstraintName("fk_direction_teacher")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName);
        }
    }
}
