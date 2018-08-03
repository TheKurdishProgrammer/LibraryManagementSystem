using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMangement.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
      

        [Required,MaxLength(30),MinLength(5)]
        public string CustomerName { get; set; }
        public ICollection<Book> BorrowedBooks { get; set; }

    }
}
