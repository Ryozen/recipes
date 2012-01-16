using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Shared
{
    public interface IScript
    {

        string Name { get; }
        string Description { get; }
        string Help { get; }
        ExecutionResult Execute(ScriptContext context);

    }
}
