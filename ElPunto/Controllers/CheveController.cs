using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElPunto.Models;

namespace ElPunto.Controllers
{
    public class CheveController : Controller
    {
        private readonly CrudBlazorContext _context;

        public CheveController(CrudBlazorContext context)
        {
            _context = context;
        }

        // GET: Cheve
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cheve.ToListAsync());
        }

        // GET: Cheve/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheve = await _context.Cheve
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheve == null)
            {
                return NotFound();
            }

            return View(cheve);
        }

        // GET: Cheve/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cheve/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Marca")] Cheve cheve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cheve);
        }

        // GET: Cheve/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheve = await _context.Cheve.FindAsync(id);
            if (cheve == null)
            {
                return NotFound();
            }
            return View(cheve);
        }

        // POST: Cheve/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Marca")] Cheve cheve)
        {
            if (id != cheve.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheveExists(cheve.Id))
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
            return View(cheve);
        }

        // GET: Cheve/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheve = await _context.Cheve
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheve == null)
            {
                return NotFound();
            }

            return View(cheve);
        }

        // POST: Cheve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheve = await _context.Cheve.FindAsync(id);
            _context.Cheve.Remove(cheve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheveExists(int id)
        {
            return _context.Cheve.Any(e => e.Id == id);
        }
    }
}
