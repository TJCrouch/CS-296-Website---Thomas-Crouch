using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueOfInfo.Models;

namespace LeagueOfInfo.DAL
{
    public class UnitOfWork : IDisposable
    {
        private LeagueOfInfoContext context = new LeagueOfInfoContext();
        private GenericRepository<League> leagueRepository;
        private GenericRepository<Team> teamRepository;

        public GenericRepository<League> LeagueRepository
        {
            get
            {
                if (this.leagueRepository == null)
                {
                    this.leagueRepository = new GenericRepository<League>(context);
                }
                return leagueRepository;
            }
        }

        public GenericRepository<Team> TeamRepository
        {
            get
            {
                if (this.teamRepository == null)
                {
                    this.teamRepository = new GenericRepository<Team>(context);
                }
                return teamRepository;
            }
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
