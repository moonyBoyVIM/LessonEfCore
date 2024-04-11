using LessonsEfCore.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonsEfCore.DataAccess.Postgres.Repositories;

public class LessonRepository
{
    private readonly AppDbContext _dbContext;

    public LessonRepository(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task Add(Guid courseId, Lesson lesson)
    {
        var courseExisting = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == courseId)
                            ?? throw new Exception();
        courseExisting.Lessons.Add(lesson);
        await _dbContext.SaveChangesAsync();
    }
    public async Task AddSecond(string title, Guid courseId)
    {
        var lesson = new Lesson
        {
            Title = title,
            CourseId = courseId
        };
        await _dbContext.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();
    }
}
