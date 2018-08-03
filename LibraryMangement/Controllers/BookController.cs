using System.Collections.Generic;
using System.Linq;
using LibraryMangement.Data.Models;
using LibraryMangement.Data.Repository.Interfaces;
using LibraryMangement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangement.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;

            _authorRepository = authorRepository;
        }


        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooksWithAuthor();

            return books.Any()?View(books):View("Empty");
        }


        public IActionResult BorrowedBooks(int customerId)
        {
            var books = _bookRepository.GetAllBooksWithAuthor(b => b.BorrowerId == customerId);

            return View("Index", books);
        }


        public IActionResult AuthorBooks(int id)
        {
            var books = _bookRepository.GetAllBooksWithAuthor(b => b.Auther.AutherId == id);

            return View("Index", books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookViewModel bookVm)
        {
            if (!ModelState.IsValid)
            {
                bookVm.Authers = _authorRepository.GetAllAuthersWithBooks();
                return View(bookVm);
            }

            _bookRepository.Update(bookVm.Book);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Book book = _bookRepository.GetAllBooksWithAuthor(a => a.BookId == id).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            var bookVm = new BookViewModel
            {
                Book = book,
                Authers = _authorRepository.FindAll()
            };

            return View(bookVm);


//            var book = _bookRepository.GetAllBooksWithAuthor(b => b.BookId == id).FirstOrDefault();
////            var book = _bookRepository.FindById(id);
//
//            var bookVm = new BookViewModel
//            {
//                Book = book,
//                Authers = _authorRepository.FindAll()
//            };
//            return View(bookVm);
        }

        public IActionResult Delete(int id)
        {
            var book = _bookRepository.FindById(id);
            _bookRepository.Delete(book);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var bookVm = new BookViewModel
            {
                Authers = _authorRepository.GetAllAuthersWithBooks(),
                Book = new Book()
            };
            return View(bookVm);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid || bookViewModel.Book == null)
            {
                bookViewModel.Authers = _authorRepository.FindAll();
                return View(bookViewModel);
            }


            _bookRepository.Create(bookViewModel.Book);
            return RedirectToAction("Index");
        }
    }
}