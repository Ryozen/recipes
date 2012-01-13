using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;

namespace Recipes.Core
{
    public class Runner
    {

        static Runner()
        {
            Initialize();
        }

        public static ExecutionResult Execute(ScriptContext context)
        {
            return Catalog[context.Type].Execute(context);
        }

        protected static void Initialize()
        {
            Catalog = new RunnerCatalog();
        }

        public static RunnerCatalog Catalog { get; private set; }

    }
}
