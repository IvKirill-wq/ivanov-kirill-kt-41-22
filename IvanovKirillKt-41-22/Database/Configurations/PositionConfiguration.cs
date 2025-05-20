using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IvanovKirillKt_41_22.Database.Helpers;
using IvanovKirillKt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IvanovKirillKt_41_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "Position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnName("c_position_title")
                .HasColumnType("varchar(100)")
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }
}
