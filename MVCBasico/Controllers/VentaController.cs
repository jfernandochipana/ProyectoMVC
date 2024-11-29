using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using MVCBasico.Models;

namespace MVCBasico.Controllers
{
    public class VentaController : Controller
    {
        private readonly ElectronicaDatabaseContext _context;

        public VentaController(ElectronicaDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ventas.ToListAsync());
        }

        public IActionResult Confirmacion()
        {
            return View();
        }

        // POST: Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirmacion([Bind("VentaId,ClienteId,emailComprador,direccionEnvio,medioDePago,nombreTarjeta,numeroTarjeta,fechaVencimientoTarjeta,cvv,ProductoId")] Venta venta)
        {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

    }
}
