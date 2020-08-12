using Mmt.Shop.DataAccess.ScriptRunner;
using System.Threading.Tasks;

namespace Mmt.Shop.Console.Strategies
{    public class ApplyDbChangeLogStrategy : IDemoProgramStrategy
    {
        private readonly IScriptRunnerClient _client;

        public ApplyDbChangeLogStrategy(IScriptRunnerClient client)
        {
            _client = client;
        }

        public Task Execute()
        {
            System.Console.Write("Applying database change log...  ");
            _client.Run();
            System.Console.WriteLine("DONE.");
            System.Console.WriteLine();

            return Task.CompletedTask;
        }        
    }
}
