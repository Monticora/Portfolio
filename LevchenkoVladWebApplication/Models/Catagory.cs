using System.ComponentModel.DataAnnotations;

namespace LevchenkoVladWebApplication.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
