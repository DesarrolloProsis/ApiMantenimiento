using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class LanesCatalog
    {
        public string CapufeLaneNum { get; set; }
        public string IdGare { get; set; }
        public string Lane { get; set; }
        public string SquareCatalogId { get; set; }
        public string TypeLaneId { get; set; }

        public virtual SquaresCatalog SquareCatalog { get; set; }
        public virtual TypeLane TypeLane { get; set; }
    }
}
