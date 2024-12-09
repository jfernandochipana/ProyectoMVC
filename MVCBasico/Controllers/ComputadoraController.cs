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
    public class ComputadoraController : Controller
    {
        private readonly ElectronicaDatabaseContext _context;

        public ComputadoraController(ElectronicaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Computadora
        public async Task<IActionResult> Index(int? clienteId)
        {
            if (clienteId != null)
            {
                var clienteBuscado = _context.Clientes.Find(clienteId);
                ViewBag.clienteId = clienteBuscado.Id;
                ViewBag.nombreCliente = clienteBuscado.Nombre;
                ViewBag.apellidoCliente = clienteBuscado.Apellido;
            }
            return View(await _context.Computadoras.ToListAsync());
        }

        // GET: Computadora/Details/5
        public async Task<IActionResult> Details(int? id, int? clienteId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadora = await _context.Computadoras
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (computadora == null)
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

            return View(computadora);
        }

        // GET: Computadora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computadora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,nombre,precio,stock,procesador,memoriaRam,lectorDisco")] Computadora computadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computadora);
        }

        // GET: Computadora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadora = await _context.Computadoras.FindAsync(id);
            if (computadora == null)
            {
                return NotFound();
            }
            return View(computadora);
        }

        // POST: Computadora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,nombre,precio,stock,procesador,memoriaRam,lectorDisco")] Computadora computadora)
        {
            if (id != computadora.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputadoraExists(computadora.ProductoId))
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
            return View(computadora);
        }

        // GET: Computadora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computadora = await _context.Computadoras
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (computadora == null)
            {
                return NotFound();
            }

            return View(computadora);
        }

        // POST: Computadora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computadora = await _context.Computadoras.FindAsync(id);
            if (computadora != null)
            {
                _context.Computadoras.Remove(computadora);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputadoraExists(int id)
        {
            return _context.Computadoras.Any(e => e.ProductoId == id);
        }
    }
}
