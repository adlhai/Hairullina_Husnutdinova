using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Holiday = new HashSet<Holiday>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Holiday> Holiday { get; set; }
    }
}
