using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using MVCBasico.Models;

namespace MVCBasico.Controllers
{
    public class AuricularController : Controller
    {
        private readonly ElectronicaDatabaseContext _context;

        public AuricularController(ElectronicaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Auricular
        //public async Task<IActionResult> Index(int? clienteId)
        //{
        //    ViewBag.clienteId = clienteId;
        //    return View(await _context.Auriculares.ToListAsync());
        //}
        public async Task<IActionResult> Index(int? clienteId)
        {
            if (clienteId != null)
            {
                var clienteBuscado = _context.Clientes.Find(clienteId);
                ViewBag.clienteId = clienteBuscado.Id;
                ViewBag.nombreCliente = clienteBuscado.Nombre;
                ViewBag.apellidoCliente = clienteBuscado.Apellido;
            }
            return View(await _context.Auriculares.ToListAsync());
        }

        // GET: Auricular/Details/5
        public async Task<IActionResult> Details(int? id, int? clienteId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auricular = await _context.Auriculares
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (auricular == null)
            {
                return NotFound();
            }

            if (clienteId != null)
            {
                var clienteBuscado = _context.Clientes.Find(clienteId);
                ViewBag.clienteId = clienteBuscado.Id;
                ViewBag.nombreCliente = clienteBuscado.Nombre;
                ViewBag.apellidoCliente = clienteBuscado.Apellido;
            }

            return View(auricular);
        }

        // GET: Auricular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auricular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,nombre,precio,stock,potenciaWatts")] Auricular auricular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auricular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auricular);
        }

        // GET: Auricular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auricular = await _context.Auriculares.FindAsync(id);
            if (auricular == null)
            {
                return NotFound();
            }
            return View(auricular);
        }

        // POST: Auricular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,nombre,precio,stock,potenciaWatts")] Auricular auricular)
        {
            if (id != auricular.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auricular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuricularExists(auricular.ProductoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(auricular);
        }

        // GET: Auricular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auricular = await _context.Auriculares
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (auricular == null)
            {
                return NotFound();
            }

            return View(auricular);
        }

        // POST: Auricular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auricular = await _context.Auriculares.FindAsync(id);
            if (auricular != null)
            {
                _context.Auriculares.Remove(auricular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuricularExists(int id)
        {
            return _context.Auriculares.Any(e => e.ProductoId == id);
        }

    }
}
