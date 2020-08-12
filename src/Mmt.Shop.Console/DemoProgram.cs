using Mmt.Shop.Console.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmt.Shop.Console
{
    public interface IDemoProgram
    {
        void Run();
    }

    public class DemoProgram : IDemoProgram
    {
        private IEnumerable<IDemoProgramStrategy> _strategies;

        public DemoProgram(IEnumerable<IDemoProgramStrategy> strategies)
        {
            _strategies = strategies;
        }

        public void Run()
        {
            var input = string.Empty;

            while (input != "Q")
            {
                System.Console.WriteLine("A) Apply database change log");
                System.Console.WriteLine("B) List categories");
                System.Console.WriteLine("C) List featured products");
                System.Console.WriteLine("D) List products in category");
                System.Console.WriteLine("Q) Quit");

                System.Console.Write("Select an option: ");

                input = System.Console.ReadKey().KeyChar.ToString().ToUpper();

                System.Console.Clear();

                switch (input)
                {
                    case "A":
                        _strategies.OfType<ApplyDbChangeLogStrategy>().First().Execute().Wait();
                        break;
                    case "B":
                        _strategies.OfType<ListCategoriesStrategy>().First().Execute().Wait();
                        break;
                    case "C":
                        _strategies.OfType<ListFeaturedProductsStrategy>().First().Execute().Wait();
                        break;
                    case "D":
                        _strategies.OfType<ListCategoriesStrategy>().First().Execute().Wait();
                        _strategies.OfType<ListProductsInCategoryStrategy>().First().Execute().Wait();
                        break;
                }

                System.Console.WriteLine();
            }
        }

        private void ExecuteStrategy<T>()
            where T : IDemoProgramStrategy
        {
            _strategies.OfType<T>().First().Execute();
        }
    }
}
