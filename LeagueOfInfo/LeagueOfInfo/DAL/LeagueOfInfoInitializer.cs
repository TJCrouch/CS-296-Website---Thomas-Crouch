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
                new League{LeagueID="LCK", RegionName="Korea"},
                new League{LeagueID="LPL", RegionName="China"},
                new League{LeagueID="GPL", RegionName="South East Asia"},
                new League{LeagueID="NALCS", RegionName="North America"},
                new League{LeagueID="EULCS", RegionName="Europe"}
            };
            leagues.ForEach(s => context.Leagues.Add(s));
            context.SaveChanges();

            var teams = new List<Team>
            {
                new Team{TeamID="SK Telecom T1", LeagueName="LCK"},
                new Team{TeamID="Edward Gaming", LeagueName="LPL"},
                new Team{TeamID="Hong Kong ESports", LeagueName="GPL"},
                new Team{TeamID="CounterLogic Gaming", LeagueName="NALCS"},
                new Team{TeamID="SK Gaming", LeagueName="EULCS"}
            };
            teams.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{PlayerID="Faker", TeamName="SK Telecom T1", LeagueName="LCK", RoleName="Middle"},
                new Player{PlayerID="Deft", TeamName="Edward Gaming", LeagueName="LPL", RoleName="Attack Damage Carry"},
                new Player{PlayerID="Toyz", TeamName="Hong Kong ESports", LeagueName="GPL", RoleName="Middle"},
                new Player{PlayerID="Doublelift", TeamName="CounterLogic Gaming", LeagueName="NALCS", RoleName="Attack Damage Carry"},
                new Player{PlayerID="NRated", TeamName="SK Gaming", LeagueName="EULCS", RoleName="Support"}
            };
            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role{RoleID="Top", PrimaryAttribute="Tank/Fighter"},
                new Role{RoleID="Jungle", PrimaryAttribute="Tank/Fighter"},
                new Role{RoleID="Middle", PrimaryAttribute="Mage/Assassin"}, 
                new Role{RoleID="Attack Damage Carry", PrimaryAttribute="Marksman"},
                new Role{RoleID="Support", PrimaryAttribute="Support"}
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var champions = new List<Champion>
            {
                new Champion{ChampionID="Lissandra", RoleName="Middle/Top", PrimaryAttribute="Mage"},
                new Champion{ChampionID="Rek'Sai", RoleName="Jungle", PrimaryAttribute="Fighter"},
                new Champion{ChampionID="Zed", RoleName="Middle", PrimaryAttribute="Assassin"},
                new Champion{ChampionID="Graves", RoleName="Marksman", PrimaryAttribute="Marksman"},
                new Champion{ChampionID="Thresh", RoleName="Support", PrimaryAttribute="Support"}
            };
            champions.ForEach(s => context.Champions.Add(s));
            context.SaveChanges();
        }
    }
}
