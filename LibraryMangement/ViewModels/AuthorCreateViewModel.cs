using LibraryMangement.Controllers;
using LibraryMangement.Data.Models;

namespace LibraryMangement.ViewModels
{
    public class AuthorCreateViewModel
    {

        public Auther Auther { get; set; }
        public string Refere { get; set; }
        public int From { get; set; }
    }
}