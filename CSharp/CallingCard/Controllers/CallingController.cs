using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard.Controllers{

    public class CallingController : Controller{

        [HttpGet]
        [Route("index/{first_name}/{last_name}/{age}/{fav_color}")]
       
        public JsonResult Index(string first_name, string last_name, string age, string fav_color){
            var input = new{
                FirstName = first_name,
                LastName = last_name,
                age = age,
                fav_color = fav_color
            };
            
            return Json(input);
        }
    }
}