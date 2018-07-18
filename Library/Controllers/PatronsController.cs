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
        [HttpGet("/patrons")]
        public IActionResult Index()
        {
            return View(Patron.GetAll());
        }

        [HttpGet("/patrons/new")]
        public IActionResult NewForm()
        {
            return View(Patron.GetAll());
        }

        [HttpPost("/patrons/new")]
        public IActionResult NewPatron(string name)
        {
            Patron newPatron = new Patron(name);
            newPatron.Save();
            return RedirectToAction("Index");
        }

        [HttpPost("/patrons/{id}/delete")]
        public IActionResult DeletePatron(int id)
        {
            Patron.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
