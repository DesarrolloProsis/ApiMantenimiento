using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class DelegationCatalog
    {
        public DelegationCatalog()
        {
            SquaresCatalog = new HashSet<SquaresCatalog>();
        }

        public int DelegationId { get; set; }
        public string DelegationName { get; set; }

        public virtual ICollection<SquaresCatalog> SquaresCatalog { get; set; }
    }
}
