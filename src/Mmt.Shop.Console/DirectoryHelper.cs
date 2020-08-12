using System;
using System.IO;
using System.Reflection;

namespace Mmt.Shop.Console
{
    public static class DirectoryHelper
    {
        public static string GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.AbsolutePath).Directory.FullName;
        }
    }
}
