using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class SquaresCatalog
    {
        public SquaresCatalog()
        {
            AgreementInfo = new HashSet<AgreementInfo>();
            LanesCatalog = new HashSet<LanesCatalog>();
            UserSquare = new HashSet<UserSquare>();
        }

        public string SquareCatalogId { get; set; }
        public string SquareName { get; set; }
        public int DelegationId { get; set; }

        public virtual DelegationCatalog Delegation { get; set; }
        public virtual ICollection<AgreementInfo> AgreementInfo { get; set; }
        public virtual ICollection<LanesCatalog> LanesCatalog { get; set; }
        public virtual ICollection<UserSquare> UserSquare { get; set; }
    }
}
