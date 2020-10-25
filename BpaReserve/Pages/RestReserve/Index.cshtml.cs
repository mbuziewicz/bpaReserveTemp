using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BpaReserve.Data;
using Bpa_Test_2.Models;
using Microsoft.AspNetCore.Authorization;

namespace BpaReserve.Pages.RestReserve
{
    [Authorize(Roles = "Admin")]
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
                .Include(r => r.Restaurant).ToListAsync();

            foreach (var p in restaurant_reservation)
            {

                DateTime date1 = p.DateAndTime;  //loop through the list and grab the date and time
                DateTime date2 = new DateTime(2020, 10, 20, 12, 0, 0);
                int result = DateTime.Compare(date1, date2);

                TimeSpan diffresult = date1.Subtract(date2);

                int hours = int.Parse(diffresult.Hours.ToString());
                int hourstominutes = hours * 60;
                int minutes = int.Parse(diffresult.Minutes.ToString());
                int totalminutes = hourstominutes + minutes;

                if (totalminutes < 15)
                    System.Diagnostics.Debug.WriteLine("Less than 15 minutes");
                else
                    System.Diagnostics.Debug.WriteLine("greater than 15 minutes");


            }
        }
    }
}
