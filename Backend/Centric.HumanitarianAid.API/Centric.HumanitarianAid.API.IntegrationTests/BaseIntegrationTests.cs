using System.Linq;
using System.Net.Http;
using Centric.HumanitarianAid.API.Data;
using HumanitarianAid.API.Shelters;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Centric.HumanitarianAid.API.IntegrationTests;

public class BaseIntegrationTests
{
    protected HttpClient HttpClient { get; private set; }

    protected BaseIntegrationTests()
    {
        var application = new WebApplicationFactory<SheltersController>()
            .WithWebHostBuilder(builder => { });
        HttpClient = application.CreateClient();

        CleanupDatabase();
    }

    private void CleanupDatabase()
    {
        var databaseContext = new DatabaseContext();
        databaseContext.Persons.RemoveRange(databaseContext.Persons.ToList());
        databaseContext.Shelters.RemoveRange(databaseContext.Shelters.ToList());
        databaseContext.SaveChanges();
    }
}