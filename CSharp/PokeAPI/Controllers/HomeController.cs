using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace PokeAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            ViewBag.name = TempData["name"];
            ViewBag.height = TempData["height"];
            ViewBag.weight = TempData["weight"];
            ViewBag.types = TempData["types"];
            ViewBag.img = TempData["img"];
            return View();
        }

        [HttpGet]
        [Route("pokemon")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();

            var type = PokeInfo["types"] as JArray;
            var images = PokeInfo["sprites"] as JObject;

            string img = (string)images["front_default"];

            List<string> typeList = new List<string>();
            
            for(int idx = 0; idx < type.Count; idx++){
                typeList.Add((string)type[idx]["type"]["name"]);
            }
            
            TempData["name"] = PokeInfo["name"];
            TempData["height"] = PokeInfo["height"];
            TempData["weight"] = PokeInfo["weight"];
            TempData["types"] = typeList;
            TempData["img"] = img;
            
            return RedirectToAction("Index");
        }

    }
}
