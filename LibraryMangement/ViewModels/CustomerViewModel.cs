using LibraryMangement.Data.Models;

namespace LibraryMangement.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer{ get; set; }
        public int BookCount { get; set; }
    }
}