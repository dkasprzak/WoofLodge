using Microsoft.EntityFrameworkCore;
using WoofLodge.Api.Entities;

namespace WoofLodge.Api.Data
{
    public class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using(var scope = _serviceProvider.CreateScope()) 
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WoofLodgeDbContext>();
                dbContext.Database.Migrate();

                var breeds = dbContext.Breeds.ToList();
                if (breeds.Any())
                {
                    return Task.CompletedTask;
                }

                breeds = new List<Breed>
                {
                     new Breed()
                    {
                        Id = Guid.Parse("15f26f51-d996-482b-8fd0-f62a061a7dba"),
                        BreedName = "Kundel"
                    },

                    new Breed()
                    {
                        Id = Guid.Parse("15d26f51-d996-482b-8fd0-f62a061a7dba"),
                        BreedName = "Owczarek szwajcarski"
                    },

                    new Breed()
                    {
                        Id = Guid.Parse("15f26f51-d996-482b-8fd0-f62a061a7dda"),
                        BreedName = "Pekińczyk"
                    },

                    new Breed()
                    {
                        Id = Guid.Parse("35f26f51-d996-482b-8fd0-f62a061a7dba"),
                        BreedName = "Mops"
                    },

                    new Breed()
                    {
                        Id = Guid.Parse("55f26f51-d996-485b-8fd0-f62a061a7dba"),
                        BreedName = "Golden retriever"
                    }
                };
                dbContext.Breeds.AddRange(breeds);
                dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
