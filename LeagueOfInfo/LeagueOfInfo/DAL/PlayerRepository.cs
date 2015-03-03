﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LeagueOfInfo.Models;

namespace LeagueOfInfo.DAL
{
    public class PlayerRepository : IPlayerRepository, IDisposable
    {
        private LeagueOfInfoContext context;

        public PlayerRepository(LeagueOfInfoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return context.Players.ToList();
        }

        public Player GetPlayerByID(int id)
        {
            return context.Players.Find(id);
        }

        public void InsertPlayer(Player player)
        {
            context.Players.Add(player);
        }

        public void DeletePlayer(int playerID)
        {
            Player player = context.Players.Find(playerID);
            context.Players.Remove(player);
        }

        public void UpdatePlayer(Player player)
        {
            context.Entry(player).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
