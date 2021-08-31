using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using EnglishTime.Core.Provider;
using EnglishTime.Core.Provider.Interfaces;
using EnglishTime.Data.SqlServer;
using EnglishTime.Data.SqlServer.Interfaces;
using EnglishTime.Data;
using AutoMapper;

namespace EnglishTime.ApiRest
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder => builder.WithOrigins("https://localhost:5002"));
            });

            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"), b => b.MigrationsAssembly("EnglishTime.ApiRest")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EnglishTime.ApiRest", Version = "v1" });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            // Need this to Patch works
            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITipProvider, TipProvider>();
            services.AddScoped<ITipRepository, TipRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnglishTime.ApiRest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
