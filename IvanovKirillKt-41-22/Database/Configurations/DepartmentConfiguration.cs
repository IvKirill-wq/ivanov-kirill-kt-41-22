using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IvanovKirillKt_41_22.Database.Helpers;
using IvanovKirillKt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IvanovKirillKt_41_22.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "Kafedra";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("department_id")
                .HasComment("Идентификатор кафедры");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType("varchar(100)")
                .HasComment("Название кафедры");

            builder.Property(d => d.HeadTeacherId)
                .IsRequired()
                .HasColumnName("f_head_teacher_id")
                .HasComment("Идентификатор заведующего кафедрой");

            builder.HasOne(d => d.HeadTeacher)
               .WithOne()
               .HasForeignKey<Department>(d => d.HeadTeacherId)
               .HasConstraintName("fk_department_head_teacher")
               .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName);
        }
    }
}
