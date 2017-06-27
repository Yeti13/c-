using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TimeDisplay.Controllers{

    public class TimeController : Controller{

        [HttpGet]
        [Route("index")]
        public IActionResult Index(){
            DateTime dateTime = DateTime.Now;
            ViewBag.dt = dateTime;
            return View("index");
        }
    }
}