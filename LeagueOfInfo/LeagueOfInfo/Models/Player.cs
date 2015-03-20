namespace LeagueOfInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Player
    {
        public int PlayerID { get; set; }

        [Required]
        [StringLength(25)]
        public string PlayerName { get; set; }

        [Required]
        [StringLength(25)]
        public string TeamName { get; set; }

        [Required]
        [StringLength(25)]
        public string LeagueName { get; set; }

        [Required]
        [StringLength(25)]
        public string RoleName { get; set; }

        public virtual Team Team { get; set; }
    }
}
