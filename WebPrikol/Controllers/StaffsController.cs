﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPrikol.Models;

namespace WebPrikol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly WebPrikolContext _context;

        public StaffsController(WebPrikolContext context)
        {
            _context = context;
        }

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _context.Staffs.ToListAsync();
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(Guid id)
        {
            var staff = await _context.Staffs.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(Guid id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.Id }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(Guid id)
        {
            return _context.Staffs.Any(e => e.Id == id);
        }
    }
}
