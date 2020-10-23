using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bpa_Test_2.Models;


namespace BpaReserve.Pages
{
    public class RideModel : PageModel
    {

        private readonly BpaReserve.Data.BpaReserveContext _context;

        public RideModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<Bpa_Test_2.Models.Ride> Ride { get; set; }

        public async Task OnGetAsync()
        {
            Ride = await _context.Ride.ToListAsync();
        }
    }
}

