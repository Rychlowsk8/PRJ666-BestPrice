using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class Locations
    {
        public Locations()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
