using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Holidayfursh
    {
        public int Id { get; set; }
        public int Holidayid { get; set; }
        public int Furshid { get; set; }
        public string Count { get; set; }

        public virtual Fershet Fursh { get; set; }
        public virtual Holiday Holiday { get; set; }
    }
}
