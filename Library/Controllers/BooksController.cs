using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet("/books")]
        public IActionResult Index()
        {
            return View(Book.GetAll());
        }

        [HttpGet("/books/new")]
        public IActionResult NewForm()
        {
            return View();
        }

        [HttpPost("/books/new")]
        public IActionResult NewBook(string title, int qty)
        {
            Book newBook = new Book(title, qty);
            newBook.Save();
            newBook.SaveCopies();
            return RedirectToAction("Index");
        }

        [HttpGet("/books/{id}/available")]
        public IActionResult AvailableBooks(int id)
        {
            List<Book> books = Book.AvailableBooks();
            List<object> model = new List<object>() { id, books};
            return View(model);
        }

        [HttpPost("/checkout/{id}/{bookId}/addnew")]
        public IActionResult CheckoutBook(int id, int bookId)
        {
            //int copyId = 15;
            int copyId = Checkout.Find(bookId);
            DateTime checkoutDate = DateTime.Now;
            Checkout newCheckout = new Checkout(id, copyId, checkoutDate);
            newCheckout.Save();
            return RedirectToAction("Index");
        }
    }
}
