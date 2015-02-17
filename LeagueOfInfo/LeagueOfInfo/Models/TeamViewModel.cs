using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfInfo.Models
{
    public class TeamViewModel
    {
        public string TeamName { get; set; }
        public LeagueViewModel LeagueName { get; set; }
    }

    public class LeagueViewModel
    {
        public string Name { get; set; }
    }
}
