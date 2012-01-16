using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

namespace Recipes.Shared
{
    public class RunnerCatalog
    {

        public RunnerCatalog()
            : this(new DirectoryCatalog("./"))
        {
        }

        protected void Initialize(ComposablePartCatalog catalog)
        {
            Scripts = new List<ScriptDefinition>();

            Container = new CompositionContainer(catalog);
            Container.ComposeParts(this);

            foreach (var runner in Runners)
            {
                runner.RunnerCatalog = this;
                var runnerScripts = runner.GetScripts();

                if (runnerScripts != null)
                {
                    Scripts.AddRange(runnerScripts);                    
                }
            }
        }

        public ScriptDefinition GetScript(string name, string type)
        {
            return Scripts.FirstOrDefault(s => s.Name == name && s.Type == type);
        }

        public RunnerCatalog(ComposablePartCatalog catalog)
        {
            Initialize(catalog);
        }

        [ImportMany(typeof(IScriptRunner))]
        public IEnumerable<IScriptRunner> Runners { get; private set; }

        public List<ScriptDefinition> Scripts { get; set; }

        public CompositionContainer Container { get; set; }

        public IScriptRunner this[string name]
        {
            get
            {
                IScriptRunner runner = Runners.FirstOrDefault(r => r.Name == name);

                if (runner == null)
                {
                    throw new NullReferenceException(string.Format("Runner [{0}] does not exist.", name));
                }

                return runner;
            }
        }

    }
}
