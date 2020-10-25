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
using System.Security.Claims;

namespace BpaReserve.Pages.RestReserve
{
    [Authorize]
    public class IndexReportModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public IndexReportModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<restaurant_reservation> restaurant_reservation { get;set; }
        public IList<RideReservation> RideReservation { get; set; }

        public async Task OnGetAsync()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            RideReservation = await _context.RideReservation
                .Include(r => r.Ride)
                .Include(r => r.user)
                .ToListAsync();

            restaurant_reservation = await _context.restaurant_reservation
                .Include(r => r.user)
                .Include(r => r.Restaurant)
                .Where(m => m.NewUserID == currentUserID)
                //.Include(m => m.NewUserID == currentUserID)
                .ToListAsync();
        }
    }
}
