using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Interfaces
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<Event> AcceptEventAsync(Event @event);
        Task<Event> RefuseEventAsync(Event @event);
        Task<Event> RevertStateAsync(Event @event);
    }
}
