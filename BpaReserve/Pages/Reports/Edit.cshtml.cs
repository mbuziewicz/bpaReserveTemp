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

namespace BpaReserve.Pages.RestReserve
{
    public class EditReportModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public EditReportModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public restaurant_reservation restaurant_reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            restaurant_reservation = await _context.restaurant_reservation
                .Include(r => r.Restaurant).FirstOrDefaultAsync(m => m.ID == id);

            if (restaurant_reservation == null)
            {
                return NotFound();
            }
           ViewData["RestaurantID"] = new SelectList(_context.Restaurant, "RestaurantID", "RestaurantID");
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

            _context.Attach(restaurant_reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!restaurant_reservationExists(restaurant_reservation.ID))
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

        private bool restaurant_reservationExists(int id)
        {
            return _context.restaurant_reservation.Any(e => e.ID == id);
        }
    }
}
