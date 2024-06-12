using Microsoft.EntityFrameworkCore;
using PR49_Galkin.Model;

namespace PR49_Galkin.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public UsersContext() {
            Database.EnsureCreated();
            User.Load();
        }
        /// <summary>
        /// Переопределение
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Config.Config.StrConnect, Config.Config.mySqlServerVersion);
    }
}
