using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IvanovKirillKt_41_22.Database.Helpers;
using IvanovKirillKt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IvanovKirillKt_41_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "Teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_firstname")
                .HasColumnType("varchar(100)")
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_lastname")
                .HasColumnType("varchar(100)")
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasColumnType("varchar(100)")
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.ADId)
                .IsRequired()
                .HasColumnName("f_academic_degree_id")
                .HasComment("Идентификатор ученой степени");

            builder.Property(p => p.PositionId)
                .IsRequired()
                .HasColumnName("f_position_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("f_department_id")
                .HasComment("Идентификатор кафедры");

            builder.HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.ADId)
                .HasConstraintName("fk_teacher_academic_degree")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_teacher_position")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_teacher_department")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName);
        }
    }
}
