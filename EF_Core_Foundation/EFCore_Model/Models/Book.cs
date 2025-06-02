using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Model.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; } = "ISBN";
        public decimal? Price { get; set; }
        public BookDetail? BookDetail { get; set; }
        [NotMapped]
        public int PriceRange { get; set; }

        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }

        public Publisher? Publisher { get; set; }

        public List<BookAuthorMap>? BookAuthors { get; set; }
    }
}
