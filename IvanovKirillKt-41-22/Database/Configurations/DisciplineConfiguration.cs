using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IvanovKirillKt_41_22.Database.Helpers;
using IvanovKirillKt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IvanovKirillKt_41_22.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType("varchar(100)")
                .HasComment("Название дисциплины");

            builder.ToTable(TableName);
        }
    }
}
