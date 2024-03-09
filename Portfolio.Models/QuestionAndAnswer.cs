using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Portfolio.Models
{
    public class QuestionAndAnswer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
        [Required]
        public int SubcategoryId { get; set; }
        [ForeignKey("SubcategoryId")]
        [ValidateNever]
        [Required]
        public Subcategory Subcategory { get; set; }
    }
}
