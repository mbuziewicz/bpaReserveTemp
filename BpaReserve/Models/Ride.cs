using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bpa_Test_2.Models
{
    public class Ride
    {
        //Set the key to autoincrement
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RideID { get; set; }
        public string RideName { get; set; }
        public string Description { get; set; }
        public string WaitTime { get; set; }

        public string RideImageUrl { get; set; }

    }
}
