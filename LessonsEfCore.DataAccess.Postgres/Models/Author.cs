namespace LessonsEfCore.DataAccess.Postgres.Models;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
}
