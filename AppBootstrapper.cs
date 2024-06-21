using Microsoft.Azure.Cosmos;
using SummerInternship.Repository;
using SummerInternship.Service;

namespace SummerInternship
{
    public class AppBootstrapper
    {
        public static void InitServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            
            services.AddSingleton(serviceProvider =>
            {
                var cosmosDbSettings = configuration.GetSection("DatabaseSettings");
                string account = cosmosDbSettings["Account"];
                string key = cosmosDbSettings["Key"];
                return new CosmosClient(account, key);
            });

            
            services.AddScoped(typeof(ICosmosRepository<>), typeof(CosmosRepository<>));

            
            services.AddScoped<ProgramService>();
        }
    }

}
