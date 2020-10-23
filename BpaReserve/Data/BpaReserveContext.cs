using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bpa_Test_2.Models;

namespace BpaReserve.Data
{
    public class BpaReserveContext : DbContext
    {
        public BpaReserveContext (DbContextOptions<BpaReserveContext> options)
            : base(options)
        {
        }

        public DbSet<Bpa_Test_2.Models.Restaurant> Restaurant { get; set; }

        public DbSet<Bpa_Test_2.Models.Ride> Ride { get; set; }

        public DbSet<Bpa_Test_2.Models.restaurant_reservation> restaurant_reservation { get; set; }

        public DbSet<Bpa_Test_2.Models.RideReservation> RideReservation { get; set; }

        public DbSet<Bpa_Test_2.Models.user> user { get; set; }
    }
}
