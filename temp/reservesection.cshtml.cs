using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.RestReserve
{
    public class CreateRestReserveModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public CreateRestReserveModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RestaurantID"] = new SelectList(_context.Restaurant, "RestaurantID", "RestaurantID");
            ViewData["UserID"] = new SelectList(_context.user, "UserID", "UserID");
            ViewData["DateAndTime"] = new SelectList(_context.user, "DateAndTime", "DateAndTime");
            return Page();
        }

        [BindProperty]
        public restaurant_reservation restaurant_reservation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.restaurant_reservation.Add(restaurant_reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
