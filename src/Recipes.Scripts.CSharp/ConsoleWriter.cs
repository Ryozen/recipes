using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recipes.Shared;
using System.ComponentModel.Composition;

namespace Recipes.Scripts.CSharp
{

    [Export(typeof(IScript))]
    public class ConsoleWriter : IScript
    {
        const string SCRIPT_NAME = "cswrite";
        const string DESCRIPTION = "Writes message to screen";
        const string HELP = "[message] - writes the message passed to screen";

        public ExecutionResult Execute(ScriptContext context)
        {
            string message = context.Parameters["message"];

            Console.WriteLine(message);

            return new ExecutionResult() { Output = message };
        }

        public string Name 
        { 
            get { return SCRIPT_NAME; } 
        }

        public string Description 
        { 
            get { return DESCRIPTION; } 
        }

        public string Help 
        {
            get { return HELP; }
        }
    }
}
