using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
namespace EFCore_Model.Models
{
    public class Fluent_BookDetail
    {
        //[Key]
        public int BookDetail_Id { get; set; }
        //[Required]
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Weight { get; set; }

        //[ForeignKey("Fluent_Book")]
        public int Book_Id { get; set; }
        public Fluent_Book? Fluent_Book { get; set; }
    }
}
