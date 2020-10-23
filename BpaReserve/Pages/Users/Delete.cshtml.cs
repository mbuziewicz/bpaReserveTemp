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
    public class DeleteModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public DeleteModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public user user { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.user.FirstOrDefaultAsync(m => m.UserID == id);

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.user.FindAsync(id);

            if (user != null)
            {
                _context.user.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
