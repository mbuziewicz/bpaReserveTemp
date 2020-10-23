using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DeleteModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.RestaurantID == id);

            if (Restaurant == null)
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

            Restaurant = await _context.Restaurant.FindAsync(id);

            if (Restaurant != null)
            {
                _context.Restaurant.Remove(Restaurant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
