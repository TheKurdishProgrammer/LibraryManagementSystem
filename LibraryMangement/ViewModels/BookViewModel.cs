using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryMangement.Data.Models;

namespace LibraryMangement.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        
        public IEnumerable<Auther> Authers { get; set; }
    }
}