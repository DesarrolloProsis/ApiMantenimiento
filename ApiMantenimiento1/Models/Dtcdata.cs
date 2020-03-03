using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class Dtcdata
    {
        public string ReferenceNumber { get; set; }
        public string SinisterNumber { get; set; }
        public string ReportNumber { get; set; }
        public DateTime SinisterDate { get; set; }
        public DateTime FailureDate { get; set; }
        public string FailureNumber { get; set; }
        public string Description { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime ElaborationDate { get; set; }
        public int UserId { get; set; }
        public int AgremmentInfoId { get; set; }

        public virtual AgreementInfo AgremmentInfo { get; set; }
        public virtual Dtcusers User { get; set; }
    }
}
