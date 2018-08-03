using System.Linq;
using LibraryMangement.Data.Repository.Interfaces;
using LibraryMangement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;


        public HomeController(IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            ICustomerRepository customerRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }
        
        
        public IActionResult Index()
        {
            var homeVm = new HomeViewModel
            {
                BookCount = _bookRepository.FindAll().Count(),
                LendBookCount = _bookRepository.GetAllBooksWithAuthorAndBorrowor(book=>book.BorrowerId != 0).Count(),
                AutherCount = _authorRepository.FindAll().Count(),
                CustomerCount = _customerRepository.FindAll().Count()
               
            };
            
            return View(homeVm);
        }
        
    }
}