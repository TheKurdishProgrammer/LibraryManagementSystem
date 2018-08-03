using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangement.Data.Models;
using LibraryMangement.Data.Repository.Interfaces;
using LibraryMangement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;


namespace LibraryMangement.Controllers
{
    
   public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository,IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }


        public IActionResult Index()
        {
            var customerVm = new List<CustomerViewModel>();

            var customers = _customerRepository.FindAll().ToList();
            
            
            if (customers.Count == 0)
                return View("Empty");

            foreach (var customer in customers)
            {
                customerVm.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Count(book=>book.BorrowerId == customer.CustomerId)
              
                });
            }

            return View(customerVm);


        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
                  return View();
                        
            
            _customerRepository.Create(customer);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
           
           
            if (!ModelState.IsValid)
                return View(customer);



            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)

        {
            var customer = _customerRepository.FindById(id);
            if (customer == null)
                return NotFound();
            
            return View(customer);
        }

        public IActionResult Delete(int id)
        {

            var customer = _customerRepository.FindById(id);
            _customerRepository.Delete(customer);

            return RedirectToAction("Index");
        }
    }
}
