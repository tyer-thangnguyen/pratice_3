using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Data
{
    public enum GenderType
    {
        Male = 0, Female = 1, Others = 2
    }
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TenantsId {get; set;}

        public Guid FormType { get; set; }

        [Required]
        [MaxLength(512)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(512)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(256)]
        public string MobilePhone { get; set; }

        public GenderType Gender { get; set; }

        public string Properties { get; set; }

        //public ICollection<FormType> FormTypes { get; set; }
        //public ICollection<Tenant> Tenants { get; set; }
        //public Customer()
        //{
            //FormTypes = new List<FormType>();
        //}

        //relationship
        public Tenant Tenant { get; set; }
        public FormType formType { get; set; }
    }
}
