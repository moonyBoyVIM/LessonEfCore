namespace LessonsEfCore.DataAccess.Postgres.Models;

public class Lesson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string LessonText { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
}
