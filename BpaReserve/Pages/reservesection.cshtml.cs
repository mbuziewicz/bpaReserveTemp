using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BpaReserve.Data;
using Bpa_Test_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BpaReserve.Pages
{
    [Authorize]
    public class RestReserveEdit2Model : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public RestReserveEdit2Model(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public restaurant_reservation restaurant_reservation { get; set; }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGet(int? RestaurantId, int? UserId)
        {
            Restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.RestaurantID == RestaurantId);

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //System.Diagnostics.Debug.WriteLine("Userid:{0}", currentUserID);

            ViewData["currentUserID"] = currentUserID;
            ViewData["RestaurantID"] = RestaurantId;
            ViewData["UserID"] = currentUserID;
            ViewData["RestaurantName"] = Restaurant.RestaurantName;
            ViewData["RestaurantImageUrl"] = Restaurant.RestaurantImageUrl;
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

            _context.restaurant_reservation.Add(restaurant_reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
