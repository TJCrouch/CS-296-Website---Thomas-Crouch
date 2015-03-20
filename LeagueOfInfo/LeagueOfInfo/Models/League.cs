namespace LeagueOfInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class League
    {
        public int LeagueID { get; set; }

        [Required]
        [StringLength(25)]
        public string LeagueName { get; set; }

        [Required]
        [StringLength(25)]
        public string RegionName { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
