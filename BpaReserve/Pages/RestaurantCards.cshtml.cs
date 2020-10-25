using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userI
            //System.Diagnostics.Debug.WriteLine("Userid:{0}", userId);
            /*
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            System.Diagnostics.Debug.WriteLine("Userid:{0}", currentUserID);
            ViewData["currentUserID"] = currentUserID;
            */

            Restaurant = await _context.Restaurant.ToListAsync();
        }
    }
}
