using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MktAcademy.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }     
        [Required(ErrorMessage = "You must insert a {0}")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }        
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
