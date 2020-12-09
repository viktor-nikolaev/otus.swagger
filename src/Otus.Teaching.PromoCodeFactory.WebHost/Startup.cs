using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;

namespace Otus.Teaching.PromoCodeFactory.WebHost
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    public Startup(IConfiguration configuration, IHostEnvironment environment)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      var appOptions = Configuration.Get<AppOptions>(c => c.BindNonPublicProperties = true);
      
      services.AddSingleton(appOptions);
      
      services.Configure<AppOptions>(Configuration);

      services.AddScoped(
        typeof(IRepository<Employee>),
        x => new InMemoryRepository<Employee>(FakeDataFactory.Employees));

      services.AddScoped(typeof(IRepository<Role>), x =>
        new InMemoryRepository<Role>(FakeDataFactory.Roles));

      services.AddControllers();

      services
        .AddOpenApiDocument(options =>
        {
          options.DocumentName = "v1";
          options.Title = "PromoCode Factory API Doc";
          options.Version = "1";
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsProduction())
      {
        // use yandex metrics
      }
      
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseOpenApi();
      app.UseSwaggerUi3(x => { x.DocExpansion = "list"; });
      app.UseReDoc(x => x.Path = "/redoc");

      app.UseHttpsRedirection();

      app.UseRouting();
      
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}