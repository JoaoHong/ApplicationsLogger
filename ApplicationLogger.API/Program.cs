using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApplicationsLogger.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Newtonsoft.Json;
namespace ApplicationLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            var config = builder.Configuration;

            var env = builder.Environment;

            var connectionString = config.GetConnectionString(env.EnvironmentName);
            var databaseName = "sample_mflix";

            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
            services.AddSingleton(new MongoDbContext(connectionString, databaseName));


            // Add services to the container.
            services.AddRazorPages();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );



            var app = builder.Build();

            var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

            lifetime.ApplicationStopping.Register(() =>
            {
                // Obter o serviço de escopo para acessar o IMongoClient
                using (var scope = app.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();

                    // Não é necessário fechar explicitamente o IMongoClient
                    // O driver do MongoDB C# gerencia a conexão automaticamente
                    // Se necessário, você pode liberar outros recursos relacionados aqui
                }
            });
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}",
                    defaults: new { controller = "Movies", action = "Index" });
            });
            app.MapRazorPages();

            app.Run();

        }
    }
}

