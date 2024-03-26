using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Holiday
    {
        public Holiday()
        {
            Holidayfursh = new HashSet<Holidayfursh>();
            Holidayservices = new HashSet<Holidayservices>();
        }

        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Eventid { get; set; }
        public int Roomid { get; set; }
        public int Klientid { get; set; }
        public int? Hours { get; set; }

        public virtual Event Event { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Holidayfursh> Holidayfursh { get; set; }
        public virtual ICollection<Holidayservices> Holidayservices { get; set; }
    }
}
