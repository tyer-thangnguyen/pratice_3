using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Id")]
        public Tenant Tenant { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        
    }
}
