using JobsAPI.Data;
using JobsAPI.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI
{
    public class Startup
    {
        public string JobsConnectionString { get; set; }
        public string EmConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JobsConnectionString = Configuration.GetConnectionString("JobsConnectionString");
            EmConnectionString = Configuration.GetConnectionString("EmConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<IConfiguration>(Configuration);
            services.AddControllers();  

            services.AddDbContext<JobsDbContext>(options => options.UseSqlServer(JobsConnectionString));
            services.AddTransient<JobsService>();
            services.AddTransient<PermissionsService>();
            services.AddTransient<RolesService>();
            services.AddTransient<AttachmentsService>();

            services.AddDbContext<EmDbContext>(options => options.UseSqlServer(EmConnectionString));
            services.AddTransient<JobDefsService>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobsAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobsAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
