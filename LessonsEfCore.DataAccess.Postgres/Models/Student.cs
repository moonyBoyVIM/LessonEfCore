namespace LessonsEfCore.DataAccess.Postgres.Models;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Course> Courses { get; set; } = [];
}
