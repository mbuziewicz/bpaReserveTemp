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
    public class DetailsModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DetailsModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

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
    }
}
