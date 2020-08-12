using System;
using System.IO;
using System.Reflection;
using Mmt.Shop.Core;
using Mmt.Shop.DataAccess.ScriptRunner;

namespace Mmt.Shop.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Setting up database...");
            ExecuteScriptRunner();

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("COMPLETE");
            System.Console.Read();
        }

        private static void ExecuteScriptRunner()
        {
            var client = new ScriptRunnerClient(new ScriptRunnerSettings
            {
                BasePath = Path.Combine(GetExecutingDirectory(), Environment.GetEnvironmentVariable(EnvironmentVariables.DB_NAME)),
                ConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.CATALOGUE_CONN_STRING)
            });

            client.Run();
        }

        public static string GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.AbsolutePath).Directory.FullName;
        }
    }
}
