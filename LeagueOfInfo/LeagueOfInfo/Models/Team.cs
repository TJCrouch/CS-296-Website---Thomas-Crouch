namespace LeagueOfInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        public int TeamID { get; set; }

        [Required]
        [StringLength(25)]
        public string TeamName { get; set; }

        [Required]
        [StringLength(25)]
        public string LeagueName { get; set; }

        public virtual League Leagues { get; set; }

        public object LeagueID { get; set; }
    }
}
