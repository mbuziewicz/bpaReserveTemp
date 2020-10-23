using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.RideReserve
{
    public class CreateModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public CreateModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RideID"] = new SelectList(_context.Ride, "RideID", "RideID");
        ViewData["UserID"] = new SelectList(_context.user, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public RideReservation RideReservation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RideReservation.Add(RideReservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
