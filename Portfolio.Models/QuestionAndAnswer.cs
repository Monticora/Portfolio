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
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
