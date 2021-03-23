using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OSharp.AspNetCore.Mvc;
using OSharp.AspNetCore.Routing;
using OSharp.AutoMapper;
using OSharp.Log4Net;
using OSharp.Samples.MultipleDbContexts.Startups;


namespace OSharp.Samples.MultipleDbContexts
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOSharp()
                .AddPack<Log4NetPack>()
                .AddPack<MvcPack>()
                .AddPack<AutoMapperPack>()
                .AddPack<EndpointsPack>()
                .AddPack<SqlServerSqlServerDbContextMigrationPack>()
                .AddPack<MySqlMySqlDbContextMigrationPack>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseDefaultFiles().UseStaticFiles();

            app.UseOSharp();
        }
    }
}
