using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPrikol.Models;
using WebPrikol.Validation;

namespace WebPrikol.Controllers
{
    public class UserDtoesController : Controller
    {
        private readonly Context _context;
        private readonly PhoneNumberValidation _validation;

        public UserDtoesController(Context context)
        {
            _context = context;
        }

        // GET: UserDtoes
        public async Task<IActionResult> Index()
        {
              return _context.UserDto != null ? 
                          View(await _context.UserDto.ToListAsync()) :
                          Problem("Entity set 'Context.UserDto'  is null.");
        }

        // GET: UserDtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserDto == null)
            {
                return NotFound();
            }

            var userDto = await _context.UserDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDto == null)
            {
                return NotFound();
            }

            return View(userDto);
        }

        // GET: UserDtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,PhoneNumber")] UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // GET: UserDtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDto == null)
            {
                return NotFound();
            }

            var userDto = await _context.UserDto.FindAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return View(userDto);
        }

        // POST: UserDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,UserName,Password,PhoneNumber")] UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDtoExists(userDto.Id))
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
            return View(userDto);
        }

        // GET: UserDtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserDto == null)
            {
                return NotFound();
            }

            var userDto = await _context.UserDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDto == null)
            {
                return NotFound();
            }

            return View(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostBuyer(UserDto buyer)
        {
            if (!_validation.IsValid(buyer.PhoneNumber))
            {

                // return ("Error - Саня пидорас"); 
                return NotFound();
            }
            _context.UserDto.Add(buyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyer", new { id = buyer.Id }, buyer);
        }

        // POST: UserDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.UserDto == null)
            {
                return Problem("Entity set 'Context.UserDto'  is null.");
            }
            var userDto = await _context.UserDto.FindAsync(id);
            if (userDto != null)
            {
                _context.UserDto.Remove(userDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDtoExists(int? id)
        {
          return (_context.UserDto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
