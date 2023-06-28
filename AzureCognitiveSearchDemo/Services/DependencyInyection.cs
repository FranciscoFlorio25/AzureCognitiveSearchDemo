using AzureCognitiveSearchDemo.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Search.Documents;
using Azure;

namespace AzureCognitiveSearchDemo.Services
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInyections(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DemoContext>
                (o => o.UseSqlServer(configuration.GetConnectionString(name: "Default")));

            service.AddSingleton(provider =>
            {
                var searchUri = new Uri(configuration["SearchClient:SearchUri"]);
                string IndexName = configuration["SearchClient:IndexName"];
                var credential = new AzureKeyCredential(configuration["SearchClient:SearchKey"]);
                var searchClient = new SearchClient(searchUri,IndexName,credential);

                return searchClient;
            });

            return service;
        }
    }
}
