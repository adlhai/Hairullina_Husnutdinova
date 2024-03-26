using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Services
    {
        public Services()
        {
            Holidayservices = new HashSet<Holidayservices>();
        }

        public int Id { get; set; }
        public string Nameservices { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Holidayservices> Holidayservices { get; set; }
    }
}
