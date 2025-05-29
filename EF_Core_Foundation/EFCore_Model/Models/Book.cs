using System.ComponentModel.DataAnnotations;

namespace EFCore_Model.Models
{
    public class Book
    {
        [Key]
        public int IDBook { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; } = "ISBN";
        public decimal? Price { get; set; }
    }
}
