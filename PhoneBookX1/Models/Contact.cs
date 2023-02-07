using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookX1.Models
{
    internal class Contact
    {
        [Key]
        public string PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
