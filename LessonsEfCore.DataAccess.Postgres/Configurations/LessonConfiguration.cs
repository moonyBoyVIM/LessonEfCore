using LessonsEfCore.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsEfCore.DataAccess.Postgres.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Course)
               .WithMany(x => x.Lessons)
               .HasForeignKey(x => x.CourseId);
    }
}
