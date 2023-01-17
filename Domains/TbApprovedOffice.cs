using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbApprovedOffice
    {
        public Guid? ApprovedOfficeId { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المكتب المعتمد")]
        public string ApprovedOfficeName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المنطقة")]
        public string AreaName { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المدينة")]
        public string CityName { get; set; }
       
        public string ApprovedOfficeLogo { get; set; }
      
        public string ApprovedOfficeLicenseDoc { get; set; }
        public string ApprovalStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
