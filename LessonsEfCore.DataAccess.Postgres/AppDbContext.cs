using LessonsEfCore.DataAccess.Postgres.Configurations;
using LessonsEfCore.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonsEfCore.DataAccess.Postgres;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
            : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
