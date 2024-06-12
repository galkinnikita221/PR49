using Microsoft.EntityFrameworkCore;
using PR49_Galkin.Model;

namespace PR49_Galkin.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<Oders> Oders { get; set; }
        public OrderContext()
        {
            Database.EnsureCreated();
            Oders.Load();   
        }
        /// <summary>
        /// Переопределение
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.Config.StrConnect, Config.Config.mySqlServerVersion);
    }
}
