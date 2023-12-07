using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.State
{
    public abstract class EventState
    {
        public Role Role { get; set; }
      public abstract void accept(Event @event);
        public abstract void cancel(Event @event);
        public abstract void refuse(Event @event);
    }
}
