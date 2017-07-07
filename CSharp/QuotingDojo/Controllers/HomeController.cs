using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/quote")]

        public IActionResult AddQuote(string name, string quote){
            System.Console.WriteLine("*****");
            System.Console.WriteLine(name);
            System.Console.WriteLine(quote);
            System.Console.WriteLine("*****");
            string userAdd = $"INSERT INTO users (name, created_at, updated_at) VALUES ('{name}', NOW(), NOW())";
            string userID = $"SELECT id FROM users WHERE name = '{name}'";
            DbConnector.Execute(userAdd);
            var id = DbConnector.Query(userID);
            string quoteAdd = $"INSERT INTO quotes (quote, user_id, created_at, updated_at) VALUES ('{quote}', '{id[0]["id"]}', NOW(), NOW())";
            DbConnector.Execute(quoteAdd);
            return RedirectToAction("DisplayQuotes");
        }

        [HttpGet]
        [Route("/quote")]

        public IActionResult DisplayQuotes(){
            string display = "SELECT name, quote FROM users, quotes WHERE user_id = users.id";
            var allQuotes = DbConnector.Query(display);
            ViewBag.quotes = allQuotes;
            ViewBag.count = allQuotes.Count;
            return View("quotes");
        }
    }
}
