// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizationMaster.Models
{
    public partial class Tblstate
    {
        [Required]
        public int? CountryId { get; set; }
        public int StateId { get; set; }

        [StringLength(20,ErrorMessage ="StateName Is too long")]
        public string StateName { get; set; }
    }
}