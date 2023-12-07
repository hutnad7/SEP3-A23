using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data.State;

namespace Data.Models
{
    public class Event : BaseEntity
    {

        [Required]
        public User CafeOwner { get; set; }

        [Required]
        public Guid CafeOwnerId { get; set; }
        [Required]
        public User Enterteiner { get; set; }
        [Required]
        public Guid EnterteinerId { get; set; }

        [Required]
        public string CreationDate { get; set; }
        
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int AvailablePlaces { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public StateEvent state { get; set; }
        public Event() 
        {
            this.state = StateEvent.Pending;
        }
    }
}
