using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Data.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DBContext context) : base(context)
        {
        }
        public override async Task<ICollection<Event>> GetAll()
        {
            return await _context.Set<Event>().Include(e => e.Bookings).ToListAsync();
        }
        public override async Task<ICollection<Event>> GetAll(Expression<Func<Event, bool>> filter)
        {
            return await _context.Set<Event>().Include(e => e.Bookings).Where(filter).ToListAsync();
        }
        public override async ValueTask<ICollection<Event>> GetByAsync(Expression<Func<Event, bool>> filter)
        {
            return await _context.Set<Event>().Include(e => e.Bookings).Where(filter).ToListAsync();
        }
        public override async Task<Event> GetByIdAsync(Guid id)
        {
            return await _context.Set<Event>().Include(e => e.Bookings).SingleAsync(e => e.Id == id);
        }
        public override async Task UpdateAsync(Event entity)
        {
            Event dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException();
            }
            if (dbEntity.Bookings is null)
            {
                dbEntity.Bookings = new List<Booking>();
            }
            foreach (var booking in entity.Bookings)
            {
                dbEntity.Bookings.Add(booking);
            }
            _context.Update(dbEntity);

            await _context.SaveChangesAsync();
        }
        public override async Task<Event> CreateAsync(Event entity)
        {
            try
            {
                User cafeOwner = _context.Set<User>().Include(u => u.Events).Include(u => u.Bookings).FirstOrDefault(c => c.Id.Equals(entity.CafeOwnerId));
                entity.CafeOwner = cafeOwner;
                User enterteiner = _context.Users.Include(u => u.Events).Include(u => u.Bookings).FirstOrDefault(c => c.Id == entity.EnterteinerId);
                entity.Enterteiner = enterteiner;
                await _context.Events.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }
    }
}
