using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Fershet
    {
        public Fershet()
        {
            Holidayfursh = new HashSet<Holidayfursh>();
        }

        public int Id { get; set; }
        public string Namefershet { get; set; }
        public string Descriptions { get; set; }
        public string People { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Holidayfursh> Holidayfursh { get; set; }
    }
}
