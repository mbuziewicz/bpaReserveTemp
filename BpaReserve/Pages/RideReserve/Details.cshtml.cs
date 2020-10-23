using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.RideReserve
{
    public class DetailsModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DetailsModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
