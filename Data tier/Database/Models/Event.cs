using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Event : BaseEntity
    {

        //[Required]
        //public User CafeOwner { get; set; }

        /*[Required]
        public Guid AuthorId { get; set; }*/
        [Required]
        public User Enterteiner { get; set; }
        [Required]
        public Guid EnterteinerId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

    }
}
