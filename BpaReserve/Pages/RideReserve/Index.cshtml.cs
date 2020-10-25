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

namespace BpaReserve.Pages.RideReserve
{

    public class IndexModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public IndexModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<RideReservation> RideReservation { get;set; }

        public async Task OnGetAsync()
        {
            RideReservation = await _context.RideReservation
                .Include(r => r.Ride)
                .Include(r => r.user).ToListAsync();
        }
    }
}
