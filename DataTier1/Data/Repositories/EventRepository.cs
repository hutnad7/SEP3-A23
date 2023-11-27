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
        public override async Task<Event> CreateAsync(Event entity)
        {
            try
            {
                User cafeOwner = _context.Set<User>().Include(u => u.Events).Include(u => u.Bookings).FirstOrDefault(c => c.Id.Equals(entity.CafeOwnerId));
                entity.CafeOwner = cafeOwner;
                User enterteiner = _context.Users.Include(u => u.Events).Include(u => u.Bookings).FirstOrDefault(c => c.Id == entity.EnterteinerId);
                entity.Enterteiner = enterteiner;
                if(entity.Bookings is null)
                {
                    entity.Bookings = new List<Booking>();
                }
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
