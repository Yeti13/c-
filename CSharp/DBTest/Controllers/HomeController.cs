using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DBTest;

namespace DBTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];
            ViewBag.name = TempData["name"];
            ViewBag.population = TempData["population"];
            ViewBag.continent = TempData["continent"];

            return View();
        }

        [HttpPost]
        [Route("/search")]

        public IActionResult GetCountries(string countryName){

            List<Dictionary<string,object>> allCountries = DbConnector.Query($"SELECT * FROM countries where name = '{countryName}'");

            if (allCountries.Count < 1){
                string message = "I'm sorry I can't seem to find that.  Please check your spelling and try again.";
                TempData["message"] = message;

                return RedirectToAction("Index");             
            }

            TempData["name"] = allCountries[0]["name"];
            TempData["population"] = allCountries[0]["population"];
            TempData["continent"] = allCountries[0]["continent"];

            return RedirectToAction("Index");
        }
    }
}
