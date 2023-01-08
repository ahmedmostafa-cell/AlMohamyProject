using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbMainConsulting
    {
        public Guid MainConsultingId { get; set; }
        public string MainConsultingTitle { get; set; }
        public string MainConsultingImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
        public string Consulting30MinutesCost { get; set; }
        public string Consulting60MinutesCost { get; set; }
        public string Consulting90MinutesCost { get; set; }
    }
}
