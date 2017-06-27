using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers{

    public class SurveyController : Controller{

        [HttpGet]
        [Route("")]
        public IActionResult index(){
            return View("index");
        }

        [HttpPost]
        [Route("submit")]

        public IActionResult Submit(string name, string location, string language, string comment){
            return RedirectToAction("Display", new {name = name, location = location, language = language, comment = comment});
        }

        [HttpGet]
        [Route("display")]

        public IActionResult Display(string name, string location, string language, string comment){
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("display");
        }
    }
}