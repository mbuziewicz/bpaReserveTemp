using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.RestReserve
{
    public class IndexModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public IndexModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<restaurant_reservation> restaurant_reservation { get;set; }

        public async Task OnGetAsync()
        {
            restaurant_reservation = await _context.restaurant_reservation
                .Include(r => r.Restaurant)
                .Include(r => r.user).ToListAsync();
        }
    }
}
