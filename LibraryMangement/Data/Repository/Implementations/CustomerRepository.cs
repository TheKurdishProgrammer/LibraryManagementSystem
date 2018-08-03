using LibraryMangement.Data.Models;
using LibraryMangement.Data.Repository.Interfaces;

namespace LibraryMangement.Data.Repository.Implementations
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {

        public CustomerRepository(LibraryDbContext context):base(context)
        {

        }
        
        
    }
}
