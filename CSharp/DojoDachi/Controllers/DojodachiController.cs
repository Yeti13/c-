using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojodachi.Controllers{

    public class DojodachiController : Controller{

        [HttpGet]
        [Route("")]

        public IActionResult Index(){
            if(HttpContext.Session.GetInt32("Fullness") == null){
            HttpContext.Session.SetInt32("Fullness", 20);
            HttpContext.Session.SetInt32("Happiness", 20);
            HttpContext.Session.SetInt32("Energy", 50); 
            HttpContext.Session.SetInt32("Meals", 3);
            }

            ViewBag.message = TempData["Message"];
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");

            if( HttpContext.Session.GetInt32("Fullness") < 1 || HttpContext.Session.GetInt32("Happiness") < 1){
                ViewBag.message = "Your Dachi has Died a slow, horrible death!";
                ViewBag.loss = true;
            }

            return View("index");
        }

        [HttpPost]
        [Route("interact")]

        public IActionResult Interact(string action){
            System.Console.WriteLine(action);
            string message = "";
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/reset")]

        public IActionResult Reset(){

            HttpContext.Session.Clear();
            
            return RedirectToAction("Index");
        }
    }
}