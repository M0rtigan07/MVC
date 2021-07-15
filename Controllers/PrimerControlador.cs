using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PrimerControlador : Controller
    {
        public string Index()
        {
            return "Esto es el index";
        }
        public string Hola(string nombre, int edad)
        {
            return HtmlEncoder.Default.Encode( $"Hola {nombre} tu edad es {edad}");
        }
    }
}
