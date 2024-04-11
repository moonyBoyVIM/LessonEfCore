using LessonsEfCore.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsEfCore.DataAccess.Postgres.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Author)
               .WithOne(x => x.Course)
               .HasForeignKey<Course>(x => x.AuthorId);
        
        builder.HasMany(x => x.Lessons)
               .WithOne(x => x.Course)
               .HasForeignKey(x => x.CourseId);

        builder.HasMany(x => x.Students)
               .WithMany(x => x.Courses);
    }
}
