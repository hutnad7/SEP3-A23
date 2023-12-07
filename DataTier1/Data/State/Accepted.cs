using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.State
{
    public class Accepted : EventState
    {
        public override void accept(Event @event)
        {
            
        }

        public override void cancel(Event @event)
        {
     //       @event.state = new Pending();
        }

        public override void refuse(Event @event)
        {

        }
        public override string ToString()
        {
            return "Accepted";
        }
    }
}
