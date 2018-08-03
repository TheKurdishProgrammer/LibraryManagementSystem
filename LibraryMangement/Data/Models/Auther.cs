using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMangement.Data.Models
{
    public class Auther
    {
        public int AutherId { get; set; }
        
        [Required,MaxLength(30),MinLength(5)]
        public string AutherName { get; set; }

        public ICollection<Book> Books { get; set; }
        
    }
}
