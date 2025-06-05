using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCore_Model.Models
{
    public class Fluent_BookAuthorMap
    {
        [ForeignKey("Fluent_Book")]
        public int Book_Id { get; set; }
        [ForeignKey("Fluent_Author")]
        public int Author_Id { get; set; }

        public Fluent_Book? Fluent_Book { get; set; }
        public Fluent_Author? Fluent_Author { get; set; }
    }
}
