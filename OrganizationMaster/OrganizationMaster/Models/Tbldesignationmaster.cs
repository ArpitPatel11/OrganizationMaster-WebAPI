﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizationMaster.Models
{
    public partial class Tbldesignationmaster
    {
        [Required]
        public int? OraganizationId { get; set; }

        [Required]
        public int? BranchId { get; set; }

        [Required]
        public int? DepartmentId { get; set; }
        public int DesignationId { get; set; }

        [StringLength(25, ErrorMessage ="DesignationName is too long")]
        public string DesignationName { get; set; }
        public bool? IsActive { get; set; }
    }
}