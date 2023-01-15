using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSubMainConsulting
    {
        public Guid? SubMainConsultingId { get; set; }
        public string SubMainConsultingTitle { get; set; }
        public string SubMainConsultingDescription { get; set; }
        public string SubMainConsultingImage { get; set; }
        public Guid? MainConsultingId { get; set; }
        public string SubMainConsulting { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
