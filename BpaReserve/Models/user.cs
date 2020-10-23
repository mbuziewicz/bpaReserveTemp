using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bpa_Test_2.Models
{
    public class user
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<restaurant_reservation> restaurant_reservations { get; set; }
    }
}
