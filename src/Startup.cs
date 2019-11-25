using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Controllers;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CoreCodeCamp
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<CampContext>();
      services.AddScoped<ICampRepository, CampRepository>();

      services.AddAutoMapper(Assembly.GetEntryAssembly());

      services.AddMvc(opt => opt.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddApiVersioning(opt =>
      {
          opt.DefaultApiVersion = new ApiVersion(1,1);
          opt.ReportApiVersions = true;
          opt.AssumeDefaultVersionWhenUnspecified = true;
          opt.ApiVersionReader = new UrlSegmentApiVersionReader();
          //opt.ApiVersionReader = ApiVersionReader.Combine(
          //    new HeaderApiVersionReader("X-Version"),
          //    new QueryStringApiVersionReader("ver", "version"));
          //opt.Conventions.Controller<TalksController>()
          //    .HasApiVersion(new ApiVersion(1, 0).HasApiVersion(new ApiVersion(1, 0));
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      
      app.UseMvc();
    }
  }
}
