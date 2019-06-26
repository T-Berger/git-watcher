using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Git_Watcher.Validation;
using Git_Watcher.Models;
using Git_Watcher.DataAccess;
using Git_Watcher.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FluentValidation.AspNetCore;
using FluentValidation;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Git_Watcher
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=localhost\sqlexpress;Database=gitwatcher;Integrated Security=True;";
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IGitRepo, GitRepo>();
            services.AddScoped<ISubscriptionRepo, SubscriptionRepo>();
            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddTransient<IValidator<Subscription>, SubscriptionValidator>();
            services.AddTransient<IValidator<GitRepository>, GitRepositoryValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Git-Watcher API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddSerilog();
            applicationLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
