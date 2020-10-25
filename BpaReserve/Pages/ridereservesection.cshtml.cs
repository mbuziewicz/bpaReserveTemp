using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BpaReserve.Pages
{
    [Authorize]
    public class ridereservesectionModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public ridereservesectionModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public Bpa_Test_2.Models.Ride Ride { get; set; }

        public void OnGet(int id)
        {
            Ride = _context.Ride.FirstOrDefault(e => e.RideID == id);

        }
    }
}
