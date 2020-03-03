using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class AgreementInfo
    {
        public AgreementInfo()
        {
            Dtcdata = new HashSet<Dtcdata>();
        }

        public int AgremmentInfoId { get; set; }
        public string Agrement { get; set; }
        public string ManagerName { get; set; }
        public string Position { get; set; }
        public string Mail { get; set; }
        public string SquareCatalogId { get; set; }

        public virtual SquaresCatalog SquareCatalog { get; set; }
        public virtual ICollection<Dtcdata> Dtcdata { get; set; }
    }
}
