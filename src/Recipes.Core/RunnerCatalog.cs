using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

namespace Recipes.Core
{
    public class RunnerCatalog
    {

        public RunnerCatalog()
            : this(new DirectoryCatalog("./"))
        {
        }

        public RunnerCatalog(ComposablePartCatalog catalog)
        {
            Container = new CompositionContainer(catalog);
            Container.ComposeParts(this);
        }

        [ImportMany(typeof(IScriptRunner))]
        public IEnumerable<IScriptRunner> Runners { get; private set; }

        protected CompositionContainer Container { get; set; }

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
