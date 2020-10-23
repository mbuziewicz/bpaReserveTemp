using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;

namespace BpaReserve.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public EditModel(BpaReserve.Data.BpaReserveContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(user.UserID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool userExists(int id)
        {
            return _context.user.Any(e => e.UserID == id);
        }
    }
}
