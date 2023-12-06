using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : BaseEntity
    {

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        [AllowNull]
        public string Description { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CreationDate { get; set; }

        [Required]
        public Role Role { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

    }
}
