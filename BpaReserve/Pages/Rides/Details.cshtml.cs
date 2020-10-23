using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.Rides
{
    public class DetailsModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DetailsModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

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
    }
}
