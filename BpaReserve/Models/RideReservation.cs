using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bpa_Test_2.Models
{
    public class RideReservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RideID { get; set; }
        public DateTime DateAndTime { get; set; }

        public user user { get; set; }
        public Ride Ride { get; set; }

    }
}
