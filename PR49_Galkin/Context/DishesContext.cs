using Microsoft.EntityFrameworkCore;
using PR49_Galkin.Model;

namespace PR49_Galkin.Context
{
    public class DishesContext : DbContext
    {
        public DbSet<Dishes> Dishes { get; set; }
        public DishesContext()
        {
            Database.EnsureCreated();
            Dishes.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.Config.StrConnect, Config.Config.mySqlServerVersion);
    }
}
