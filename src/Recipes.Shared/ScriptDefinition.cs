using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Shared
{
    public class ScriptDefinition
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Help { get; set; }
        public string Type { get; set; }
        public object Reference { get; set; }

    }
}
