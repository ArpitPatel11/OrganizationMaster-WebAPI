// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizationMaster.Models
{
    public partial class Tblcity
    {
        //public string CountryName { get; set; }
        [Required]
        public int? StateId { get; set; }
        //public string StateName { get; set; }
        public int CityId { get; set; }

        [StringLength(20, ErrorMessage ="CityName is too long")]
        public string CityName { get; set; }
        
        
    }
}