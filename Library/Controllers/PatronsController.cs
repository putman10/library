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
        [HttpGet("librarian/all-patrons")]
        public IActionResult Index()
        {
            return View(Patron.GetAll());
        }

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
            return RedirectToAction("Home", "Index");
        }

        [HttpPost("/patrons/{id}/details")]
        public IActionResult DetailsRoute(int patron)
        {
            return RedirectToAction("Details");
        }

        [HttpGet("/patrons/{id}/details")]
        public IActionResult Details(int patron)
        {
            return View(Book.PatronsCheckedOutBooks(patron));
        }

        [HttpPost("/patrons/{id}/delete")]
        public IActionResult DeletePatron(int id)
        {
            Patron.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
