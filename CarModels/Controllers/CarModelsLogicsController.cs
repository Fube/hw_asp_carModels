﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarModels.Data;
using CarModels.Models;

namespace CarModels.Controllers
{
    public class CarModelsLogicsController : Controller
    {
        private readonly CarModelsContext _context;

        public CarModelsLogicsController(CarModelsContext context)
        {
            _context = context;
        }

        // GET: CarModelsLogics
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarModelsLogics.ToListAsync());
        }

        // GET: CarModelsLogics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModelsLogic = await _context.CarModelsLogics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModelsLogic == null)
            {
                return NotFound();
            }

            return View(carModelsLogic);
        }

        // GET: CarModelsLogics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarModelsLogics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Company,Released,Country,Color")] CarModelsLogic carModelsLogic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModelsLogic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carModelsLogic);
        }

        // GET: CarModelsLogics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModelsLogic = await _context.CarModelsLogics.FindAsync(id);
            if (carModelsLogic == null)
            {
                return NotFound();
            }
            return View(carModelsLogic);
        }

        // POST: CarModelsLogics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Company,Released,Country,Color")] CarModelsLogic carModelsLogic)
        {
            if (id != carModelsLogic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModelsLogic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelsLogicExists(carModelsLogic.Id))
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
            return View(carModelsLogic);
        }

        // GET: CarModelsLogics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModelsLogic = await _context.CarModelsLogics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModelsLogic == null)
            {
                return NotFound();
            }

            return View(carModelsLogic);
        }

        // POST: CarModelsLogics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModelsLogic = await _context.CarModelsLogics.FindAsync(id);
            _context.CarModelsLogics.Remove(carModelsLogic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelsLogicExists(int id)
        {
            return _context.CarModelsLogics.Any(e => e.Id == id);
        }
    }
}
