using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OSharp.AspNetCore.Mvc;
using OSharp.AspNetCore.Routing;
using OSharp.Authorization.EntityInfos;
using OSharp.AutoMapper;
using OSharp.Entity.SqlServer;
using OSharp.Log4Net;
using OSharp.Samples.MasterSlaveSplit.Startups;


namespace OSharp.Samples.MasterSlaveSplit
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOSharp()
                .AddPack<Log4NetPack>()
                .AddPack<AutoMapperPack>()
                .AddPack<MvcPack>()
                .AddPack<EntityInfoPack>()
                .AddPack<EndpointsPack>()
                .AddPack<SqlServerDefaultDbContextMigrationPack>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseOSharp();
        }
    }
}
