// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizationMaster.Models
{
    public partial class Tblorganizationmaster
    {
        public int OraganizationId { get; set; }

        [StringLength(25, ErrorMessage ="OrganizationName is too long")]
        public string OraganizationName { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Fax { get; set; }

        [Required]
        public int? CityId { get; set; }

        [Required]
        public string Prefix { get; set; }

        [StringLength(8)]
        public string ZipCode { get; set; }

        [Required]
        public string Address { get; set; }
        public bool? IsActive { get; set; }
    }
}