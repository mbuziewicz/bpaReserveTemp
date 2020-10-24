using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;
using Microsoft.AspNetCore.Authorization;

namespace BpaReserve.Pages.Rides
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DeleteModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ride Ride { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ride = await _context.Ride.FirstOrDefaultAsync(m => m.RideID == id);

            if (Ride == null)
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

            Ride = await _context.Ride.FindAsync(id);

            if (Ride != null)
            {
                _context.Ride.Remove(Ride);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
