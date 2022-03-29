# HumanitarianAid

**Step 4 - Developer tests**

## Unit tests
* Right click project Centric.HumanitarianAid.Business.UnitTests, Manage NuGet Packages, find and search FluentAssertions
* Write the unit tests in the ShelterTests for the Shelter business model
* Use the method name convention When_StateUnderTest_Then_ShouldHaveExpectedResult

## Integration tests
* Right click project HumanitarianAid.API.IntegrationTests, Manage NuGet Packages, find and search the NuGet packages
  * FluentAssertions
  * Microsoft.AspNetCore.Mvc.Testing
* Write the integration test in the SheltersControllerTests for the ShelterController register shelter functionality
  * Use the WebApplicationFactory in order to create the HttpClient, like in the article https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
  * Use the POST method in the act section and the GET method in the Assert section 
