using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BpaReserve.Pages
{

    public class ResturantCardModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public ResturantCardModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<Bpa_Test_2.Models.Restaurant> Restaurant { get; set; }

        public async Task OnGetAsync()
        {

            Restaurant = await _context.Restaurant.ToListAsync();
        }
    }
}
