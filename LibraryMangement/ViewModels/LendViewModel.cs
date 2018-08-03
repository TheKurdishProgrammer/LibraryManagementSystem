using System.Collections.Generic;
using LibraryMangement.Data.Models;

namespace LibraryMangement.ViewModels
{
    public class LendViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Book Book { get; set; }
    }
}