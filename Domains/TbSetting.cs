﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSetting
    {
        public Guid SettingId { get; set; }
        public string ValueAddedTax { get; set; }
        public string AppProfitPercent { get; set; }
        public string OffersValidityDays { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
