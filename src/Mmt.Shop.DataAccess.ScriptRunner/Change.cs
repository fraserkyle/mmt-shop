using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mmt.Shop.DataAccess.ScriptRunner
{
    public class Change
    {
        public string Version { get; set; }

        public IEnumerable<string> Scripts { get; set; }
    }
}
