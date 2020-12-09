using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MyNamespace;

namespace Otus.Teaching.PromoCodeFactory.WebHost
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();

      var httpClient = new HttpClient
      {
        BaseAddress = new Uri("")
      };
      
      
      // var employeesClient = new EmployeesClient(httpClient);
      // var employeeShortResponses = await employeesClient.GetEmployeesAsync();
      
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host
        .CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(cb =>
        {
          cb.AddJsonFile("jonSmit.json", true, true)
            .AddInMemoryCollection(new Dictionary<string, string>
            {
              ["StartedAtUtc"] = DateTime.UtcNow.ToString("O"),
            });
        })
        .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
  }
}