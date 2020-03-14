// o nome do ficheiro deve ser SalesRecord+"s"+"Controller" - é o padrão do framework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        // foi criada uma sub-pasta "SalesRecords" na pasta Views que trabalhará com este controller

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}