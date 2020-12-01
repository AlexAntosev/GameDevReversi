using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Reversi.Business.Contracts.Services;
using Reversi.Business.Services;

namespace Reversi.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);
            
            services.AddControllers(c => c.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddSwaggerGen(
                s => { s.SwaggerDoc("v1", new OpenApiInfo { Title = "Reversi API", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Reversi API V1");
            });
            
            app.UseRouting();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "api/[controller]",
                        defaults: new { controller = "games" });
                });
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IBoardService, BoardService>();
        }
    }
}