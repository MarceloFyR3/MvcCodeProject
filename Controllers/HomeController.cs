using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMvc.Models;

namespace ProjetoMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Este projeto é de uso público, o objetivo dele é testar funcionalidades com o VS Code. A fins de somar conhecimentos. ";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Página de Contato.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
