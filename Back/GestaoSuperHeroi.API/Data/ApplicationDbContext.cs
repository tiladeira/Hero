using GestaoSuperHeroi.API.Models;

using System.Data.Entity;

namespace GestaoSuperHeroi.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :
          base("OktaConnectionString")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<SugarLevel> SugarLevels { get; set; }
    }
}