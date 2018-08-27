using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryMangement.Data.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required, MaxLength(30), MinLength(5)]
        public string BookName { get; set; }

        public Auther Auther { get; set; }
        public int AutherId { get; set; }

        
        public int? BorrowerId { get; set; }
        public virtual Customer Borrower { get; set; }
    }
}