using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.State
{
    public class Pending : EventState
    {
        public override void accept(Event @event)
        {
          //  @event.state = new Accepted();
        }

        public override void cancel(Event @event)
        {
            
        }

        public override void refuse(Event @event)
        {
       //     @event.state = new Refused();
        }
        public override string ToString()
        {
            return "Pending";
        }
    }
}
