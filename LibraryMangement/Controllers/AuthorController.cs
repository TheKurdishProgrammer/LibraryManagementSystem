using System;
using System.Linq;
using LibraryMangement.Data.Models;
using LibraryMangement.Data.Repository.Interfaces;
using LibraryMangement.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryMangement.Controllers
{
    public class AuthorController : Controller
    {

        public  const int REFERE_BOOK = 1;
        public  const int REFERE_AUTHOR = 2;
        private readonly IAuthorRepository _authorRepository;


        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

      
        
        // GET: /<controller>/
        public IActionResult Index(int? refere)
        {
            
            
            var authors = _authorRepository.GetAllAuthersWithBooks();
            return !authors.Any() ? View("Empty") : View(authors);
        }

        [HttpPost]
        public IActionResult Edit(Auther auther)
        {

            if (!ModelState.IsValid)
                return View(auther);

            _authorRepository.Update(auther);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
         
            var author = _authorRepository.GetAutherWithBooks(id);

            if (author == null)
                return NotFound();

            
            return View(author);
        }

        public IActionResult Delete(int id)
        {

            var auther = _authorRepository.GetAutherWithBooks(id);
            _authorRepository.Delete(auther);

            return RedirectToAction("Index");
        }

        public IActionResult Create(int? from)
        {
            
            
            var authorCreateViewModel = new AuthorCreateViewModel {Refere = Request.Headers["Referer"].ToString()};
            if (from != null)
                authorCreateViewModel.From =1;
            
            return View(authorCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel authorVm)
        {
            if (!ModelState.IsValid)
                return View();
            
            _authorRepository.Create(authorVm.Auther);

            if (!string.IsNullOrEmpty(authorVm.Refere))
                return Redirect(authorVm.Refere);
            
            return RedirectToAction("Index");
        }
    }
}