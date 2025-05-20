using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IvanovKirillKt_41_22.Database.Helpers;
using IvanovKirillKt_41_22.Models;
using Microsoft.EntityFrameworkCore;


namespace IvanovKirillKt_41_22.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "Academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.HasKey(p => p.ADId)
                .HasName($"pk_{TableName}_ad_id");

            builder.Property(p => p.ADId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ad_id")
                .HasComment("Идентификатор ученой степени");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_ad_name")
                .HasColumnType("varchar(100)")
                .HasComment("Название ученой степени");

            builder.ToTable(TableName);
        }
    }
}
