using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Room
    {
        public Room()
        {
            Holiday = new HashSet<Holiday>();
        }

        public int Id { get; set; }
        public string Nameroom { get; set; }
        public string Descriptions { get; set; }
        public string Persons { get; set; }
        public byte[] Photo { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Holiday> Holiday { get; set; }
    }
}
