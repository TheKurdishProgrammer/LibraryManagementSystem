using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangement.Data.Models;

namespace LibraryMangement.ViewModels
{
    public class AuthorViewModel
    {
        public Auther Auther { get; set; }
        public int BookCount { get; set; }
    }
}
