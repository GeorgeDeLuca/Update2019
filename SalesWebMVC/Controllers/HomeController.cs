using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.ViewModes;

namespace SalesWebMVC.Controllers
{
    // o .Net é baseado em nomes, entao, o controlador HomeController, será a pagina home
    public class HomeController : Controller
    {
        // o nome do metodo é mapeado nas acoes
        public IActionResult Index()
        {
            // IActionResult é um tipo genérico

            // este metodo é a acao padrao
            return View();  // View é do tipo ViewResult
        }

        public IActionResult About()
        {
            // este metodo está ligado ao ficheiro About.cshtml
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = "Salles web MVC App from C# Course";
            ViewData["Professor"] = "George De Luca";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
