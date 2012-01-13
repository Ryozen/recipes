using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;
using System.ComponentModel.Composition;

namespace Recipes.ScriptRunners
{
    [Export(typeof(IScriptRunner))]
    public class CSharpScriptRunner : IScriptRunner
    {

        const string RUNNER_NAME = "csharp";

        public string Name
        {
            get { return RUNNER_NAME; }
        }

        public ExecutionResult Execute(ScriptContext context)
        {
            return new ExecutionResult() { Output = context.Parameters["message"] };
        }
    }
}
