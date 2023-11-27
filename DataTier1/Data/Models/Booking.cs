using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Booking : BaseEntity
    {
        [Required]
        public User User { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Event Event { get; set; }
        [Required]
        public Guid EventId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }


    }
}
