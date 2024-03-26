using System;
using System.Collections.Generic;

namespace calculate.Models
{
    public partial class Holidayservices
    {
        public int Id { get; set; }
        public int Holidayid { get; set; }
        public int Servicesid { get; set; }

        public virtual Holiday Holiday { get; set; }
        public virtual Services Services { get; set; }
    }
}
