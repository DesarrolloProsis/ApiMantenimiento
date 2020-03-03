using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class UserSquare
    {
        public int UserId { get; set; }
        public string SquareCatalogId { get; set; }

        public virtual SquaresCatalog SquareCatalog { get; set; }
        public virtual Dtcusers User { get; set; }
    }
}
