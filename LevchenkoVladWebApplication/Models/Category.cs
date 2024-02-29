using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LevchenkoVladWebApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
