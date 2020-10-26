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
        public static string globalRestaurantUrl;
        public static string globalRestaurantName;
        public static int globalRestaurantID;
        public static string globalUserID;
        public async Task<IActionResult> OnGet(int? RestaurantId, int? UserId)
        {
            Restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.RestaurantID == RestaurantId);

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //System.Diagnostics.Debug.WriteLine("Userid:{0}", currentUserID);

            globalRestaurantUrl = Restaurant.RestaurantImageUrl;
            globalRestaurantID = (int) RestaurantId;
            globalUserID = currentUserID;
            globalRestaurantName = Restaurant.RestaurantName;

            ViewData["currentUserID"] = currentUserID;
            ViewData["RestaurantID"] = RestaurantId;
            ViewData["UserID"] = currentUserID;
            ViewData["RestaurantName"] = Restaurant.RestaurantName;
            ViewData["RestaurantImageUrl"] = Restaurant.RestaurantImageUrl;
            return Page();
        }
        //added
        public IList<restaurant_reservation> restaurant_reservation2 { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //added
            int totalminutescheck = 0;

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            restaurant_reservation2 = await _context.restaurant_reservation
                .Include(r => r.user)
                .Include(r => r.Restaurant)
                .Where(m => m.NewUserID == currentUserID)
                //.Include(m => m.NewUserID == currentUserID)
                .ToListAsync();

            //account for the fact that there are no previous reservations.
            if (restaurant_reservation2.Count < 1)
                totalminutescheck = 100; //make it bigger than 30 so that it can add

            foreach (var p in restaurant_reservation2)
            {

                DateTime date1 = p.DateAndTime;  //loop through the list and grab the date and time
                DateTime date2 = restaurant_reservation.DateAndTime;
                System.Diagnostics.Debug.WriteLine(date2);

                //int result = DateTime.Compare(date1, date2);

                TimeSpan diffresult = date2.Subtract(date1);

                int hours = int.Parse(diffresult.Hours.ToString());
                int hourstominutes = hours * 60;
                int minutes = int.Parse(diffresult.Minutes.ToString());
                int totalminutes = hourstominutes + minutes;
                totalminutescheck = Math.Abs(totalminutes);
                System.Diagnostics.Debug.WriteLine(totalminutescheck);

                if (totalminutescheck < 30)
                    System.Diagnostics.Debug.WriteLine("Less than 30 minutes");
                else
                    System.Diagnostics.Debug.WriteLine("greater than 30 minutes");
            }

            if (!ModelState.IsValid || totalminutescheck < 30)
            {
                System.Diagnostics.Debug.WriteLine(globalRestaurantUrl);
                ViewData["DisplayError"] = "Reservations must be greater than 30 minutes apart.  Please choose another time.";
                ViewData["RestaurantImageUrl"] = globalRestaurantUrl;
                ViewData["RestaurantID"] = globalRestaurantID;
                ViewData["UserID"] = globalUserID;
                ViewData["RestaurantName"] = globalRestaurantName;

                return Page();
            }

            _context.restaurant_reservation.Add(restaurant_reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Reports/Index");
        }
    }
}
