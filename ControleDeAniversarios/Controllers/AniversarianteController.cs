using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeAniversarios.Data;
using ControleDeAniversarios.Models;

namespace ControleDeAniversarios.Controllers
{
    public class AniversarianteController : Controller
    {
        private readonly BancoContext _context;

        public AniversarianteController(BancoContext context)
        {
            _context = context;
        }

        // GET: Aniversariante
        public async Task<IActionResult> Index()
        {
              return View(await _context.Aniversariante.ToListAsync());
        }

        // GET: Aniversariante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aniversariante == null)
            {
                return NotFound();
            }

            var aniversarianteModel = await _context.Aniversariante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aniversarianteModel == null)
            {
                return NotFound();
            }

            return View(aniversarianteModel);
        }

        // GET: Aniversariante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aniversariante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Data")] AniversarianteModel aniversarianteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aniversarianteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aniversarianteModel);
        }

        // GET: Aniversariante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aniversariante == null)
            {
                return NotFound();
            }

            var aniversarianteModel = await _context.Aniversariante.FindAsync(id);
            if (aniversarianteModel == null)
            {
                return NotFound();
            }
            return View(aniversarianteModel);
        }

        // POST: Aniversariante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Data")] AniversarianteModel aniversarianteModel)
        {
            if (id != aniversarianteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aniversarianteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AniversarianteModelExists(aniversarianteModel.Id))
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
            return View(aniversarianteModel);
        }

        // GET: Aniversariante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aniversariante == null)
            {
                return NotFound();
            }

            var aniversarianteModel = await _context.Aniversariante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aniversarianteModel == null)
            {
                return NotFound();
            }

            return View(aniversarianteModel);
        }

        // POST: Aniversariante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aniversariante == null)
            {
                return Problem("Entity set 'BancoContext.Aniversariante'  is null.");
            }
            var aniversarianteModel = await _context.Aniversariante.FindAsync(id);
            if (aniversarianteModel != null)
            {
                _context.Aniversariante.Remove(aniversarianteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AniversarianteModelExists(int id)
        {
          return _context.Aniversariante.Any(e => e.Id == id);
        }
    }
}
