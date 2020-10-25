using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.RestReserve
{
    public class DeleteModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DeleteModel(BpaReserve.Data.BpaReserveContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            restaurant_reservation = await _context.restaurant_reservation.FindAsync(id);

            if (restaurant_reservation != null)
            {
                _context.restaurant_reservation.Remove(restaurant_reservation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
