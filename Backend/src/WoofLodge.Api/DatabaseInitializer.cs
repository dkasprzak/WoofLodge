using Microsoft.EntityFrameworkCore;
using WoofLodge.Api.Data;
using WoofLodge.Api.Entities;

namespace WoofLodge.Api
{
    public class DatabaseInitializer 
    {
        private readonly WoofLodgeDbContext _dbContext;

        public DatabaseInitializer(WoofLodgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
            }
        }
    }
}
