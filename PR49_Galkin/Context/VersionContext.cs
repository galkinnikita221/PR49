using Microsoft.EntityFrameworkCore;
using PR49_Galkin.Model;

namespace PR49_Galkin.Context
{
    public class VersionContext : DbContext
    {
        public DbSet<Versiya> Versiyas { get; set; }
        public VersionContext() { 
            Database.EnsureCreated();
            Versiyas.Load();
        }
        /// <summary>
        /// Переопределение
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.Config.StrConnect, Config.Config.mySqlServerVersion);
    }
}
