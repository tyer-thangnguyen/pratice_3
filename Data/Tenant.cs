using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Data
{
    [Table("Tenant")]
    public class Tenant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public ICollection<Customer> Customers { get; set; }
        //public Tenant()
        //{
            //Users = new HashSet<User>();
        //}

        //relationship
        public Customer Customer { get; set; }
    }
}
