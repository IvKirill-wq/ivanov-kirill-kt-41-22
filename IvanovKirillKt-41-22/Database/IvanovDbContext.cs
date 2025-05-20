using IvanovKirillKt_41_22.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using IvanovKirillKt_41_22.Models;
using IvanovKirillKt_41_22.Database;

namespace IvanovKirillKt_41_22.Databse
{

    public class IvanovDbContext : DbContext
    {
        public IvanovDbContext(DbContextOptions<IvanovDbContext> options) : base(options)
        {
        }

        //Добавляем таблицы
        DbSet<AcademicDegree> AcademicDegree { get; set; }
        DbSet<Department> Department { get; set; }
        DbSet<Direction> Direction { get; set; }
        DbSet<Discipline> Discipline { get; set; }
        DbSet<Position> Position { get; set; }
        DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DirectionConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
        
    }
}
