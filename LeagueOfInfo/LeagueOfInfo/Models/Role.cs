namespace LeagueOfInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Role
    {
        public int RoleID { get; set; }

        [Required]
        [StringLength(25)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(25)]
        public string PrimaryAttribute { get; set; }
    }
}
