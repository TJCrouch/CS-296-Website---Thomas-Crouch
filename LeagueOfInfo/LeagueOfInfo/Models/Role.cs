//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeagueOfInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Primary Attribute")]
        public string PrimaryAttribute { get; set; }
    }
}
