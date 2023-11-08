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
    public class CafeOwnerRepository : BaseRepository<User>, ICafeOwnerRepository
    {
        public CafeOwnerRepository(DBContext context) : base(context)
        {
        }
        public override async Task<ICollection<User>> GetAll()
        {
            return await _context.Set<User>().Where(e => e.Role.Equals(Role.CafeOwner)).Include(e => e.Events).ToListAsync();
        }
        public override async Task<ICollection<User>> GetAll(Expression<Func<User, bool>> filter)
        {
            return await _context.Set<User>().Where(e => e.Role.Equals(Role.CafeOwner)).Include(e => e.Events).Where(filter).ToListAsync();
        }
        public override async ValueTask<ICollection<User>> GetByAsync(Expression<Func<User, bool>> filter)
        {
            return await _context.Set<User>().Where(e => e.Role.Equals(Role.CafeOwner)).Include(e => e.Events).Where(filter).ToListAsync();
        }
        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Set<User>().Where(e=>e.Role.Equals(Role.User)).Include(e => e.Events).SingleAsync(e => e.Id == id);
        }
        public override async Task UpdateAsync(User entity)
        {
            User dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException();
            }
            if (dbEntity.Events is null)
            {
                dbEntity.Events = new List<Event>();
            }
            foreach (var excursion in entity.Events)
            {
                dbEntity.Events.Add(excursion);
            }
            _context.Update(dbEntity);
            
            await _context.SaveChangesAsync();
        }
    }
}
