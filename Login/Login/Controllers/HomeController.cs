using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Users = "lmonsalve22@gmail.com")]
        public string Saludo()
        {
            return "Hola";
        }


        public string Saludo2(int SerialDate = 32874)
        {
            //;
            //if (SerialDate > 59) SerialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            
            return new DateTime(1899, 12, 30).AddDays(SerialDate).ToString();
        }
    }
}