using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Subcategory Name")]
        [MaxLength(15)]
        public string? Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        [Required]
        public Category Category { get; set; }

    }
}
