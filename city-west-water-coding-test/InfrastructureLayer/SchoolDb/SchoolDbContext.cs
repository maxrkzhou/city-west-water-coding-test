using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.InfrastructureLayer.SchoolDb
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentClass>()
                .ToTable("StudentClass")
                .HasKey(x => new { x.StudentId, x.ClassId });

            builder.Entity<StudentClass>()
                .HasOne(x=>x.Student)
                .WithMany(x=>x.StudentClasses)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentClass>()
             .HasOne(x => x.Class)
             .WithMany(x => x.StudentClasses)
             .HasForeignKey(x => x.ClassId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
