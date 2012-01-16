using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

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

        public CompositionContainer Container { get; set; }

        public ExecutionResult Execute(ScriptContext context)
        {
            var scriptDef = RunnerCatalog.GetScript(context.Name, context.Type);

            if (scriptDef != null)
            {
                IScript script = scriptDef.Reference as IScript;

                if (script != null) return script.Execute(context);
            }

            return null;
        }

        public List<ScriptDefinition> GetScripts()
        {
            List<ScriptDefinition> scriptDefs = new List<ScriptDefinition>();
            Container = new CompositionContainer(new DirectoryCatalog("./"));
            Container.ComposeParts(this);

            foreach (var script in Scripts)
            {
                ScriptDefinition scriptDef = new ScriptDefinition()
                {
                    Name = script.Name,
                    Type = Name,
                    Description = script.Description,
                    Help = script.Help,
                    Reference = script
                };

                scriptDefs.Add(scriptDef);
            }

            return scriptDefs;
        }

        public RunnerCatalog RunnerCatalog { get; set; }

        [ImportMany(typeof(IScript))]
        public IEnumerable<IScript> Scripts { get; set; }
    }
}
