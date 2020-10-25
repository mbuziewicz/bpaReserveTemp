using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BpaReserve.Data;
using Bpa_Test_2.Models;
using System.Security.Claims;

namespace BpaReserve.Pages.RestReserve
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

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            System.Diagnostics.Debug.WriteLine("Userid:{0}", currentUserID);

            ViewData["currentUserID"] = currentUserID;
            ViewData["UserID"] = currentUserID;
            ViewData["RestaurantID"] = new SelectList(_context.Restaurant, "RestaurantID", "RestaurantID");
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
