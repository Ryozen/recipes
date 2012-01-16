using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;

namespace Recipes.ScriptRunners
{
    public class IronRubyScriptRunner : IScriptRunner
    {

        const string RUNNER_NAME = "ruby";

        public string Name
        {
            get { return RUNNER_NAME; }
        }

        public ExecutionResult Execute(ScriptContext context)
        {
            throw new NotImplementedException();
        }


        public RunnerCatalog RunnerCatalog
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<ScriptDefinition> GetScripts()
        {
            return null;
        }
    }
}
