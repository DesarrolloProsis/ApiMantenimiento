using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class TypeLane
    {
        public TypeLane()
        {
            LanesCatalog = new HashSet<LanesCatalog>();
        }

        public string TypeLaneId { get; set; }
        public string TypeLaneDescription { get; set; }

        public virtual ICollection<LanesCatalog> LanesCatalog { get; set; }
    }
}
