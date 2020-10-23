using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DetailsModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public user user { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.user.FirstOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
