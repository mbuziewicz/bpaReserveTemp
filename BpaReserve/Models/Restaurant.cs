using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bpa_Test_2.Models
{
    public class Restaurant
    {
        //Set the key to autoincrement
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantImageUrl { get; set; }
        public string Description { get; set; }
        public string WaitTime { get; set; }

    }
}
