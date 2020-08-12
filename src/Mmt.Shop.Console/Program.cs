using Microsoft.Extensions.DependencyInjection;
using Mmt.Shop.Console.Strategies;
using Mmt.Shop.Core;
using Mmt.Shop.DataAccess.ScriptRunner;
using System;
using System.IO;

namespace Mmt.Shop.Console
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<IDemoProgram>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDemoProgramStrategy, ApplyDbChangeLogStrategy>();  
            services.AddSingleton<IDemoProgramStrategy, ListCategoriesStrategy>();
            services.AddSingleton<IDemoProgramStrategy, ListFeaturedProductsStrategy>();
            services.AddSingleton<IDemoProgramStrategy, ListProductsInCategoryStrategy>();

            services.AddSingleton<IDemoProgram, DemoProgram>();   

            services.AddHttpClient(Strings.DemoClient, x =>
            {
                x.BaseAddress = new Uri(Environment.GetEnvironmentVariable(EnvironmentVariables.API_URL));
            });
            
            services.AddSingleton<IScriptRunnerClient, ScriptRunnerClient>();
            services.AddSingleton(x => new ScriptRunnerSettings
            {
                BasePath = Path.Combine(DirectoryHelper.GetExecutingDirectory(), Environment.GetEnvironmentVariable(EnvironmentVariables.DB_NAME)),
                ConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.CATALOGUE_CONN_STRING)
            });

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
