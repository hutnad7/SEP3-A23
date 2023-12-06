using System.Linq.Expressions;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(DBContext context) : base(context)
    {
    }
    
    public override async Task<ICollection<Post>> GetAll()
    {
        return await _context.Set<Post>().Include(p => p.Author).Include(p => p.Event).ToListAsync();
    }
    
    public override async Task<ICollection<Post>> GetAll(Expression<Func<Post, bool>> filter)
    {
        return await _context.Set<Post>().Include(p => p.Author).Include(p=> p.Event).Where(filter).ToListAsync();
    }
    
    public override async ValueTask<ICollection<Post>> GetByAsync(Expression<Func<Post, bool>> filter)
    {
        return await _context.Set<Post>().Include(p => p.Author).Include(p=> p.Event).Where(filter).ToListAsync();
    }
    
    public override async Task<Post> GetByIdAsync(Guid id)
    {
        return await _context.Set<Post>().Include(p => p.Author).SingleAsync(p => p.Id == id);
    }
    
    public override async Task<Post> CreateAsync(Post entity)
    {
        try
        {
            User author = _context.Set<User>().Include(u => u.Posts).FirstOrDefault(c => c.Id.Equals(entity.Author));
            entity.Author = author;
            if (entity.Author is not null) { 
            Event events = _context.Set<Event>().Include(u => u.CafeOwner).FirstOrDefault(c => c.Id.Equals(entity.EventId));
            entity.Event = events;
        }
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}