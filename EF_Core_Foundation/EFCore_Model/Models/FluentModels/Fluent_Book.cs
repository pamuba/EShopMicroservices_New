using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Model.Models
{
    public class Fluent_Book
    {
        public int Book_Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; } = "ISBN";
        public decimal? Price { get; set; }
        public int PriceRange { get; set; }

        public Fluent_BookDetail? BookDetail { get; set; }

        //[ForeignKey("Fluent_Publisher")]
        public int Publisher_Id { get; set; }

        public Fluent_Publisher? Fluent_Publisher { get; set; }

        //public List<Fluent_Author>? Authors { get; set; }

        public List<Fluent_BookAuthorMap>? BookAuthors { get; set; }
    }
}
