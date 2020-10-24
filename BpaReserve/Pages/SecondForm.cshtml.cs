using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bpa_Test_2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BpaReserve.Pages
{
    public class RideCard2Model : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public RideCard2Model(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public Bpa_Test_2.Models.Ride Ride { get; set; }

        public void OnGet(int id)
        {
            Ride =  _context.Ride.FirstOrDefault(e => e.RideID == id);
            
        }
    }
}