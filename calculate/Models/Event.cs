using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Event
    {
        public Event()
        {
            Holiday = new HashSet<Holiday>();
        }

        public int Id { get; set; }
        public string Nameevent { get; set; }

        public virtual ICollection<Holiday> Holiday { get; set; }
    }
}
