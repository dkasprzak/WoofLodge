using Microsoft.EntityFrameworkCore;

namespace WoofLodge.Api.Data
{
    public static class Extension
    {
        private const string SectionName = "ConnectionStrings";

        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration) 
        {
            var section = configuration.GetSection(SectionName);
            services.Configure<PostgresOptions>(section);
            var options = configuration.GetOptions<PostgresOptions>(SectionName);

            services.AddDbContext<WoofLodgeDbContext>(x => x.UseNpgsql(options.ConnectionString));
            services.AddHostedService<DatabaseInitializer>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
