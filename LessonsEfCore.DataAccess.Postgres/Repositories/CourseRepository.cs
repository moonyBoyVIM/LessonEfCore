using LessonsEfCore.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LessonsEfCore.DataAccess.Postgres;

public class CourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<List<Course>> Get()
    {
        return await _dbContext.Courses
                               .AsNoTracking()
                               .OrderBy(x => x.Title)
                               .ToListAsync();
    }
    public async Task<List<Course>> GetWithLessons()
    {
        return await _dbContext.Courses
                               .AsNoTracking()
                               .Include(x => x.Lessons)
                               .ToListAsync();
    }
    public async Task<Course?> GetById(Guid id)
    {
        return await _dbContext.Courses
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<Course>> GetByFilters(string title, decimal price)
    {
        var query = _dbContext.Courses.AsNoTracking();

        if(!string.IsNullOrEmpty(title))
        {
            query = query.Where(x => x.Title.Contains(title));
        }

        if(price > 0)
        {
            query = query.Where(x => x.Price > price);
        }

        return await query.ToListAsync();
    }
    public async Task<List<Course>> GetByPage(int page, int pageSize)
    {
        return await _dbContext.Courses
                               .AsNoTracking()
                               .Skip((page - 1) * pageSize)
                               .ToListAsync();
    }
    public async Task Add(Guid id, string title, string description, Guid authorId, decimal price)
    {
        var courseEnt = new Course
        {
            Id = id,
            Title = title,
            Description = description,
            AuthorId = authorId,
            Price = price
        };
        await _dbContext.AddAsync(courseEnt);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(Guid id, string title, string description, Guid authorId, decimal price)
    {
        var courseExisting = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id)
                            ?? throw new Exception();

        courseExisting.Title = title;
        courseExisting.Description = description;
        courseExisting.Price = price;
        courseExisting.AuthorId = authorId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateSecond(Guid id, string title, string description, Guid authorId, decimal price)
    {
        await _dbContext.Courses
                        .AsNoTracking()
                        .ExecuteUpdateAsync(x =>
                                            x.SetProperty(i => i.Id, id)
                                             .SetProperty(i => i.Title, title)
                                             .SetProperty(i => i.Description, description));
        await _dbContext.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        await _dbContext.Courses 
                        .Where(x => x.Id == id)
                        .ExecuteDeleteAsync();
    }
}
