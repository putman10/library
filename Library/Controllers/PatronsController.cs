using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class PatronsController : Controller
    {
        [HttpGet("/patrons/new")]
        public IActionResult NewForm()
        {
            return View();
        }

        [HttpPost("/patrons/new")]
        public IActionResult NewPatron(string name)
        {
            Patron newPatron = new Patron(name);
            newPatron.Save();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("/patrons/{id}/details")]
        public IActionResult DetailsRoute(int id)
        {
            return RedirectToAction("Details");
        }

        [HttpGet("/patrons/{id}/details")]
        public IActionResult Details(int id)
        {
            List<object> model = new List<object>() {Book.PatronsCheckedOutBooks(id), Patron.Find(id) };
            return View(model);
        }

        [HttpGet("/patrons/{id}/checkout")]
        public IActionResult AvailableBooks(int id)
        {
            List<Book> books = Book.AvailableBooks();
            List<object> model = new List<object>() { id, books };
            return View(model);
        }

        [HttpPost("/patrons/{id}/{bookId}/checkout")]
        public IActionResult CheckoutBook(int id, int bookId)
        {

            int copyId = Checkout.Find(bookId);
            DateTime checkoutDate = DateTime.Now;
            Checkout newCheckout = new Checkout(id, copyId, checkoutDate);
            newCheckout.Save();
            return RedirectToAction("Details");
        }

        [HttpPost("/patrons/{id}/delete")]
        public IActionResult DeletePatron(int id)
        {
            Patron.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet("librarian/all-patrons")]
        public IActionResult Index()
        {
            return View(Patron.GetAll());
        }
    }
}
