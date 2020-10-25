using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BpaReserve.Pages
{

    public class RideCardModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public RideCardModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<Bpa_Test_2.Models.Ride> Rides { get; set; }

        public async Task OnGetAsync()
        {
            Rides = await _context.Ride.ToListAsync();
        }
    }
}
