using LibraryMangement.Data.Repository.Interfaces;
using LibraryMangement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace LibraryMangement.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }


        public IActionResult Index()
        {

            var bookWithNoBorrowr = _bookRepository.GetAllBooksWithAuthor(book=>book.BorrowerId == 0);

            return bookWithNoBorrowr.Any()?View(bookWithNoBorrowr):View("Empty");
        }

        public IActionResult LendBook(int id)
        {

            var lendBook = new LendViewModel
            {
                Book = _bookRepository.FindById(id),
                Customers = _customerRepository.FindAll()
            };
            return View(lendBook);
        }


        [HttpPost]
        public IActionResult LendBook(LendViewModel lendVm)
        {
            /*
             * we have to add that book to the list of borrowed books of the customer,and 
             */

            var book = _bookRepository.FindById(lendVm.Book.BookId);
            book.BorrowerId = lendVm.Book.BorrowerId;
            _bookRepository.Update(book);
            
            
            return RedirectToAction("Index");
        }
    }
}