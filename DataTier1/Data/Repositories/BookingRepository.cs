using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DBContext context) : base(context)
        {
        }
        public override async Task<ICollection<Booking>> GetAll()
        {
            return await _context.Set<Booking>().ToListAsync();
        }
        public override async Task<ICollection<Booking>> GetAll(Expression<Func<Booking, bool>> filter)
        {
            return await _context.Set<Booking>().Where(filter).ToListAsync();
        }
        public override async ValueTask<ICollection<Booking>> GetByAsync(Expression<Func<Booking, bool>> filter)
        {
            return await _context.Set<Booking>().Where(filter).ToListAsync();
        }
        public override async Task<Booking> GetByIdAsync(Guid id)
        {
            return await _context.Set<Booking>().SingleAsync(e => e.Id == id);
        }
        public override async Task UpdateAsync(Booking entity)
        {
            Booking dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException();
            }
            _context.Update(dbEntity);

            await _context.SaveChangesAsync();
        }
        public override async Task<Booking> CreateAsync(Booking entity)
        {
            try
            {
                User user = _context.Set<User>().Include(u => u.Events).Include(u => u.Bookings).FirstOrDefault(c => c.Id.Equals(entity.UserId));
                entity.User = user;
                Event events = _context.Set<Event>().Include(u => u.Bookings).FirstOrDefault(c => c.Id == entity.EventId);
                entity.Event = events;
                if (entity.NumberOfPeople > events.AvailablePlaces)
                {
                    throw new ArgumentException("There are not enough places!");
                }
                await _context.Bookings.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
