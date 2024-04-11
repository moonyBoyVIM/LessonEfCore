using LessonsEfCore.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsEfCore.DataAccess.Postgres.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Course)
               .WithOne(x => x.Author)
               .HasForeignKey<Author>(x => x.CourseId);
    }
}
