namespace LessonsEfCore.DataAccess.Postgres.Models;

public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
    public List<Lesson> Lessons { get; set; } = []; 
    public List<Student> Students { get; set; } = [];
}
