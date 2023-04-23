namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System.Diagnostics.CodeAnalysis;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext([NotNull] DbContextOptions options)
            : base(options)
        {

        }

        //To configure connection to your server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.CONNNECTION_STRING);
            }
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        //To configure database relations (DDL)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(e =>
                e.Property(s => s.PhoneNumber).HasColumnType("CHAR(10)"));

            modelBuilder.Entity<Resource>(e => 
                e.Property(r => r.Url).IsUnicode(false));
           
            modelBuilder.Entity<Homework>(e =>
                e.Property(h => h.Content).IsUnicode(false));

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentsCourses);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsCourses);

                entity.HasKey(x => new { x.StudentId, x.CourseId });
            });
        }
    }
}