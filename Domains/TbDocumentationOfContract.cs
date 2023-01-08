using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbDocumentationOfContract
    {
        public Guid DocumentationOfContractId { get; set; }
        public string DocumentationOfContractTilte { get; set; }
        public string DocumentationOfContractDescription { get; set; }
        public string DocumentationOfContractImage { get; set; }
        public string DocumentationOfContractCost { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
