using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPrikol.Models;

namespace WebPrikol.Controllers
{
    public class BasketsController : Controller
    {
        private readonly Context _context;

        public BasketsController(Context context)
        {
            _context = context;
        }

        // GET: Baskets
        public async Task<IActionResult> Index()
        {
            var context = _context.Baskets.Include(b => b.Product).Include(b => b.User);
            return View(await context.ToListAsync());
        }

        // GET: Baskets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Baskets == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets
                .Include(b => b.Product)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Baskets/Create
        public IActionResult Create()
        {
            ViewData["ProductsForeiginKey"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["UserForeiginKey"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductsForeiginKey,UserForeiginKey,PriceSumming")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductsForeiginKey"] = new SelectList(_context.Products, "Id", "Id", basket.ProductsForeiginKey);
            ViewData["UserForeiginKey"] = new SelectList(_context.Users, "Id", "Id", basket.UserForeiginKey);
            return View(basket);
        }

        // GET: Baskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Baskets == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            ViewData["ProductsForeiginKey"] = new SelectList(_context.Products, "Id", "Id", basket.ProductsForeiginKey);
            ViewData["UserForeiginKey"] = new SelectList(_context.Users, "Id", "Id", basket.UserForeiginKey);
            return View(basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,ProductsForeiginKey,UserForeiginKey,PriceSumming")] Basket basket)
        {
            if (id != basket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketExists(basket.Id))
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
            ViewData["ProductsForeiginKey"] = new SelectList(_context.Products, "Id", "Id", basket.ProductsForeiginKey);
            ViewData["UserForeiginKey"] = new SelectList(_context.Users, "Id", "Id", basket.UserForeiginKey);
            return View(basket);
        }

        // GET: Baskets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Baskets == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets
                .Include(b => b.Product)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Baskets == null)
            {
                return Problem("Entity set 'Context.Baskets'  is null.");
            }
            var basket = await _context.Baskets.FindAsync(id);
            if (basket != null)
            {
                _context.Baskets.Remove(basket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketExists(int? id)
        {
          return (_context.Baskets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
