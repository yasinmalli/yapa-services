using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using yapa_api.Contracts;
using yapa_api.Models;
using yapa_api.Repositories;

namespace yapa_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddScopeObjects(services);
            services.AddDbContext<personalDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", 
                    builder => builder.WithOrigins(Configuration["CORS:AllowedOrigins"])
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void AddScopeObjects(IServiceCollection services)
        {
            services.AddScoped<IMainCategoryRepository, MainCategoryRepository>()
                    .AddScoped<ISubCategoryRepository, SubCategoryRepository>()
                    .AddScoped<IExpenseRepository, ExpenseRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();            
            app.UseCors("AllowOrigin");
            app.UseMvc();
        }
    }
}
