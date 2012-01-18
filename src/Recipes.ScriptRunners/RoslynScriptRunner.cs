using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;
using System.ComponentModel.Composition;
using System.IO;
using System.Xml;
using Roslyn.Scripting.CSharp;
using System.Runtime.Remoting.Messaging;

namespace Recipes.ScriptRunners
{
    [Export(typeof(IScriptRunner))]
    public class RoslynScriptRunner : IScriptRunner
    {

        const string RUNNER_NAME = "roslyn";

        public string Name
        {
            get { return RUNNER_NAME; }
        }

        public ExecutionResult Execute(ScriptContext context)
        {
            ScriptDefinition def = RunnerCatalog.GetScript(context.Name);

            string script = null;

            using (StreamReader reader = new StreamReader((string)def.Reference))
            {
                script = reader.ReadToEnd();
                reader.Close();
            }

            CallContext.SetData("rsprop", context.Parameters);
            
            ScriptEngine engine = new ScriptEngine();
            object result = engine.Execute(script);

            return new ExecutionResult() { Output = result.ToString() };
        }

        public RunnerCatalog RunnerCatalog { get; set; }

        public List<ScriptDefinition> GetScripts()
        {
            List<ScriptDefinition> defs = new List<ScriptDefinition>();

            var defFiles = Directory.GetFiles("./", "*.rsinfo");

            foreach (var file in defFiles)
            {
                defs.Add(readDef(file));
            }

            return defs;
        }

        private ScriptDefinition readDef(string file)
        {
            ScriptDefinition def = new ScriptDefinition();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            def.Name = doc.GetElementsByTagName("name")[0].InnerText;
            def.Description = doc.GetElementsByTagName("description")[0].InnerText;
            def.Help = doc.GetElementsByTagName("help")[0].InnerText;
            def.Reference = doc.GetElementsByTagName("reference")[0].InnerText;

            return def;
        }
    }
}
