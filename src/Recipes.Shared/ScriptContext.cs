using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Shared
{
    public class ScriptContext
    {

        public string Name { get; set; }

        public string Type { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

    }
}
