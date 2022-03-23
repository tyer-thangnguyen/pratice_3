using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Models
{
    public class TenantModel
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
