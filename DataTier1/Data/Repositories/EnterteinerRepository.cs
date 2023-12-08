 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class EnterteinerRepository : BaseRepository<User>, IEnterteinerRepository
    {
        public EnterteinerRepository(DBContext context) : base(context)
        {
        }

        public override async Task<ICollection<User>> GetAll()
        {
            return await _context.Set<User>().Where(e=> e.Role.Equals(Role.Entertainer)).Include(e => e.Bookings).Include(e=> e.Events).ToListAsync();
        }
        public override async Task<ICollection<User>> GetAll(Expression<Func<User, bool>> filter)
        {
            return await _context.Set<User>().Where(e => e.Role.Equals(Role.Entertainer)).Include(e => e.Events).Include(e => e.Bookings).Where(filter).ToListAsync();
        }
        public override async ValueTask<ICollection<User>> GetByAsync(Expression<Func<User, bool>> filter)
        {
            return await _context.Set<User>().Where(e => e.Role.Equals(Role.Entertainer)).Include(e => e.Events).Include(e => e.Bookings).Where(filter).ToListAsync();
        }
        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Set<User>().Include(e => e.Events).Include(e => e.Bookings).SingleAsync(e=>e.Id==id);
        }
        public override async Task UpdateAsync(User entity)
        {
            User dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException();
            }
            if(dbEntity.Events is null)
            { 
                dbEntity.Events = new List<Event>(); }
            foreach(var destination in entity.Events)
            {
                dbEntity.Events.Add(destination);
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
    }
}
