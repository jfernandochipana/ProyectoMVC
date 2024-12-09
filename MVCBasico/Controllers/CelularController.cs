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
    public class CelularController : Controller
    {
        private readonly ElectronicaDatabaseContext _context;

        public CelularController(ElectronicaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Celular
        public async Task<IActionResult> Index(int? clienteId)
        {
            if (clienteId != null)
            {
                var clienteBuscado = _context.Clientes.Find(clienteId);
                ViewBag.clienteId = clienteBuscado.Id;
                ViewBag.nombreCliente = clienteBuscado.Nombre;
                ViewBag.apellidoCliente = clienteBuscado.Apellido;
            }
            return View(await _context.Celulares.ToListAsync());
        }

        // GET: Celular/Details/5
        public async Task<IActionResult> Details(int? id, int? clienteId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celulares
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (celular == null)
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

            return View(celular);
        }

        // GET: Celular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Celular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,nombre,precio,stock,procesador,memoriaRam")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celular);
        }

        // GET: Celular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celulares.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }
            return View(celular);
        }

        // POST: Celular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,nombre,precio,stock,procesador,memoriaRam")] Celular celular)
        {
            if (id != celular.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularExists(celular.ProductoId))
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
            return View(celular);
        }

        // GET: Celular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celulares
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // POST: Celular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celular = await _context.Celulares.FindAsync(id);
            if (celular != null)
            {
                _context.Celulares.Remove(celular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularExists(int id)
        {
            return _context.Celulares.Any(e => e.ProductoId == id);
        }
    }
}
