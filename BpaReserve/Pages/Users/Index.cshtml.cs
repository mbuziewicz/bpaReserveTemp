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
    public class IndexModel : PageModel
    {
        private readonly BpaReserve.Data.BpaReserveContext _context;

        public IndexModel(BpaReserve.Data.BpaReserveContext context)
        {
            _context = context;
        }

        public IList<user> user { get;set; }

        public async Task OnGetAsync()
        {
            user = await _context.user.ToListAsync();
        }
    }
}
