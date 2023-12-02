using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MktAcademy.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must insert a {0}")]
        [Display(Name = "Course Name")]
        public string Name { get; set; }


        [StringLength(200, ErrorMessage = "The {0} should be between {2} and {1} characters", MinimumLength = 5)]
        [Required(ErrorMessage = "You must insert a {0}")]
        public string Description { get; set; }

        //Preço normal de lista
        [DataType(DataType.Currency)]//tipo moeda
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]//formatar 2 casas decimais, mas guarda com o formato que está na tabela
        [Required(ErrorMessage = "You must insert a {0}")]
        [Display(Name = "List Price")]
        [Range(0, 1200)]
        public decimal ListPrice { get; set; }

        //Preço para empresas com desconto 20%
        [DataType(DataType.Currency)]//tipo moeda
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]//formatar 2 casas decimais, mas guarda com o formato que está na tabela
        [Required(ErrorMessage = "You must insert a {0}")]
        [Display(Name = "Company Price")]
        [Range(1, 1200)]
        public decimal Price20 { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }        

    }
}
