using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojodachi.Controllers{

    public class DojodachiController : Controller{

        [HttpGet]
        [Route("")]

        public IActionResult Index(int fullState = 20, int happyState = 20, int energyState = 50, int mealState = 3){
            if(HttpContext.Session == null){
            HttpContext.Session.SetInt32("Fullness", 20);
            HttpContext.Session.SetInt32("Happiness", 20);
            HttpContext.Session.SetInt32("Energy", 50); 
            HttpContext.Session.SetInt32("Meals", 3);
            }
            ViewBag.message = TempData["Message"];
            ViewBag.Fullness = fullState;
            ViewBag.Happiness = happyState;
            ViewBag.Energy = energyState;
            ViewBag.Meals = mealState;
            return View("index");
        }

        [HttpPost]
        [Route("interact")]

        public IActionResult Interact(string action){
            System.Console.WriteLine(action);
            string message = "Go ahead, have fun with your Dachi!";
            Random rand = new Random();
            int fullState = (int)HttpContext.Session.GetInt32("Fullness");
            int happyState = (int)HttpContext.Session.GetInt32("Happiness");
            int energyState = (int)HttpContext.Session.GetInt32("Energy");
            int mealState = (int)HttpContext.Session.GetInt32("Meals");
            switch(action){
                case "feed":
                    if(mealState > 0){
                        HttpContext.Session.SetInt32("Meals", mealState - 1);
                        HttpContext.Session.SetInt32("Fullness", fullState + rand.Next(5,10));
                    }
                    else{
                        message = "You don't have enough food!";
                    }
                    break;
                case "play":
                    if(energyState >= 5){
                        HttpContext.Session.SetInt32("Energy", energyState - 5);
                        HttpContext.Session.SetInt32("Happiness", happyState + rand.Next(5,10));
                    }
                    else{
                        message = "Your dachi is too tired to play.";
                    }
                    break;
                case "work":
                    if(energyState >= 5){
                        HttpContext.Session.SetInt32("Energy", energyState - 5);
                        HttpContext.Session.SetInt32("Meals", mealState + rand.Next(1,3));
                    }
                    else{
                        message = "Your dachi is too tired to work.";
                    }
                    break;
                case "sleep":
                    HttpContext.Session.SetInt32("Energy", energyState + 15);
                    HttpContext.Session.SetInt32("Happiness", happyState - 5);
                    HttpContext.Session.SetInt32("Fullness", fullState - 5);
                    message = "Shh, your dachi is sleeping.";
                    break;
            }
            TempData["Message"] = message;
            return Redirect("");
        }
    }
}