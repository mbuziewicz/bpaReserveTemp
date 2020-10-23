using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bpa_Test_2.Models
{
    public class Ride
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int RideID { get; set; }
        public string RideName { get; set; }
        public string Description { get; set; }
        public string WaitTime { get; set; }

        public string RideImageUrl { get; set; }

    }
}
