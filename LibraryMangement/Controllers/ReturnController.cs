using System.Linq;
using LibraryMangement.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangement.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {

            var books = _bookRepository.GetAllBooksWithAuthorAndBorrowor(b=>b.BorrowerId != null);

            return books.Any() ? View(books) : View("Empty");
        }

        public IActionResult ReturnBook(int id)
        {

            var book = _bookRepository.FindById(id);
            book.Borrower = null;
            book.BorrowerId =0;
            _bookRepository.Update(book);
            
            return RedirectToAction("Index");
        }
    }
}