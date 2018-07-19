using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Diagnostics.Contracts;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet("/books/new")]
        public IActionResult NewForm()
        {
            return View(Author.GetAll());
        }

        [HttpPost("/books/new")]
        public IActionResult NewBook(string title, int qty, string[] authorFields, int[] authors)
        {
            
            Book newBook = new Book(title, 0, qty);
            newBook.Save();
            newBook.SaveCopies();
            int bookId = Book.FindLastAdded();
            Author.CreateBookAuthorPairing(bookId, authors);

            if (!(authorFields[0] == null))
            {
                int[] listOfNewAuthorIds = Author.SaveListOfAuthors(authorFields);
                Author.CreateBookAuthorPairing(bookId, listOfNewAuthorIds);
            }
            return RedirectToAction("LibrarianIndex");
        }


        [HttpGet("/librarian")]
        public IActionResult LibrarianIndex()
        {
            return View(Book.GetAll());
        }

        [HttpGet("/books/{id}/copies")]
        public IActionResult Copies(int id)
        {
            Contract.Ensures(Contract.Result<IActionResult>() != null);

            return View(Copy.GetAllOfOneBook(id));
        }

        [HttpPost("/books/{bookId}/{copyId}/delete")]
        public IActionResult DeleteCopy(int copyId, int bookId)
        {
            Copy.Delete(copyId);

            return RedirectToAction("Copies", new { id = bookId }); 
        }

        [HttpGet("/books/{id}/update")]
        public IActionResult UpdateForm(int id)
        {
            return View(Book.Find(id));
        }

        [HttpPost("/books/{id}/update")]
        public IActionResult UpdateBook(int id, string newName)
        {
            Book.Update(newName, id);
            return RedirectToAction("LibrarianIndex");
        }

    }
}
