using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.RideReserve
{
    public class EditModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public EditModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RideReservation RideReservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RideReservation = await _context.RideReservation
                .Include(r => r.Ride)
                .Include(r => r.user).FirstOrDefaultAsync(m => m.ID == id);

            if (RideReservation == null)
            {
                return NotFound();
            }
           ViewData["RideID"] = new SelectList(_context.Ride, "ID", "ID");
           ViewData["UserID"] = new SelectList(_context.user, "UserID", "UserID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RideReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideReservationExists(RideReservation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RideReservationExists(int id)
        {
            return _context.RideReservation.Any(e => e.ID == id);
        }
    }
}
