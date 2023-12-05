using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MktAcademy.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        
    }
}
