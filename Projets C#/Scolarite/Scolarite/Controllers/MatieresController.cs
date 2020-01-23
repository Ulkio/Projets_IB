﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scolarite.Models;

namespace Scolarite.Controllers
{
    public class MatieresController : Controller
    {
        private readonly EcoleContext _context;

        public MatieresController(EcoleContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Notes(Guid? id, DateTime? date)
        {
            if (date == null) date = DateTime.Now;
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }
            ViewData["Date"] = date;
            ViewData["Eleves"] = _context.Eleves.ToList();
            return View(matiere);
        }






        // GET: Matieres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matieres.ToListAsync());
        }

        // GET: Matieres/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // GET: Matieres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                matiere.Id = Guid.NewGuid();
                _context.Add(matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nom")] Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(matiere.Id))
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
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var matiere = await _context.Matieres.FindAsync(id);
            _context.Matieres.Remove(matiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatiereExists(Guid id)
        {
            return _context.Matieres.Any(e => e.Id == id);
        }
    }
}
