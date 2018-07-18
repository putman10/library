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
    }
}
