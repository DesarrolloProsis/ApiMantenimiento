using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class RollsCatalog
    {
        public RollsCatalog()
        {
            Dtcusers = new HashSet<Dtcusers>();
        }

        public int RollId { get; set; }
        public string RollDescription { get; set; }

        public virtual ICollection<Dtcusers> Dtcusers { get; set; }
    }
}
