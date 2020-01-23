﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillBucket.Models;

namespace BillBucket.Controllers
{
    public class PrestationsController : Controller
    {
        private readonly BillBucketContext _context;

        public PrestationsController(BillBucketContext context)
        {
            _context = context;
        }

        // GET: Prestations
        public async Task<IActionResult> Index()
        {
            var billBucketContext = _context.Prestations.Include(p => p.Facture);
            return View(await billBucketContext.ToListAsync());
        }

        // GET: Prestations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestation = await _context.Prestations
                .Include(p => p.Facture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestation == null)
            {
                return NotFound();
            }

            return View(prestation);
        }

        // GET: Prestations/Create
        public IActionResult Create(Guid idFacture)
        {
            var prestation = new Prestation()
            {
                IdFacture = idFacture
            };
            //ViewBag.ListPrestations = _context.Prestations.Where(c => c.IdFacture == prestation.IdFacture);

            return View(prestation);
        }

        // POST: Prestations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Montant,Description,IdFacture")] Prestation prestation)
        {
            if (ModelState.IsValid)
            {
                prestation.Id = Guid.NewGuid();
                _context.Add(prestation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Factures", new { id = prestation.IdFacture });
            }
            ViewData["IdFacture"] = new SelectList(_context.Factures, "Id", "Id", prestation.IdFacture);
            return View(prestation);
        }



        // GET: Prestations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestation = await _context.Prestations.FindAsync(id);
            if (prestation == null)
            {
                return NotFound();
            }
            ViewData["IdFacture"] = new SelectList(_context.Factures, "Id", "Id", prestation.IdFacture);
            return View(prestation);
        }

        // POST: Prestations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nom,Montant,Description,IdFacture")] Prestation prestation)
        {
            if (id != prestation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestationExists(prestation.Id))
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

            ViewData["IdFacture"] = new SelectList(_context.Factures, "Id", "Id", prestation.IdFacture);
            return View(prestation);
        }

        // GET: Prestations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestation = await _context.Prestations
                .Include(p => p.Facture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestation == null)
            {
                return NotFound();
            }

            return View(prestation);
        }

        // POST: Prestations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prestation = await _context.Prestations.FindAsync(id);
            _context.Prestations.Remove(prestation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestationExists(Guid id)
        {
            return _context.Prestations.Any(e => e.Id == id);
        }
    }
}
