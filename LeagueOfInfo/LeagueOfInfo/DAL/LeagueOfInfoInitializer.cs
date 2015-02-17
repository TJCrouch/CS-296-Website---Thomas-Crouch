using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LeagueOfInfo.Models;

namespace LeagueOfInfo.DAL
{
    class LeagueOfInfoInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<LeagueOfInfoContext>
    {
        protected override void Seed(LeagueOfInfoContext context)
        {
            var leagues = new List<League>
            {
                new League{LeagueID=1, LeagueName="LCK", RegionName="Korea"},
                new League{LeagueID=2, LeagueName="LPL", RegionName="China"},
                new League{LeagueID=3, LeagueName="GPL", RegionName="South East Asia"},
                new League{LeagueID=4, LeagueName="NALCS", RegionName="North America"},
                new League{LeagueID=5, LeagueName="EULCS", RegionName="Europe"}
            };
            leagues.ForEach(s => context.Leagues.Add(s));
            context.SaveChanges();

            var teams = new List<Team>
            {
                new Team{TeamID=1, TeamName="SK Telecom T1", LeagueName="LCK"},
                new Team{TeamID=2, TeamName="Edward Gaming", LeagueName="LPL"},
                new Team{TeamID=3, TeamName="Hong Kong ESports", LeagueName="GPL"},
                new Team{TeamID=4, TeamName="CounterLogic Gaming", LeagueName="NALCS"},
                new Team{TeamID=5, TeamName="SK Gaming", LeagueName="EULCS"}
            };
            teams.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{PlayerID=1, PlayerName="Faker", TeamName="SK Telecom T1", LeagueName="LCK", RoleName="Middle"},
                new Player{PlayerID=2, PlayerName="Deft", TeamName="Edward Gaming", LeagueName="LPL", RoleName="Attack Damage Carry"},
                new Player{PlayerID=3, PlayerName="Toyz", TeamName="Hong Kong ESports", LeagueName="GPL", RoleName="Middle"},
                new Player{PlayerID=4, PlayerName="Doublelift", TeamName="CounterLogic Gaming", LeagueName="NALCS", RoleName="Attack Damage Carry"},
                new Player{PlayerID=5, PlayerName="NRated", TeamName="SK Gaming", LeagueName="EULCS", RoleName="Support"}
            };
            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role{RoleID=1, RoleName="Top", PrimaryAttribute="Tank/Fighter"},
                new Role{RoleID=2, RoleName="Jungle", PrimaryAttribute="Tank/Fighter"},
                new Role{RoleID=3, RoleName="Middle", PrimaryAttribute="Mage/Assassin"}, 
                new Role{RoleID=4, RoleName="Attack Damage Carry", PrimaryAttribute="Marksman"},
                new Role{RoleID=5, RoleName="Support", PrimaryAttribute="Support"}
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var champions = new List<Champion>
            {
                new Champion{ChampionID=1, ChampionName="Lissandra", RoleName="Middle/Top", PrimaryAttribute="Mage"},
                new Champion{ChampionID=2, ChampionName="Rek'Sai", RoleName="Jungle", PrimaryAttribute="Fighter"},
                new Champion{ChampionID=3, ChampionName="Zed", RoleName="Middle", PrimaryAttribute="Assassin"},
                new Champion{ChampionID=4, ChampionName="Graves", RoleName="Marksman", PrimaryAttribute="Marksman"},
                new Champion{ChampionID=5, ChampionName="Thresh", RoleName="Support", PrimaryAttribute="Support"}
            };
            champions.ForEach(s => context.Champions.Add(s));
            context.SaveChanges();
        }
    }
}
