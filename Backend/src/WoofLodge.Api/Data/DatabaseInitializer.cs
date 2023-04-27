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
                        Id = 1,
                        BreedName = "Kundel"
                    },

                    new Breed()
                    {
                        Id = 2,
                        BreedName = "Owczarek szwajcarski"
                    },

                    new Breed()
                    {
                        Id = 3,
                        BreedName = "Pekińczyk"
                    },

                    new Breed()
                    {
                        Id = 4,
                        BreedName = "Mops"
                    },

                    new Breed()
                    {
                        Id = 5,
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
