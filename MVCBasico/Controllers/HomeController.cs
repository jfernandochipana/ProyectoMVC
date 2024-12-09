using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using MVCBasico.Models;
using System.Diagnostics;

namespace MVCBasico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ElectronicaDatabaseContext _context; //para mostrar cliente en carrito

        public HomeController(ILogger<HomeController> logger, ElectronicaDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("MostrarClientes", "Cliente");
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

        public IActionResult Pagar(int id, string nombre, double precio, int clienteId)
        {
            //var producto = new Auricular { nombre = nombre, precio = precio };
            ViewBag.Id = id;
            ViewBag.Nombre = nombre;
            ViewBag.Precio = precio;
            //ViewBag.clienteId = clienteId;

            if (clienteId != null)
            {
                var clienteBuscado = _context.Clientes.Find(clienteId);
                ViewBag.clienteId = clienteBuscado.Id;
                ViewBag.nombreCliente = clienteBuscado.Nombre;
                ViewBag.apellidoCliente = clienteBuscado.Apellido;
            }

            // retorna una vista e indico el nombre de la vista
            return View("Carrito");
        }

        public IActionResult RecibirCliente(int clienteId)
        {
            ViewBag.clienteId = clienteId;
            return View();
        }

    }
}
