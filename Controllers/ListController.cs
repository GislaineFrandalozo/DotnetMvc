using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetMvc.Data;
using DotnetMvc.Models;

namespace DotnetMvc.Controllers
{
    public class ListController : Controller
    {
        private readonly DotnetMvcContext _context;

        public ListController(DotnetMvcContext context)
        {
            _context = context;
        }

        // GET: List
        public async Task<IActionResult> Index()
        {
              return _context.ListModel != null ? 
                          View(await _context.ListModel.ToListAsync()) :
                          Problem("Entity set 'DotnetMvcContext.ListModel'  is null.");
        }

        // GET: List/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListModel == null)
            {
                return NotFound();
            }

            var listModel = await _context.ListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        // GET: List/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: List/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,ReleaseDate")] ListModel listModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listModel);
        }

        // GET: List/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListModel == null)
            {
                return NotFound();
            }

            var listModel = await _context.ListModel.FindAsync(id);
            if (listModel == null)
            {
                return NotFound();
            }
            return View(listModel);
        }

        // POST: List/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,ReleaseDate")] ListModel listModel)
        {
            if (id != listModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListModelExists(listModel.Id))
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
            return View(listModel);
        }

        // GET: List/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListModel == null)
            {
                return NotFound();
            }

            var listModel = await _context.ListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listModel == null)
            {
                return NotFound();
            }

            return View(listModel);
        }

        // POST: List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListModel == null)
            {
                return Problem("Entity set 'DotnetMvcContext.ListModel'  is null.");
            }
            var listModel = await _context.ListModel.FindAsync(id);
            if (listModel != null)
            {
                _context.ListModel.Remove(listModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListModelExists(int id)
        {
          return (_context.ListModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
