using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bpa_Test_2.Models
{
    public class restaurant_reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RestaurantID { get; set; }
        public DateTime DateAndTime { get; set; }


        public user user { get; set; }
        public Restaurant Restaurant { get; set; }


    }
}
